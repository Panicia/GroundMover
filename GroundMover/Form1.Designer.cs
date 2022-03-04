namespace GroundMover
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.speedTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.figureComboB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sizeXTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeYTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.coordYTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.coordXTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.radTB = new System.Windows.Forms.TextBox();
            this.COMportsCB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.COMbutton = new System.Windows.Forms.Button();
            this.repeatNumberTB = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.alterLayerChB = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.pauseLayersTB = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.goZeroZhB = new System.Windows.Forms.CheckBox();
            this.goZero2ChB = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gcodeLabel = new System.Windows.Forms.Label();
            this.gcodelabel2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.DispEnChB = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.delayRasTB = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.DisperTimeTB = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.DisperIntervalTB = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.DisperOnBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonCompressor = new System.Windows.Forms.Button();
            this.buttonAerograph = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Скорость перемещения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 631);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Build GCODE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(399, 438);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(189, 186);
            this.listBox1.TabIndex = 4;
            // 
            // speedTB
            // 
            this.speedTB.Location = new System.Drawing.Point(414, 36);
            this.speedTB.Name = "speedTB";
            this.speedTB.Size = new System.Drawing.Size(78, 20);
            this.speedTB.TabIndex = 5;
            this.speedTB.TextChanged += new System.EventHandler(this.SpeedTB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "мм/мин";
            // 
            // figureComboB
            // 
            this.figureComboB.FormattingEnabled = true;
            this.figureComboB.Items.AddRange(new object[] {
            "Линейное",
            "Диагональное",
            "Концентрическое"});
            this.figureComboB.Location = new System.Drawing.Point(414, 88);
            this.figureComboB.Name = "figureComboB";
            this.figureComboB.Size = new System.Drawing.Size(121, 21);
            this.figureComboB.TabIndex = 7;
            this.figureComboB.SelectedIndexChanged += new System.EventHandler(this.FigureComboB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Тип заполнения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "мм";
            // 
            // sizeXTB
            // 
            this.sizeXTB.Location = new System.Drawing.Point(414, 263);
            this.sizeXTB.Name = "sizeXTB";
            this.sizeXTB.Size = new System.Drawing.Size(78, 20);
            this.sizeXTB.TabIndex = 10;
            this.sizeXTB.TextChanged += new System.EventHandler(this.SizeXTB_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Размеры";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "мм";
            // 
            // sizeYTB
            // 
            this.sizeYTB.Location = new System.Drawing.Point(414, 289);
            this.sizeYTB.Name = "sizeYTB";
            this.sizeYTB.Size = new System.Drawing.Size(78, 20);
            this.sizeYTB.TabIndex = 12;
            this.sizeYTB.TextChanged += new System.EventHandler(this.SizeYTB_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(663, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "мм";
            // 
            // coordYTB
            // 
            this.coordYTB.Location = new System.Drawing.Point(579, 289);
            this.coordYTB.Name = "coordYTB";
            this.coordYTB.Size = new System.Drawing.Size(78, 20);
            this.coordYTB.TabIndex = 17;
            this.coordYTB.TextChanged += new System.EventHandler(this.CoordYTB_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(663, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "мм";
            // 
            // coordXTB
            // 
            this.coordXTB.Location = new System.Drawing.Point(579, 263);
            this.coordXTB.Name = "coordXTB";
            this.coordXTB.Size = new System.Drawing.Size(78, 20);
            this.coordXTB.TabIndex = 15;
            this.coordXTB.TextChanged += new System.EventHandler(this.CoordXTB_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(559, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Расстояние от начала";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(576, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Количество проходов";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(394, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(394, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(559, 292);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(559, 266);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "X";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(576, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Радиус пучка";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(663, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "мм";
            // 
            // radTB
            // 
            this.radTB.Location = new System.Drawing.Point(579, 36);
            this.radTB.Name = "radTB";
            this.radTB.Size = new System.Drawing.Size(78, 20);
            this.radTB.TabIndex = 26;
            this.radTB.TextChanged += new System.EventHandler(this.RadTB_TextChanged);
            // 
            // COMportsCB
            // 
            this.COMportsCB.FormattingEnabled = true;
            this.COMportsCB.Location = new System.Drawing.Point(89, 42);
            this.COMportsCB.Name = "COMportsCB";
            this.COMportsCB.Size = new System.Drawing.Size(121, 21);
            this.COMportsCB.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "COM порт";
            // 
            // COMbutton
            // 
            this.COMbutton.Location = new System.Drawing.Point(233, 29);
            this.COMbutton.Name = "COMbutton";
            this.COMbutton.Size = new System.Drawing.Size(81, 38);
            this.COMbutton.TabIndex = 30;
            this.COMbutton.Text = "Подключить";
            this.COMbutton.UseVisualStyleBackColor = true;
            this.COMbutton.Click += new System.EventHandler(this.COMbutton_Click);
            // 
            // repeatNumberTB
            // 
            this.repeatNumberTB.Location = new System.Drawing.Point(579, 88);
            this.repeatNumberTB.Name = "repeatNumberTB";
            this.repeatNumberTB.Size = new System.Drawing.Size(78, 20);
            this.repeatNumberTB.TabIndex = 31;
            this.repeatNumberTB.TextChanged += new System.EventHandler(this.RepeatNumberTB_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(663, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "раз";
            // 
            // alterLayerChB
            // 
            this.alterLayerChB.AutoSize = true;
            this.alterLayerChB.Location = new System.Drawing.Point(410, 121);
            this.alterLayerChB.Name = "alterLayerChB";
            this.alterLayerChB.Size = new System.Drawing.Size(114, 17);
            this.alterLayerChB.TabIndex = 33;
            this.alterLayerChB.Text = "Чередовать слои";
            this.alterLayerChB.UseVisualStyleBackColor = true;
            this.alterLayerChB.CheckedChanged += new System.EventHandler(this.AlterLayerChB_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(611, 593);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 31);
            this.button3.TabIndex = 35;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(611, 486);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 42);
            this.button4.TabIndex = 36;
            this.button4.Text = "Send GCODE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(663, 137);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "мс";
            // 
            // pauseLayersTB
            // 
            this.pauseLayersTB.Location = new System.Drawing.Point(579, 134);
            this.pauseLayersTB.Name = "pauseLayersTB";
            this.pauseLayersTB.Size = new System.Drawing.Size(78, 20);
            this.pauseLayersTB.TabIndex = 38;
            this.pauseLayersTB.TextChanged += new System.EventHandler(this.PauseLayersTB_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(576, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(115, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Пауза между слоями";
            // 
            // goZeroZhB
            // 
            this.goZeroZhB.AutoSize = true;
            this.goZeroZhB.Location = new System.Drawing.Point(410, 153);
            this.goZeroZhB.Name = "goZeroZhB";
            this.goZeroZhB.Size = new System.Drawing.Size(111, 30);
            this.goZeroZhB.TabIndex = 40;
            this.goZeroZhB.Text = "Первоначальная\r\nотправка в ноль";
            this.goZeroZhB.UseVisualStyleBackColor = true;
            this.goZeroZhB.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // goZero2ChB
            // 
            this.goZero2ChB.AutoSize = true;
            this.goZero2ChB.Location = new System.Drawing.Point(410, 189);
            this.goZero2ChB.Name = "goZero2ChB";
            this.goZero2ChB.Size = new System.Drawing.Size(109, 30);
            this.goZero2ChB.TabIndex = 41;
            this.goZero2ChB.Text = "Конечная\r\nотправка в ноль";
            this.goZero2ChB.UseVisualStyleBackColor = true;
            this.goZero2ChB.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(39, 503);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(319, 25);
            this.progressBar1.TabIndex = 42;
            // 
            // gcodeLabel
            // 
            this.gcodeLabel.AutoSize = true;
            this.gcodeLabel.Location = new System.Drawing.Point(36, 543);
            this.gcodeLabel.Name = "gcodeLabel";
            this.gcodeLabel.Size = new System.Drawing.Size(75, 13);
            this.gcodeLabel.TabIndex = 43;
            this.gcodeLabel.Text = "Выполняется";
            // 
            // gcodelabel2
            // 
            this.gcodelabel2.AutoSize = true;
            this.gcodelabel2.Location = new System.Drawing.Point(117, 543);
            this.gcodelabel2.Name = "gcodelabel2";
            this.gcodelabel2.Size = new System.Drawing.Size(13, 13);
            this.gcodelabel2.TabIndex = 44;
            this.gcodelabel2.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(400, 324);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 45;
            this.label21.Text = "Диспергатор";
            // 
            // DispEnChB
            // 
            this.DispEnChB.AutoSize = true;
            this.DispEnChB.Location = new System.Drawing.Point(399, 387);
            this.DispEnChB.Name = "DispEnChB";
            this.DispEnChB.Size = new System.Drawing.Size(155, 17);
            this.DispEnChB.TabIndex = 46;
            this.DispEnChB.Text = "Включать автоматически";
            this.DispEnChB.UseVisualStyleBackColor = true;
            this.DispEnChB.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged_2);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(663, 206);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "мс";
            // 
            // delayRasTB
            // 
            this.delayRasTB.Location = new System.Drawing.Point(579, 203);
            this.delayRasTB.Name = "delayRasTB";
            this.delayRasTB.Size = new System.Drawing.Size(78, 20);
            this.delayRasTB.TabIndex = 48;
            this.delayRasTB.TextChanged += new System.EventHandler(this.DelayRasTB_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(576, 174);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 26);
            this.label23.TabIndex = 47;
            this.label23.Text = "Задержка при включении \r\nраспылителя";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(487, 364);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 13);
            this.label24.TabIndex = 52;
            this.label24.Text = "мс";
            // 
            // DisperTimeTB
            // 
            this.DisperTimeTB.Location = new System.Drawing.Point(403, 361);
            this.DisperTimeTB.Name = "DisperTimeTB";
            this.DisperTimeTB.Size = new System.Drawing.Size(78, 20);
            this.DisperTimeTB.TabIndex = 51;
            this.DisperTimeTB.TextChanged += new System.EventHandler(this.DisperTimeTB_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(400, 345);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 13);
            this.label25.TabIndex = 50;
            this.label25.Text = "Время работы";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(608, 364);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(21, 13);
            this.label26.TabIndex = 55;
            this.label26.Text = "мс";
            // 
            // DisperIntervalTB
            // 
            this.DisperIntervalTB.Location = new System.Drawing.Point(524, 361);
            this.DisperIntervalTB.Name = "DisperIntervalTB";
            this.DisperIntervalTB.Size = new System.Drawing.Size(78, 20);
            this.DisperIntervalTB.TabIndex = 54;
            this.DisperIntervalTB.TextChanged += new System.EventHandler(this.DisperIntervalTB_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(521, 345);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 13);
            this.label27.TabIndex = 53;
            this.label27.Text = "Интервал";
            // 
            // DisperOnBtn
            // 
            this.DisperOnBtn.Location = new System.Drawing.Point(647, 349);
            this.DisperOnBtn.Name = "DisperOnBtn";
            this.DisperOnBtn.Size = new System.Drawing.Size(81, 42);
            this.DisperOnBtn.TabIndex = 56;
            this.DisperOnBtn.Text = "Включить диспергатор";
            this.DisperOnBtn.UseVisualStyleBackColor = true;
            this.DisperOnBtn.Click += new System.EventHandler(this.DisperOnBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(611, 534);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(81, 42);
            this.StopBtn.TabIndex = 57;
            this.StopBtn.Text = "Остановить";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(741, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 13);
            this.label28.TabIndex = 58;
            this.label28.Text = "Компрессор";
            // 
            // buttonCompressor
            // 
            this.buttonCompressor.Location = new System.Drawing.Point(744, 39);
            this.buttonCompressor.Name = "buttonCompressor";
            this.buttonCompressor.Size = new System.Drawing.Size(81, 42);
            this.buttonCompressor.TabIndex = 59;
            this.buttonCompressor.Text = "Включить компрессор";
            this.buttonCompressor.UseVisualStyleBackColor = true;
            this.buttonCompressor.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonAerograph
            // 
            this.buttonAerograph.Location = new System.Drawing.Point(744, 112);
            this.buttonAerograph.Name = "buttonAerograph";
            this.buttonAerograph.Size = new System.Drawing.Size(81, 42);
            this.buttonAerograph.TabIndex = 61;
            this.buttonAerograph.Text = "Поднять курок\r\n";
            this.buttonAerograph.UseVisualStyleBackColor = true;
            this.buttonAerograph.Click += new System.EventHandler(this.buttonAerograph_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(741, 93);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 13);
            this.label29.TabIndex = 60;
            this.label29.Text = "Аэрограф";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 674);
            this.Controls.Add(this.buttonAerograph);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.buttonCompressor);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.DisperOnBtn);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.DisperIntervalTB);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.DisperTimeTB);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.delayRasTB);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.DispEnChB);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.gcodelabel2);
            this.Controls.Add(this.gcodeLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.goZero2ChB);
            this.Controls.Add(this.goZeroZhB);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.pauseLayersTB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.alterLayerChB);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.repeatNumberTB);
            this.Controls.Add(this.COMbutton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.COMportsCB);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.radTB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.coordYTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.coordXTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sizeYTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sizeXTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.figureComboB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.speedTB);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Ground Dweller";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox speedTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox figureComboB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sizeXTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sizeYTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox coordYTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox coordXTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox radTB;
        private System.Windows.Forms.ComboBox COMportsCB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button COMbutton;
        private System.Windows.Forms.TextBox repeatNumberTB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox alterLayerChB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox pauseLayersTB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox goZeroZhB;
        private System.Windows.Forms.CheckBox goZero2ChB;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label gcodeLabel;
        private System.Windows.Forms.Label gcodelabel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox DispEnChB;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox delayRasTB;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox DisperTimeTB;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox DisperIntervalTB;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button DisperOnBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button buttonCompressor;
        private System.Windows.Forms.Button buttonAerograph;
        private System.Windows.Forms.Label label29;
    }
}

