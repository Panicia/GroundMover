using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace GroundMover
{
    public partial class Form1 : Form
    {
        Thread myThread;
        delegate void WriteIntDelegate(int progress);
        delegate void WriteLineDelegate(string gcode);
        delegate void ChangeSendingDelegate(bool sending);
        COMports Ports;
        HelpList list;
        double radius;
        double speed;
        double repeatNumber;
        double pauseLayers;
        double delayRasp;
        int disperInterval;
        int disperTime;
        static bool DispEn;
        bool alternateLayers;
        bool goZero;
        bool goZero2;
        string form; // последовательно .. диагонально
        double maxX = 140;
        double maxY = 140;
        iPoint Coordinates;
        iPoint Sizes;
        Drawer d;
        List<string> GCodeStack;
        List<string> preparedGcode;
        List<iPoint> layer;
        bool sending = false;
        bool CompressorIsOn = false;
        bool AeroIsOn = false;
        static bool Stop = false;
        public Form1()
        {
            InitializeComponent();
            Ports = new COMports(9600);
            list = new HelpList(listBox1);
            layer = new List<iPoint>();
            d = new Drawer(pictureBox1);
            CheckPort(); 
            figureComboB.Text = figureComboB.Items[0].ToString();
            
            setDefValues();
            GCodeStack = new List<string>();
            preparedGcode = new List<string>();
        }
        private void ChangeSending(bool _sending)
        {
            sending = _sending;
        }
        private void WriteProgress(int progress)
        {
            progressBar1.Value = progress;
        }
        private void WriteGcode(string gcode)
        {
            gcodelabel2.Text = gcode;
        }
        private bool CheckPort()
        {
            COMportsCB.Items.Clear();
            for (int i = 0; i < Ports.GetActPorts().Length; i++)
            {
                COMportsCB.Items.Add(Ports.GetActPorts()[i]);
            }
            if (COMportsCB.Items.Count > 0)
            {
                COMportsCB.Text = COMportsCB.Items[0].ToString();
            }
            if (Ports.IsPortOpen())
            {
                list.AddMsg("Port opened");
                COMportsCB.Enabled = false;
                COMbutton.Text = "Disconnect";
                return true;
            }
            else
            {
                list.AddMsg("Port closed");
                COMportsCB.Enabled = true;
                COMbutton.Text = "Connect";
                return false;
            }
        }
        void setDefValues()
        {
            speedTB.Text = "1800";
            radTB.Text = "4";
            figureComboB.SelectedIndex = 0;
            alterLayerChB.Checked = false;
            goZeroZhB.Checked = false;
            goZero2ChB.Checked = false;
            repeatNumberTB.Text = "5";
            sizeXTB.Text = "20";
            sizeYTB.Text = "20";
            coordXTB.Text = "0";
            coordYTB.Text = "0";
            delayRasTB.Text = "100";
            pauseLayersTB.Text = "1500";
            DisperTimeTB.Text = "1500";
            DisperIntervalTB.Text = "1000";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (sending)
            {
                Stop = true;
            }
            if (myThread != null)
            {
                while (true)
                {
                    if (!myThread.IsAlive)
                        break;
                }
            }
            Close();
        }

        private void COMbutton_Click(object sender, EventArgs e)
        {
            if (Ports.IsPortOpen())
            {
                Ports.ClosePort();
            }
            else
            {
                Ports.OpenPort(COMportsCB.Text);
            }
            CheckPort();
        }

        double filterDouble(string doub, double max)
        {
            try
            {
                if (Convert.ToDouble(doub) > max) return -1.0;
                else return Convert.ToDouble(doub);
            }
            catch(Exception)
            {
                return -1.0;
            }
        }

        private void SpeedTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(speedTB.Text, 10000);
            if (a != -1.0) speed = a;
            else speedTB.Text = "";
        }

        private void FigureComboB_SelectedIndexChanged(object sender, EventArgs e)
        {
            form = figureComboB.Text;
        }

        private void RadTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(radTB.Text, 10000);
            if (a != -1.0) radius = a;
            else radTB.Text = "";
        }


        private void SizeXTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(sizeXTB.Text, 10000);
            if (a != -1.0) Sizes.X = a;
            else sizeXTB.Text = "";
        }

        private void SizeYTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(sizeYTB.Text, 10000);
            if (a != -1.0) Sizes.Y = a;
            else sizeYTB.Text = "";
        }

        private void CoordXTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(coordXTB.Text, 10000);
            if (a != -1.0) Coordinates.X = a;
            else coordXTB.Text = "";
        }

        private void CoordYTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(coordYTB.Text, 10000);
            if (a != -1.0) Coordinates.Y = a;
            else coordYTB.Text = "";
        }

        private void AlterLayerChB_CheckedChanged(object sender, EventArgs e)
        {
            alternateLayers = alterLayerChB.Checked;
        }

        private void RepeatNumberTB_TextChanged(object sender, EventArgs e)
        {
            bool ex = false;
            if (repeatNumberTB.Text == "") ex = true;
            for (int i = 0; i < repeatNumberTB.Text.Length; i++)
            {
                bool numb = false;
                for (int j = 0; j < 10; j++)
                {
                    if (repeatNumberTB.Text.Substring(i, 1) == Convert.ToString(j))
                        numb = true;
                }
                if (numb == false)
                {
                    repeatNumberTB.Text = "";
                    ex = true;
                    break;
                }
            }
            if (!ex)
            {
                if (Convert.ToInt32(repeatNumberTB.Text) < 10000)
                {
                    repeatNumber = Convert.ToInt32(repeatNumberTB.Text);
                }
                else repeatNumberTB.Text = "";
            }
        }
        string createG1(double wx, double wy)
        {
            return "G01" +
                    " X" + Convert.ToString(Math.Round(wx, 2)) +
                    " Y" + Convert.ToString(Math.Round(wy, 2));
        }
        List<iPoint> rotateVertical(List<iPoint> firstList)
        {
            double polY;
            polY = Sizes.Y + Coordinates.Y;
            List<iPoint> secondList = new List<iPoint>();
            for(int i = 0; i < firstList.Count; i++)
            {
                double y, newY;
                polY = Sizes.Y / 2 + Coordinates.Y;
                y = firstList[i].Y;
                if (polY < y)
                {
                    newY = polY - (y - polY);
                }
                else
                {
                    newY = polY + (polY - y);
                }
                secondList.Add(new iPoint(firstList[i].X, newY));
            }
            for(int i = 0; i < secondList.Count; i++)
            {
                if(secondList[i].X < 0)
                {
                    double p = secondList[i].X;
                    for (int j = 0; j < secondList.Count; j++)
                    {
                        secondList[j] = new iPoint(secondList[j].X - p, secondList[j].Y);
                    }
                }
                if (secondList[i].Y < 0)
                {
                    double p = secondList[i].Y;
                    for (int j = 0; j < secondList.Count; j++)
                    {
                        secondList[j] = new iPoint(secondList[j].X, secondList[j].Y - p);
                    }
                }
            }
            return secondList;
        }
        List<iPoint> rotateGorizontal(List<iPoint> firstList)
        {
            double polX;
            polX = Sizes.X + Coordinates.X;
            List<iPoint> secondList = new List<iPoint>();
            for (int i = 0; i < firstList.Count; i++)
            {
                double x, newX;
                polX = Sizes.X / 2 + Coordinates.X;
                x = firstList[i].X;
                if (polX < x)
                {
                    newX = polX - (x - polX);
                }
                else
                {
                    newX = polX + (polX - x);
                }
                secondList.Add(new iPoint(newX, firstList[i].Y));
            }
            for (int i = 0; i < secondList.Count; i++)
            {
                if (secondList[i].X < 0)
                {
                    double p = secondList[i].X;
                    for (int j = 0; j < secondList.Count; j++)
                    {
                        secondList[j] = new iPoint(secondList[j].X + p, secondList[j].Y);
                    }
                }
                if (secondList[i].Y < 0)
                {
                    double p = secondList[i].Y;
                    for (int j = 0; j < secondList.Count; j++)
                    {
                        secondList[j] = new iPoint(secondList[j].X, secondList[j].Y + p);
                    }
                }
            }
            return secondList;
        }
        void createLayerLinear(bool lay2)
        {
            layer = new List<iPoint>();
            int a = Convert.ToInt16(Sizes.X / radius - 1);
            int b = Convert.ToInt16(Sizes.Y / radius - 1);
            layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + radius / 2 ));
            if (!lay2)
            {
                for (int j = 0; j < b; j++)
                {
                    if ((j + 1) % 2 != 0) //нечетный проход
                    {
                        layer.Add(new iPoint(Coordinates.X + a * radius + radius / 2, Coordinates.Y + radius / 2 + j * radius));
                        if ((j + 1) != b) // не последний проход
                        {
                            layer.Add(new iPoint(Coordinates.X + a * radius + radius / 2, Coordinates.Y + radius / 2 + (j + 1) * radius));
                        }
                    }
                    if ((j + 1) % 2 == 0) // четный проход
                    {
                        layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + radius / 2 + j * radius));
                        if ((j + 1) != b) // не последний проход
                        {
                            layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + radius / 2 + (j + 1) * radius));
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < a; j++)
                {
                    if ((j + 1) % 2 != 0) //нечетный проход
                    {
                        layer.Add(new iPoint(Coordinates.X + radius * j + radius / 2, Coordinates.Y + radius / 2 + b * radius));
                        if ((j + 1) != a) // не последний проход
                        {
                            layer.Add(new iPoint(Coordinates.X + radius * (j + 1) + radius / 2, Coordinates.Y + radius / 2 + b * radius));
                        }
                    }
                    if ((j + 1) % 2 == 0) // четный проход
                    {
                        layer.Add(new iPoint(Coordinates.X + radius * j + radius / 2, Coordinates.Y + radius / 2));
                        if ((j + 1) != a) // не последний проход
                        {
                            layer.Add(new iPoint(Coordinates.X + radius * (j + 1) + radius / 2, Coordinates.Y + radius / 2));
                        }
                    }
                }
            }
        }
        void createLayerDiagonal()
        {
            layer = new List<iPoint>();
            double rad = radius / Math.Cos(Math.PI / 4.0);
            int a = Convert.ToInt16(Sizes.X / (rad) - 1);
            int b = Convert.ToInt16(Sizes.Y / (rad) - 1);
            layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + radius / 2));
            int pl = 0; // 0 - сверху налево, 1 - сверху вниз, 2 - справа налево, 3 - справа вниз
            bool up = true;
            for (int j = 0; j + 1 < a + b; j++)
            {
                if (up && pl == 0) // вверху и сверху налево
                {
                    if (j != a)
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j + 1) + radius / 2, Coordinates.Y + radius / 2));
                    }
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                        pl = 2;
                    }
                    if (j != b)
                    {
                        layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + rad * (j + 1) + radius / 2));
                    }
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                        if (pl == 0)
                            pl = 1;
                        else if (pl == 2)
                            pl = 3;
                    }
                    up = !up;
                }
                else if (!up && pl == 0) // внизу и сверху налево
                {
                    if (j != b)
                    {
                        layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + rad * (j + 1) + radius / 2));
                    }
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                        pl = 1;
                    }
                    if (j != a)
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j + 1) + radius / 2, Coordinates.Y + radius / 2));
                    }
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                        if (pl == 0)
                            pl = 2;
                        else if (pl == 1)
                            pl = 3;
                    }
                    up = !up;
                }
                else if (up && pl == 1) // вверху и сверху вниз
                {
                    if (j != a)
                        layer.Add(new iPoint(Coordinates.X + rad * (j + 1) + radius / 2, Coordinates.Y + radius / 2));
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                        pl = 3;
                    }
                    layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                    up = !up;
                }
                else if (!up && pl == 1) // внизу и сверху вниз
                {
                    layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                    if (j != a)
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j + 1) + radius / 2, Coordinates.Y + radius / 2));
                    }
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                        pl = 3;
                    }
                    up = !up;
                }
                else if(up && pl == 2) // вверху и справа налево
                {
                    layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                    if (j != b)
                        layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + rad * (j + 1) + radius / 2));
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                        pl = 3;
                    }
                    up = !up;
                }
                else if (!up && pl == 2) // внизу и справа налево
                {
                    if (j != b)
                        layer.Add(new iPoint(Coordinates.X + radius / 2, Coordinates.Y + rad * (j + 1) + radius / 2));
                    else
                    {
                        layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                        pl = 3;
                    }
                    layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                    up = !up;
                }
                else if(up && pl == 3) // вверху и справа вниз
                {
                    layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                    layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                    up = !up;
                }
                else if (!up && pl == 3) // внизу и справа вниз
                {
                    layer.Add(new iPoint(Coordinates.X + rad * (j - b + 1) + radius / 2, Coordinates.Y + rad * b + radius / 2));
                    layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * (j - a + 1) + radius / 2));
                    up = !up;
                }
            }
            layer.Add(new iPoint(Coordinates.X + rad * a + radius / 2, Coordinates.Y + rad * b + radius / 2));
        }
        void createLayerConcentric()
        {
            layer = new List<iPoint>();
            int a = Convert.ToInt16(Sizes.X / radius - 1);
            int b = Convert.ToInt16(Sizes.Y / radius - 1);
            int d;
            if (a > b)
                d = b;
            else
                d = a;
            for (int j = 0; j < d/2 + 1; j++)
            {
                if(j == 0)
                    layer.Add(new iPoint(Coordinates.X + radius * j + radius / 2, Coordinates.Y + radius * j + radius / 2));
                else
                    layer.Add(new iPoint(Coordinates.X + radius * (j - 1) + radius / 2, Coordinates.Y + radius * j + radius / 2));
                    layer.Add(new iPoint(Coordinates.X + radius * (a - j) + radius / 2, Coordinates.Y + radius * j + radius / 2));
                    layer.Add(new iPoint(Coordinates.X + radius * (a - j) + radius / 2, Coordinates.Y + radius * (b - j) + radius / 2));
                    layer.Add(new iPoint(Coordinates.X + radius * j + radius / 2, Coordinates.Y + radius * (b - j) + radius / 2));
                if (j == d / 2 && d % 2 != 0)
                {
                    layer.Add(new iPoint(Coordinates.X + radius * j + radius / 2, Coordinates.Y + radius * (j + 1) + radius / 2));
                }
            }
        }
        void createGCODElinar()
        {
            createLayerLinear(true);
            List<iPoint> layer2 = layer;
            createLayerLinear(false);
            if (Coordinates.X + Sizes.X > maxX || Coordinates.Y + Sizes.Y > maxY)
            {
                list.AddMsg("Dimentions are too big");
                return;
            }
            GCodeStack = new List<string>();
            GCodeStack.Add("%");
            GCodeStack.Add("M01"); // включение моторов
            if(DispEn)
                GCodeStack.Add("M06 P" + Convert.ToString(disperTime) + " N" + Convert.ToString(disperInterval));
            if (goZero)
                GCodeStack.Add("G00");
            GCodeStack.Add("G01" +
                " X" + Convert.ToString(Math.Round(Coordinates.X + radius / 2, 2)) +
                " Y" + Convert.ToString(Math.Round(Coordinates.Y + radius / 2, 2)) +
                " F" + Convert.ToString(speed));
            for (int i = 0; i < repeatNumber; i++)
            {
                GCodeStack.Add("M03"); // включение распыления
                if(delayRasp > 0)
                    GCodeStack.Add("M25 P" + Convert.ToString(Math.Round(delayRasp, 2))); //задержка включения распылителя
                if (!alternateLayers || (i + 1) % 2 != 0) // нечетный или нечередующийся
                {
                    for (int j = 0; j < layer.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer[j].X, layer[j].Y));
                    }
                }
                else if(((i + 1) % 2) == 0 && alternateLayers) // четный слой и чередующийся
                {
                    for (int j = 0; j < layer2.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer2[j].X, layer2[j].Y));
                    }
                }
                GCodeStack.Add("M05"); // остановка распыления
                if ((i + 1) != repeatNumber) // не последний слой
                {
                    if (pauseLayers > 0)
                        GCodeStack.Add("M25 P" + Convert.ToString(Math.Round(pauseLayers, 2))); //пауза на время 
                    if (alternateLayers && (i + 2) % 2 == 0)
                    {
                        GCodeStack.Add(createG1(layer2[0].X, layer2[0].Y));
                    }
                    else if (!alternateLayers || (i + 2) % 2 != 0)
                    {
                        GCodeStack.Add(createG1(layer[0].X, layer[0].Y));
                    }
                }
            }
            if (goZero2)
                GCodeStack.Add("G00"); // к начальной точке
            GCodeStack.Add("M07");
            GCodeStack.Add("M00"); // выключение моторов
            GCodeStack.Add("M30"); // конец программы
            prepareGcode(GCodeStack);
        }
        void createGCODEdiagonal()
        {
            createLayerDiagonal();
            List<iPoint> layer2 = rotateVertical(layer);
            if (Coordinates.X + Sizes.X > maxX || Coordinates.Y + Sizes.Y > maxY)
            {
                list.AddMsg("Dimentions are too big");
                return;
            }
            GCodeStack = new List<string>();
            GCodeStack.Add("%");
            GCodeStack.Add("M01"); // включение моторов
            if (DispEn)
                GCodeStack.Add("M06 P" + Convert.ToString(disperTime) + " N" + Convert.ToString(disperInterval));
            if (goZero)
                GCodeStack.Add("G00");
            GCodeStack.Add("G01" +
                " X" + Convert.ToString(Math.Round(Coordinates.X + radius / 2, 2)) +
                " Y" + Convert.ToString(Math.Round(Coordinates.Y + radius / 2, 2)) +
                " F" + Convert.ToString(speed));
            for (int i = 0; i < repeatNumber; i++)
            {
                GCodeStack.Add("M03"); // включение распыления
                if (!alternateLayers || (i + 1) % 2 != 0) // нечетный или нечередующийся
                {
                    for(int j = 0; j < layer.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer[j].X, layer[j].Y));
                    }
                }
                if (alternateLayers && (i + 1) % 2 == 0) // четный и чередующийся
                {
                    for (int j = 0; j < layer.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer2[j].X, layer2[j].Y));
                    }
                }
                GCodeStack.Add("M05"); // остановка распыления
                if ((i + 1) != repeatNumber) // не последний слой
                {
                    if (pauseLayers > 0)
                        GCodeStack.Add("M25 P" + Convert.ToString(Math.Round(pauseLayers, 2))); //пауза на время 
                    if (alternateLayers && (i + 2) % 2 == 0)
                    {
                        GCodeStack.Add(createG1(layer2[0].X, layer2[0].Y));
                    }
                    else if (!alternateLayers || (i + 2) % 2 != 0)
                    {
                        GCodeStack.Add(createG1(layer[0].X, layer[0].Y));
                    }
                }
            }
            if (goZero2)
                GCodeStack.Add("G00"); // к начальной точке
            GCodeStack.Add("M07");
            GCodeStack.Add("M00"); // выключение моторов
            GCodeStack.Add("M30"); // конец программы
            prepareGcode(GCodeStack);
        }
        void createGCODEconcentric() 
        {
            createLayerConcentric();
            List<iPoint> layer2 = rotateGorizontal(rotateVertical(layer)); 
            //List<iPoint> layer2 = layer;
            if (Coordinates.X + Sizes.X > maxX || Coordinates.Y + Sizes.Y > maxY)
            {
                list.AddMsg("Dimentions are too big");
                return;
            }
            GCodeStack = new List<string>();
            GCodeStack.Add("%");
            GCodeStack.Add("M01"); // включение моторов
            if (DispEn)
                GCodeStack.Add("M06 P" + Convert.ToString(disperTime) + " N" + Convert.ToString(disperInterval));
            if (goZero)
                GCodeStack.Add("G00");
            GCodeStack.Add("G01" +
                " X" + Convert.ToString(Math.Round(Coordinates.X + radius / 2, 2)) +
                " Y" + Convert.ToString(Math.Round(Coordinates.Y + radius / 2, 2)) +
                " F" + Convert.ToString(speed));
            for (int i = 0; i < repeatNumber; i++)
            {
                GCodeStack.Add("M03"); // включение распыления
                if (!alternateLayers || (i + 1) % 2 != 0) // нечетный или нечередующийся
                {
                    for (int j = 0; j < layer.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer[j].X, layer[j].Y));
                    }
                }
                if (alternateLayers && (i + 1) % 2 == 0) // четный и чередующийся
                {
                    for (int j = 0; j < layer.Count; j++)
                    {
                        GCodeStack.Add(createG1(layer2[j].X, layer2[j].Y));
                    }
                }
                GCodeStack.Add("M05"); // остановка распыления
                if ((i + 1) != repeatNumber) // не последний слой
                {
                    if (pauseLayers > 0)
                        GCodeStack.Add("M25 P" + Convert.ToString(Math.Round(pauseLayers, 2))); //пауза на время 
                    if (alternateLayers && (i + 2) % 2 == 0)
                    {
                        GCodeStack.Add(createG1(layer2[0].X, layer2[0].Y));
                    }
                    else if (!alternateLayers || (i + 2) % 2 != 0)
                    {
                        GCodeStack.Add(createG1(layer[0].X, layer[0].Y));
                    }
                }
            }
            if (goZero2)
                GCodeStack.Add("G00"); // к начальной точке
            GCodeStack.Add("M07");
            GCodeStack.Add("M00"); // выключение моторов
            GCodeStack.Add("M30"); // конец программы
            prepareGcode(GCodeStack);
        }
        void SendGcode()
        {
            bool endisp = DispEn;
            for (int i = 0; i < preparedGcode.Count; i++)
            {
                if (Ports.IsPortOpen())
                {
                    if (Stop)
                    {
                        Ports.SendMessage("M00");
                        while (true)
                        {
                            if (Ports.Avalilable())
                            {
                                if (Ports.buffer == "1")
                                {
                                    Ports.ClearBuffer();
                                    break;
                                }
                            }
                        }
                        Ports.SendMessage("M07");
                        while (true)
                        {
                            if (Ports.Avalilable())
                            {
                                if (Ports.buffer == "1")
                                {
                                    Ports.ClearBuffer();
                                    break;
                                }
                            }
                        }
                        Ports.SendMessage("M05");
                        while (true)
                        {
                            if (Ports.Avalilable())
                            {
                                if (Ports.buffer == "1")
                                {
                                    Ports.ClearBuffer();
                                    break;
                                }
                            }
                        }
                        Ports.SendMessage("M30");
                        while (true)
                        {
                            if (Ports.Avalilable())
                            {
                                if (Ports.buffer == "1")
                                {
                                    Ports.ClearBuffer();
                                    break;
                                }
                            }
                        }
                        BeginInvoke(new WriteIntDelegate(WriteProgress), 0);
                        Stop = false;
                        return;
                    }
                    if(DispEn != endisp)
                    {
                        if(!DispEn)
                        {
                            Ports.SendMessage("M07");
                            while (true)
                            {
                                if (Ports.Avalilable())
                                {
                                    if (Ports.buffer == "1")
                                    {
                                        Ports.ClearBuffer();
                                        break;
                                    }
                                }
                            }
                            endisp = DispEn;
                        }
                        else
                        {
                            Ports.SendMessage("M06 P" + Convert.ToString(disperTime) + " N" + Convert.ToString(disperInterval));
                            while (true)
                            {
                                if (Ports.Avalilable())
                                {
                                    if (Ports.buffer == "1")
                                    {
                                        Ports.ClearBuffer();
                                        break;
                                    }
                                }
                            }
                            endisp = DispEn;
                        }
                    }
                    int progress = Convert.ToInt32((Convert.ToDouble(i + 1) / Convert.ToDouble(preparedGcode.Count)) * 100.0);
                    BeginInvoke(new WriteIntDelegate(WriteProgress), progress);
                    BeginInvoke(new WriteLineDelegate(WriteGcode), preparedGcode[i]);
                    Ports.SendMessage(preparedGcode[i]);
                    while (true)
                    {
                        if (Ports.Avalilable())
                        {
                            if(Ports.buffer == "1")
                            {
                                Ports.ClearBuffer();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    list.AddMsg("Port have been closed");
                    CheckPort();
                    return;
                }
            }
            BeginInvoke(new ChangeSendingDelegate(ChangeSending), false);
            BeginInvoke(new WriteIntDelegate(WriteProgress), 0);
        }
        void prepareGcode(List<string> gcode)
        {
            preparedGcode = new List<string>();
            for(int i = 0; i < gcode.Count; i++)
            {
                string codik = "";
                for(int j = 0; j < gcode[i].Length; j++)
                {
                    string codichek = gcode[i].Substring(j, 1);
                    if (codichek != ",")
                        codik += codichek;
                    else
                        codik += ".";
                }
                preparedGcode.Add(codik);
            }
            gcode = preparedGcode;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Coordinates.X + Sizes.X > maxX || Coordinates.Y + Sizes.Y > maxY)
            {
                list.AddMsg("Dimentions are too big");
                return;
            }
            else
            {
                switch (form)
                {
                    case "Линейное":  
                        createGCODElinar();
                        break;
                    case "Диагональное":
                        createGCODEdiagonal();
                        break;
                    case "Концентрическое":
                        createGCODEconcentric();
                        break;
                }
                list.ClearList();
                //d.Draw(rotateVertical(layer));
                d.Draw(layer);
                for (int i = 0; i < preparedGcode.Count; i++)
                {
                    list.AddMsg(preparedGcode[i]);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            list.ClearList();
            d.Clear();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!CheckPort())
            {
                return;
            }
            sending = true;
            myThread = new Thread(SendGcode); //Создаем новый объект потока (Thread)
            myThread.Start(); //запускаем поток
        }

        private void PauseLayersTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(pauseLayersTB.Text, 10000);
            if (a != -1.0) pauseLayers = a;
            else pauseLayersTB.Text = "";
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            goZero = goZeroZhB.Checked;
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            goZero2 = goZero2ChB.Checked;
        }

        private void DelayRasTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(delayRasTB.Text, 10000);
            if (a != -1.0) delayRasp = a;
            else delayRasTB.Text = "";
        }

        private void CheckBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            DispEn = DispEnChB.Checked;
        }

        private void DisperIntervalTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(DisperIntervalTB.Text, 1000000);
            if (a != -1.0) disperInterval = Convert.ToInt32(a);
            else DisperIntervalTB.Text = "";
        }

        private void DisperTimeTB_TextChanged(object sender, EventArgs e)
        {
            double a = filterDouble(DisperTimeTB.Text, 1000000);
            if (a != -1.0) disperTime = Convert.ToInt32(a);
            else DisperTimeTB.Text = "";
        }
        bool SendCommand(string command)
        {
            if (Ports.IsPortOpen())
            {
                Ports.SendMessage("%");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage(command);
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage("M30");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                DispEn = true;
                return true;
            }
            else
            {
                list.AddMsg("Port is not open");
                return false;
            }
        }
        bool SendDisperOn()
        {
            if (Ports.IsPortOpen())
            {
                Ports.SendMessage("%");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage("M06 P" + Convert.ToString(disperTime) + " N" + Convert.ToString(disperInterval));
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage("M30");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                DispEn = true;
                return true;
            }
            else
            {
                list.AddMsg("Port is not open");
                return false;
            }
        }

        bool SendDisperOff()
        {
            if (Ports.IsPortOpen())
            {
                Ports.SendMessage("%");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage("M07");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                Ports.SendMessage("M30");
                while (true)
                {
                    if (Ports.Avalilable())
                    {
                        if (Ports.buffer == "1")
                        {
                            Ports.ClearBuffer();
                            break;
                        }
                    }
                }
                DispEn = false;
                return true;
            }
            else
            {
                list.AddMsg("Port is not open");
                return false;
            }
        }

        private void DisperOnBtn_Click(object sender, EventArgs e)
        {
            if (!DispEn)
            {
                if (sending)
                {
                    DispEn = true;
                    DisperOnBtn.Text = "Выключить диспергатор";
                }
                else
                {
                    if(SendDisperOn())
                        DisperOnBtn.Text = "Выключить диспергатор";
                }

            }
            else
            {
                if (sending)
                {
                    DispEn = false;
                    DisperOnBtn.Text = "Включить диспергатор";
                }
                else
                {
                    if(SendDisperOff())
                        DisperOnBtn.Text = "Включить диспергатор";
                }
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (sending)
            {
                Stop = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!sending)
            {
                if (CompressorIsOn)
                {
                    if (SendCommand("M09"))
                    {
                        buttonCompressor.Text = "Включить диспергатор";
                        CompressorIsOn = false;
                    }
                }
                else
                {
                    if (SendCommand("M08"))
                    {
                        buttonCompressor.Text = "Выключить диспергатор";
                        CompressorIsOn = true;
                    }
                }
            }
        }

        private void buttonAerograph_Click(object sender, EventArgs e)
        {
            if (!sending)
            {
                if (AeroIsOn)
                {
                    if (SendCommand("M12"))
                    {
                        buttonAerograph.Text = "Поднять курок";
                        AeroIsOn = false;
                    }
                }
                else
                {
                    if (SendCommand("M11"))
                    {
                        buttonAerograph.Text = "Опустить курок";
                        AeroIsOn = true;
                    }
                }
            }
        }
    }
}

class Saiver
{

}

struct iPoint 
{
    public iPoint(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double X;
    public double Y;
}

class Drawer
{
    protected SolidBrush b;
    protected Pen p;
    protected Graphics g;
    double skale = 2.5;
    public Drawer(PictureBox pictureBox)
    {
        g = pictureBox.CreateGraphics();
        p = new Pen(Color.Black);
        b = new SolidBrush(Color.Black);
    }
    public void Draw(List<iPoint> list)
    {
        Clear();
        for(int i = 0; i < list.Count - 1; i++)
        {
            g.DrawLine(p, Convert.ToSingle(list[i].X * skale), 
                Convert.ToSingle(list[i].Y * skale), 
                Convert.ToSingle(list[i + 1].X * skale),
                Convert.ToSingle(list[i + 1].Y * skale));
        }
    }
    public void Clear()
    {
        g.Clear(Color.White);
    }
}
class COMports
{
    public string buffer;
    SerialPort Port;
    int BoudRate;
    public COMports(int boudrate)
    {
        BoudRate = boudrate;
        buffer = "";
        Port = new SerialPort();
        Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
    }


    public string[] GetActPorts()
    {
        return SerialPort.GetPortNames();
    }
    public bool OpenPort(string port)
    {
        try
        {
            Port.BaudRate = BoudRate;
            Port.PortName = port;
            Port.Open();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public bool IsPortOpen()
    {
        return Port.IsOpen;
    }
    public void ClosePort()
    {
        Port.Close();
    }
    public bool SendMessage(string msg)
    {
        if (!IsPortOpen())
            return false;
        Port.Write(msg);
        return true;
    }

    void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        char a = (char)((SerialPort)sender).ReadByte();
        buffer += a;
    }

    public bool Avalilable()
    {
        return (buffer == "") ? false : true;
    }

    public void ClearBuffer()
    {
        buffer = "";
    }
}
class HelpList
{
    public int MaxMsgs = 100;
    ListBox listbox;
    public HelpList(ListBox _listbox)
    {
        listbox = _listbox;
    }
    public void AddMsg(object text)
    {
        if (listbox.Items.Count > MaxMsgs - 1)
        {
            for (int i = 0; i < MaxMsgs - 1; i++)
            {
                listbox.Items[i] = listbox.Items[i + 1];
            }
            listbox.Items[MaxMsgs - 1] = text;
        }
        else listbox.Items.Add(text);
    }
    public void ClearList()
    {
        listbox.Items.Clear();
    }
}