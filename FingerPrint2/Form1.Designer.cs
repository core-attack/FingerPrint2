namespace FingerPrint2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перемещениеИзображенияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.разметкаИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построениеГрафикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьНесколькоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxfilename = new System.Windows.Forms.ToolStripTextBox();
            this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.выйтиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уменьшитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центрироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.растянутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.повернутьПоЧасовойСтрелкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повернутьПротивЧасовойСтрелкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.изменитьШагМасштабированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxMasshtab = new System.Windows.Forms.ToolStripTextBox();
            this.режимРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перемещениеИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проставлениеТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построенияГрафикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьСеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьМелкуюСеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.загрузитьДанныеИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxName = new System.Windows.Forms.ToolStripTextBox();
            this.сохранитьИмяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьГрафикиToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.показатьГрафикиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxHand = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxFingers = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxColorPoints = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxColorLines = new System.Windows.Forms.ToolStripComboBox();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRegime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWhatToDo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelWho = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelKolPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelError = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLenght = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonForeign = new System.Windows.Forms.RadioButton();
            this.radioButtonCh = new System.Windows.Forms.RadioButton();
            this.radioButtonF = new System.Windows.Forms.RadioButton();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.textBoxKolLines = new System.Windows.Forms.TextBox();
            this.contextMenuStripTextBoxKolLines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonGrp = new System.Windows.Forms.RadioButton();
            this.radioButtonPnt = new System.Windows.Forms.RadioButton();
            this.radioButtonImg = new System.Windows.Forms.RadioButton();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.checkBoxHelpBuild = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStripMasshtab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabelCopyright = new System.Windows.Forms.LinkLabel();
            this.разработчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.piskarewnikolayramblerruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vkcompiskarewnikolayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStripTextBoxKolLines.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИзображениеToolStripMenuItem,
            this.сохранитьИзображенияToolStripMenuItem,
            this.toolStripMenuItem7,
            this.режимToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 92);
            // 
            // открытьИзображениеToolStripMenuItem
            // 
            this.открытьИзображениеToolStripMenuItem.Name = "открытьИзображениеToolStripMenuItem";
            this.открытьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.открытьИзображениеToolStripMenuItem.Text = "Открыть изображение";
            this.открытьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.открытьИзображениеToolStripMenuItem_Click);
            // 
            // сохранитьИзображенияToolStripMenuItem
            // 
            this.сохранитьИзображенияToolStripMenuItem.Name = "сохранитьИзображенияToolStripMenuItem";
            this.сохранитьИзображенияToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.сохранитьИзображенияToolStripMenuItem.Text = "Сохранить изображение";
            this.сохранитьИзображенияToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem7.Text = "Сохранить текущий палец";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перемещениеИзображенияToolStripMenuItem1,
            this.разметкаИзображенияToolStripMenuItem,
            this.построениеГрафикаToolStripMenuItem});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.режимToolStripMenuItem.Text = "Режим";
            // 
            // перемещениеИзображенияToolStripMenuItem1
            // 
            this.перемещениеИзображенияToolStripMenuItem1.Name = "перемещениеИзображенияToolStripMenuItem1";
            this.перемещениеИзображенияToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.перемещениеИзображенияToolStripMenuItem1.Text = "Перемещение изображения";
            this.перемещениеИзображенияToolStripMenuItem1.Click += new System.EventHandler(this.перемещениеИзображенияToolStripMenuItem1_Click);
            // 
            // разметкаИзображенияToolStripMenuItem
            // 
            this.разметкаИзображенияToolStripMenuItem.Name = "разметкаИзображенияToolStripMenuItem";
            this.разметкаИзображенияToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.разметкаИзображенияToolStripMenuItem.Text = "Разметка изображения";
            this.разметкаИзображенияToolStripMenuItem.Click += new System.EventHandler(this.разметкаИзображенияToolStripMenuItem_Click);
            // 
            // построениеГрафикаToolStripMenuItem
            // 
            this.построениеГрафикаToolStripMenuItem.Name = "построениеГрафикаToolStripMenuItem";
            this.построениеГрафикаToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.построениеГрафикаToolStripMenuItem.Text = "Построение графика";
            this.построениеГрафикаToolStripMenuItem.Click += new System.EventHandler(this.построениеГрафикаToolStripMenuItem_Click_1);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 593);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оттиск";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.zedGraphControl1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 568);
            this.panel1.TabIndex = 7;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 14);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(881, 544);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.Visible = false;
            this.zedGraphControl1.VisibleChanged += new System.EventHandler(this.zedGraphControl1_VisibleChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 562);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изображениеToolStripMenuItem,
            this.режимРаботыToolStripMenuItem,
            this.toolStripComboBoxType,
            this.toolStripComboBoxHand,
            this.toolStripComboBoxFingers,
            this.toolStripComboBoxColorPoints,
            this.toolStripComboBoxColorLines,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1112, 27);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem2,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.закрытьToolStripMenuItem,
            this.выйтиToolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьНесколькоToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // открытьНесколькоToolStripMenuItem
            // 
            this.открытьНесколькоToolStripMenuItem.Name = "открытьНесколькоToolStripMenuItem";
            this.открытьНесколькоToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.открытьНесколькоToolStripMenuItem.Text = "Открыть несколько ";
            this.открытьНесколькоToolStripMenuItem.Click += new System.EventHandler(this.открытьСразуНесклькоИзображенийToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxfilename,
            this.сохранитьToolStripMenuItem1});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem6.Text = "Сохранить в .txt как..";
            // 
            // toolStripTextBoxfilename
            // 
            this.toolStripTextBoxfilename.Name = "toolStripTextBoxfilename";
            this.toolStripTextBoxfilename.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxfilename.Text = "noname";
            this.toolStripTextBoxfilename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // сохранитьToolStripMenuItem1
            // 
            this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.сохранитьToolStripMenuItem1.Text = "Сохранить";
            this.сохранитьToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem2.Text = "Распечатать";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(184, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem4.Text = "Закрыть";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(184, 6);
            // 
            // выйтиToolStripMenuItem1
            // 
            this.выйтиToolStripMenuItem1.Name = "выйтиToolStripMenuItem1";
            this.выйтиToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.выйтиToolStripMenuItem1.Text = "Выйти";
            this.выйтиToolStripMenuItem1.Click += new System.EventHandler(this.выйтиToolStripMenuItem1_Click);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.увеличитьToolStripMenuItem,
            this.уменьшитьToolStripMenuItem,
            this.центрироватьToolStripMenuItem,
            this.растянутьToolStripMenuItem,
            this.оригиналToolStripMenuItem,
            this.toolStripMenuItem1,
            this.повернутьПоЧасовойСтрелкеToolStripMenuItem,
            this.повернутьПротивЧасовойСтрелкиToolStripMenuItem,
            this.toolStripMenuItem3,
            this.изменитьШагМасштабированияToolStripMenuItem});
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(95, 23);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            // 
            // увеличитьToolStripMenuItem
            // 
            this.увеличитьToolStripMenuItem.Name = "увеличитьToolStripMenuItem";
            this.увеличитьToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.увеличитьToolStripMenuItem.Text = "Увеличить";
            this.увеличитьToolStripMenuItem.Click += new System.EventHandler(this.увеличитьToolStripMenuItem_Click);
            // 
            // уменьшитьToolStripMenuItem
            // 
            this.уменьшитьToolStripMenuItem.Name = "уменьшитьToolStripMenuItem";
            this.уменьшитьToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.уменьшитьToolStripMenuItem.Text = "Уменьшить";
            this.уменьшитьToolStripMenuItem.Click += new System.EventHandler(this.уменьшитьToolStripMenuItem_Click);
            // 
            // центрироватьToolStripMenuItem
            // 
            this.центрироватьToolStripMenuItem.Name = "центрироватьToolStripMenuItem";
            this.центрироватьToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.центрироватьToolStripMenuItem.Text = "Центрировать";
            this.центрироватьToolStripMenuItem.Click += new System.EventHandler(this.центрироватьToolStripMenuItem_Click);
            // 
            // растянутьToolStripMenuItem
            // 
            this.растянутьToolStripMenuItem.Name = "растянутьToolStripMenuItem";
            this.растянутьToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.растянутьToolStripMenuItem.Text = "Растянуть";
            this.растянутьToolStripMenuItem.Click += new System.EventHandler(this.растянутьToolStripMenuItem_Click);
            // 
            // оригиналToolStripMenuItem
            // 
            this.оригиналToolStripMenuItem.Name = "оригиналToolStripMenuItem";
            this.оригиналToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.оригиналToolStripMenuItem.Text = "Оригинал";
            this.оригиналToolStripMenuItem.Click += new System.EventHandler(this.оригиналToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(268, 6);
            // 
            // повернутьПоЧасовойСтрелкеToolStripMenuItem
            // 
            this.повернутьПоЧасовойСтрелкеToolStripMenuItem.Name = "повернутьПоЧасовойСтрелкеToolStripMenuItem";
            this.повернутьПоЧасовойСтрелкеToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.повернутьПоЧасовойСтрелкеToolStripMenuItem.Text = "Повернуть по часовой стрелке";
            // 
            // повернутьПротивЧасовойСтрелкиToolStripMenuItem
            // 
            this.повернутьПротивЧасовойСтрелкиToolStripMenuItem.Name = "повернутьПротивЧасовойСтрелкиToolStripMenuItem";
            this.повернутьПротивЧасовойСтрелкиToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.повернутьПротивЧасовойСтрелкиToolStripMenuItem.Text = "Повернуть против часовой стрелки";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(268, 6);
            // 
            // изменитьШагМасштабированияToolStripMenuItem
            // 
            this.изменитьШагМасштабированияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxMasshtab});
            this.изменитьШагМасштабированияToolStripMenuItem.Name = "изменитьШагМасштабированияToolStripMenuItem";
            this.изменитьШагМасштабированияToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.изменитьШагМасштабированияToolStripMenuItem.Text = "Изменить шаг масштабирования";
            // 
            // toolStripTextBoxMasshtab
            // 
            this.toolStripTextBoxMasshtab.Name = "toolStripTextBoxMasshtab";
            this.toolStripTextBoxMasshtab.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxMasshtab.Text = "250";
            this.toolStripTextBoxMasshtab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.toolStripTextBoxMasshtab.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxMasshtab_KeyUp);
            // 
            // режимРаботыToolStripMenuItem
            // 
            this.режимРаботыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перемещениеИзображенияToolStripMenuItem,
            this.проставлениеТочекToolStripMenuItem,
            this.построенияГрафикаToolStripMenuItem,
            this.toolStripMenuItem8,
            this.загрузитьДанныеИзФайлаToolStripMenuItem});
            this.режимРаботыToolStripMenuItem.Name = "режимРаботыToolStripMenuItem";
            this.режимРаботыToolStripMenuItem.Size = new System.Drawing.Size(101, 23);
            this.режимРаботыToolStripMenuItem.Text = "Режим работы";
            // 
            // перемещениеИзображенияToolStripMenuItem
            // 
            this.перемещениеИзображенияToolStripMenuItem.Name = "перемещениеИзображенияToolStripMenuItem";
            this.перемещениеИзображенияToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.перемещениеИзображенияToolStripMenuItem.Text = "Перемещение изображения";
            this.перемещениеИзображенияToolStripMenuItem.Click += new System.EventHandler(this.перемещениеИзображенияToolStripMenuItem_Click);
            // 
            // проставлениеТочекToolStripMenuItem
            // 
            this.проставлениеТочекToolStripMenuItem.Name = "проставлениеТочекToolStripMenuItem";
            this.проставлениеТочекToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.проставлениеТочекToolStripMenuItem.Text = "Проставление точек";
            this.проставлениеТочекToolStripMenuItem.Click += new System.EventHandler(this.проставлениеТочекToolStripMenuItem_Click);
            // 
            // построенияГрафикаToolStripMenuItem
            // 
            this.построенияГрафикаToolStripMenuItem.AutoSize = false;
            this.построенияГрафикаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьСеткуToolStripMenuItem,
            this.показатьМелкуюСеткуToolStripMenuItem});
            this.построенияГрафикаToolStripMenuItem.Name = "построенияГрафикаToolStripMenuItem";
            this.построенияГрафикаToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.построенияГрафикаToolStripMenuItem.Text = "Построение графика";
            this.построенияГрафикаToolStripMenuItem.Click += new System.EventHandler(this.построениеГрафикаToolStripMenuItem_Click);
            // 
            // показатьСеткуToolStripMenuItem
            // 
            this.показатьСеткуToolStripMenuItem.Name = "показатьСеткуToolStripMenuItem";
            this.показатьСеткуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.показатьСеткуToolStripMenuItem.Text = "Показать крупную сетку";
            this.показатьСеткуToolStripMenuItem.Click += new System.EventHandler(this.показатьСеткуToolStripMenuItem_Click);
            // 
            // показатьМелкуюСеткуToolStripMenuItem
            // 
            this.показатьМелкуюСеткуToolStripMenuItem.Name = "показатьМелкуюСеткуToolStripMenuItem";
            this.показатьМелкуюСеткуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.показатьМелкуюСеткуToolStripMenuItem.Text = "Показать мелкую сетку";
            this.показатьМелкуюСеткуToolStripMenuItem.Click += new System.EventHandler(this.мелкуюСеткуToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(228, 6);
            // 
            // загрузитьДанныеИзФайлаToolStripMenuItem
            // 
            this.загрузитьДанныеИзФайлаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxName,
            this.сохранитьИмяToolStripMenuItem,
            this.toolStripMenuItem9,
            this.показатьГрафикиToolStripMenuItem,
            this.показатьГрафикиToolStripMenuItem1});
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Name = "загрузитьДанныеИзФайлаToolStripMenuItem";
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.загрузитьДанныеИзФайлаToolStripMenuItem.Text = "Загрузить данные из файла";
            // 
            // toolStripTextBoxName
            // 
            this.toolStripTextBoxName.Name = "toolStripTextBoxName";
            this.toolStripTextBoxName.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxName.Text = "Введите фамилию";
            this.toolStripTextBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxName_KeyDown);
            this.toolStripTextBoxName.Click += new System.EventHandler(this.toolStripTextBoxName_Click);
            // 
            // сохранитьИмяToolStripMenuItem
            // 
            this.сохранитьИмяToolStripMenuItem.Name = "сохранитьИмяToolStripMenuItem";
            this.сохранитьИмяToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.сохранитьИмяToolStripMenuItem.Text = "Сохранить фамилию";
            this.сохранитьИмяToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИмяToolStripMenuItem_Click_1);
            // 
            // показатьГрафикиToolStripMenuItem
            // 
            this.показатьГрафикиToolStripMenuItem.Name = "показатьГрафикиToolStripMenuItem";
            this.показатьГрафикиToolStripMenuItem.Size = new System.Drawing.Size(195, 6);
            // 
            // показатьГрафикиToolStripMenuItem1
            // 
            this.показатьГрафикиToolStripMenuItem1.Name = "показатьГрафикиToolStripMenuItem1";
            this.показатьГрафикиToolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.показатьГрафикиToolStripMenuItem1.Text = "Показать графики";
            this.показатьГрафикиToolStripMenuItem1.Click += new System.EventHandler(this.показатьГрафикиToolStripMenuItem1_Click);
            // 
            // toolStripComboBoxType
            // 
            this.toolStripComboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxType.Name = "toolStripComboBoxType";
            this.toolStripComboBoxType.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxType.Text = "Тип узора";
            this.toolStripComboBoxType.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxType_SelectedIndexChanged);
            this.toolStripComboBoxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
            // 
            // toolStripComboBoxHand
            // 
            this.toolStripComboBoxHand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxHand.Name = "toolStripComboBoxHand";
            this.toolStripComboBoxHand.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxHand.Text = "Выберите руку";
            this.toolStripComboBoxHand.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxHand_SelectedIndexChanged);
            this.toolStripComboBoxHand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
            // 
            // toolStripComboBoxFingers
            // 
            this.toolStripComboBoxFingers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxFingers.Name = "toolStripComboBoxFingers";
            this.toolStripComboBoxFingers.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxFingers.Text = "Выберете палец";
            this.toolStripComboBoxFingers.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxFingers_SelectedIndexChanged);
            this.toolStripComboBoxFingers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
            // 
            // toolStripComboBoxColorPoints
            // 
            this.toolStripComboBoxColorPoints.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxColorPoints.Name = "toolStripComboBoxColorPoints";
            this.toolStripComboBoxColorPoints.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxColorPoints.Text = "Цвет точек";
            this.toolStripComboBoxColorPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
            // 
            // toolStripComboBoxColorLines
            // 
            this.toolStripComboBoxColorLines.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBoxColorLines.Name = "toolStripComboBoxColorLines";
            this.toolStripComboBoxColorLines.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBoxColorLines.Text = "Цвет линий";
            this.toolStripComboBoxColorLines.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxColorLines_SelectedIndexChanged);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.разработчикToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // buttonBuild
            // 
            this.buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBuild.Location = new System.Drawing.Point(1016, 34);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(87, 23);
            this.buttonBuild.TabIndex = 10;
            this.buttonBuild.Text = "Просчитать";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRegime,
            this.toolStripStatusLabelCoord,
            this.toolStripStatusLabelWhatToDo,
            this.toolStripStatusLabelWho,
            this.toolStripStatusLabelKolPoints,
            this.toolStripStatusLabelError,
            this.toolStripStatusLabelLenght});
            this.statusStrip1.Location = new System.Drawing.Point(0, 628);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1112, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRegime
            // 
            this.toolStripStatusLabelRegime.Name = "toolStripStatusLabelRegime";
            this.toolStripStatusLabelRegime.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelRegime.Text = "Режим";
            // 
            // toolStripStatusLabelCoord
            // 
            this.toolStripStatusLabelCoord.Name = "toolStripStatusLabelCoord";
            this.toolStripStatusLabelCoord.Size = new System.Drawing.Size(129, 17);
            this.toolStripStatusLabelCoord.Text = "| Координаты курсора";
            // 
            // toolStripStatusLabelWhatToDo
            // 
            this.toolStripStatusLabelWhatToDo.Name = "toolStripStatusLabelWhatToDo";
            this.toolStripStatusLabelWhatToDo.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabelWhatToDo.Text = "| Действие";
            // 
            // toolStripStatusLabelWho
            // 
            this.toolStripStatusLabelWho.Name = "toolStripStatusLabelWho";
            this.toolStripStatusLabelWho.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabelWho.Text = "| Чей палец";
            // 
            // toolStripStatusLabelKolPoints
            // 
            this.toolStripStatusLabelKolPoints.Name = "toolStripStatusLabelKolPoints";
            this.toolStripStatusLabelKolPoints.Size = new System.Drawing.Size(193, 17);
            this.toolStripStatusLabelKolPoints.Text = "| Количество поставленных точек";
            // 
            // toolStripStatusLabelError
            // 
            this.toolStripStatusLabelError.Name = "toolStripStatusLabelError";
            this.toolStripStatusLabelError.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabelError.Text = "| Ошибки";
            // 
            // toolStripStatusLabelLenght
            // 
            this.toolStripStatusLabelLenght.Name = "toolStripStatusLabelLenght";
            this.toolStripStatusLabelLenght.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabelLenght.Text = "| Длина линии";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonForeign);
            this.groupBox2.Controls.Add(this.radioButtonCh);
            this.groupBox2.Controls.Add(this.radioButtonF);
            this.groupBox2.Controls.Add(this.radioButtonM);
            this.groupBox2.Location = new System.Drawing.Point(928, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 112);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Чей оттиск";
            // 
            // radioButtonForeign
            // 
            this.radioButtonForeign.AutoSize = true;
            this.radioButtonForeign.Location = new System.Drawing.Point(10, 88);
            this.radioButtonForeign.Name = "radioButtonForeign";
            this.radioButtonForeign.Size = new System.Drawing.Size(58, 17);
            this.radioButtonForeign.TabIndex = 3;
            this.radioButtonForeign.TabStop = true;
            this.radioButtonForeign.Text = "Чужой";
            this.radioButtonForeign.UseVisualStyleBackColor = true;
            this.radioButtonForeign.CheckedChanged += new System.EventHandler(this.radioButtonMens_CheckedChanged);
            // 
            // radioButtonCh
            // 
            this.radioButtonCh.AutoSize = true;
            this.radioButtonCh.Location = new System.Drawing.Point(10, 65);
            this.radioButtonCh.Name = "radioButtonCh";
            this.radioButtonCh.Size = new System.Drawing.Size(68, 17);
            this.radioButtonCh.TabIndex = 2;
            this.radioButtonCh.TabStop = true;
            this.radioButtonCh.Text = "Ребёнок";
            this.radioButtonCh.UseVisualStyleBackColor = true;
            this.radioButtonCh.CheckedChanged += new System.EventHandler(this.radioButtonMens_CheckedChanged);
            // 
            // radioButtonF
            // 
            this.radioButtonF.AutoSize = true;
            this.radioButtonF.Location = new System.Drawing.Point(10, 42);
            this.radioButtonF.Name = "radioButtonF";
            this.radioButtonF.Size = new System.Drawing.Size(50, 17);
            this.radioButtonF.TabIndex = 1;
            this.radioButtonF.TabStop = true;
            this.radioButtonF.Text = "Отец";
            this.radioButtonF.UseVisualStyleBackColor = true;
            this.radioButtonF.CheckedChanged += new System.EventHandler(this.radioButtonMens_CheckedChanged);
            // 
            // radioButtonM
            // 
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.Location = new System.Drawing.Point(10, 19);
            this.radioButtonM.Name = "radioButtonM";
            this.radioButtonM.Size = new System.Drawing.Size(51, 17);
            this.radioButtonM.TabIndex = 0;
            this.radioButtonM.TabStop = true;
            this.radioButtonM.Text = "Мать";
            this.radioButtonM.UseVisualStyleBackColor = true;
            this.radioButtonM.CheckedChanged += new System.EventHandler(this.radioButtonMens_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listBoxLog);
            this.groupBox3.Location = new System.Drawing.Point(928, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 151);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отчёт";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(6, 19);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(169, 121);
            this.listBoxLog.TabIndex = 0;
            // 
            // textBoxKolLines
            // 
            this.textBoxKolLines.ContextMenuStrip = this.contextMenuStripTextBoxKolLines;
            this.textBoxKolLines.Location = new System.Drawing.Point(6, 19);
            this.textBoxKolLines.Name = "textBoxKolLines";
            this.textBoxKolLines.ReadOnly = true;
            this.textBoxKolLines.Size = new System.Drawing.Size(46, 20);
            this.textBoxKolLines.TabIndex = 14;
            this.textBoxKolLines.ReadOnlyChanged += new System.EventHandler(this.textBoxKolLines_ReadOnlyChanged);
            this.textBoxKolLines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBoxKolLines.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxKolLines_KeyUp);
            // 
            // contextMenuStripTextBoxKolLines
            // 
            this.contextMenuStripTextBoxKolLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem});
            this.contextMenuStripTextBoxKolLines.Name = "contextMenuStripTextBoxKolLines";
            this.contextMenuStripTextBoxKolLines.Size = new System.Drawing.Size(129, 26);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxKolLines);
            this.groupBox4.Location = new System.Drawing.Point(928, 309);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 53);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дополнительные параметры";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "пересекаемых линий";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Количество";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.radioButtonGrp);
            this.groupBox5.Controls.Add(this.radioButtonPnt);
            this.groupBox5.Controls.Add(this.radioButtonImg);
            this.groupBox5.Location = new System.Drawing.Point(927, 391);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(181, 100);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Режим";
            // 
            // radioButtonGrp
            // 
            this.radioButtonGrp.AutoSize = true;
            this.radioButtonGrp.Location = new System.Drawing.Point(10, 65);
            this.radioButtonGrp.Name = "radioButtonGrp";
            this.radioButtonGrp.Size = new System.Drawing.Size(132, 17);
            this.radioButtonGrp.TabIndex = 5;
            this.radioButtonGrp.TabStop = true;
            this.radioButtonGrp.Text = "Построение графика";
            this.radioButtonGrp.UseVisualStyleBackColor = true;
            this.radioButtonGrp.CheckedChanged += new System.EventHandler(this.radioButtonRegimes_CheckedChanged);
            // 
            // radioButtonPnt
            // 
            this.radioButtonPnt.AutoSize = true;
            this.radioButtonPnt.Location = new System.Drawing.Point(10, 42);
            this.radioButtonPnt.Name = "radioButtonPnt";
            this.radioButtonPnt.Size = new System.Drawing.Size(146, 17);
            this.radioButtonPnt.TabIndex = 4;
            this.radioButtonPnt.TabStop = true;
            this.radioButtonPnt.Text = "Разметка изображения";
            this.radioButtonPnt.UseVisualStyleBackColor = true;
            this.radioButtonPnt.CheckedChanged += new System.EventHandler(this.radioButtonRegimes_CheckedChanged);
            // 
            // radioButtonImg
            // 
            this.radioButtonImg.AutoSize = true;
            this.radioButtonImg.Location = new System.Drawing.Point(10, 19);
            this.radioButtonImg.Name = "radioButtonImg";
            this.radioButtonImg.Size = new System.Drawing.Size(169, 17);
            this.radioButtonImg.TabIndex = 3;
            this.radioButtonImg.TabStop = true;
            this.radioButtonImg.Text = "Перемещение изображения";
            this.radioButtonImg.UseVisualStyleBackColor = true;
            this.radioButtonImg.CheckedChanged += new System.EventHandler(this.radioButtonRegimes_CheckedChanged);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandom.Location = new System.Drawing.Point(1016, 112);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(87, 34);
            this.buttonRandom.TabIndex = 17;
            this.buttonRandom.Text = "Корейский рандом";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLine.Location = new System.Drawing.Point(1016, 61);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(87, 45);
            this.buttonLine.TabIndex = 18;
            this.buttonLine.Text = "Соединить точки";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // checkBoxHelpBuild
            // 
            this.checkBoxHelpBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHelpBuild.AutoSize = true;
            this.checkBoxHelpBuild.Location = new System.Drawing.Point(927, 368);
            this.checkBoxHelpBuild.Name = "checkBoxHelpBuild";
            this.checkBoxHelpBuild.Size = new System.Drawing.Size(179, 17);
            this.checkBoxHelpBuild.TabIndex = 17;
            this.checkBoxHelpBuild.Text = "Вспомогательное построение";
            this.checkBoxHelpBuild.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(925, 497);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(181, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // contextMenuStripMasshtab
            // 
            this.contextMenuStripMasshtab.Name = "contextMenuStripMasshtab";
            this.contextMenuStripMasshtab.Size = new System.Drawing.Size(61, 4);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(930, 536);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(170, 85);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem9.Text = "Показать сохраненное";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // linkLabelCopyright
            // 
            this.linkLabelCopyright.AutoSize = true;
            this.linkLabelCopyright.Location = new System.Drawing.Point(1036, 9);
            this.linkLabelCopyright.Name = "linkLabelCopyright";
            this.linkLabelCopyright.Size = new System.Drawing.Size(72, 13);
            this.linkLabelCopyright.TabIndex = 21;
            this.linkLabelCopyright.TabStop = true;
            this.linkLabelCopyright.Text = "Разработчик";
            // 
            // разработчикToolStripMenuItem
            // 
            this.разработчикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.piskarewnikolayramblerruToolStripMenuItem,
            this.vkcompiskarewnikolayToolStripMenuItem,
            this.iCQToolStripMenuItem});
            this.разработчикToolStripMenuItem.Name = "разработчикToolStripMenuItem";
            this.разработчикToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.разработчикToolStripMenuItem.Text = "Разработчик";
            // 
            // piskarewnikolayramblerruToolStripMenuItem
            // 
            this.piskarewnikolayramblerruToolStripMenuItem.Name = "piskarewnikolayramblerruToolStripMenuItem";
            this.piskarewnikolayramblerruToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.piskarewnikolayramblerruToolStripMenuItem.Text = "piskarew_nikolay@rambler.ru";
            this.piskarewnikolayramblerruToolStripMenuItem.Click += new System.EventHandler(this.piskarewnikolayramblerruToolStripMenuItem_Click);
            // 
            // vkcompiskarewnikolayToolStripMenuItem
            // 
            this.vkcompiskarewnikolayToolStripMenuItem.Name = "vkcompiskarewnikolayToolStripMenuItem";
            this.vkcompiskarewnikolayToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.vkcompiskarewnikolayToolStripMenuItem.Text = "vk.com/piskarew_nikolay";
            this.vkcompiskarewnikolayToolStripMenuItem.Click += new System.EventHandler(this.vkcompiskarewnikolayToolStripMenuItem_Click);
            // 
            // iCQToolStripMenuItem
            // 
            this.iCQToolStripMenuItem.Name = "iCQToolStripMenuItem";
            this.iCQToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.iCQToolStripMenuItem.Text = "ICQ: 390247362";
            this.iCQToolStripMenuItem.Click += new System.EventHandler(this.iCQToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem10.Text = "Как строить композиции";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 650);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.linkLabelCopyright);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBoxHelpBuild);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.groupBox4);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerPrint 2.0 ";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStripTextBoxKolLines.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem открытьИзображениеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem увеличитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уменьшитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центрироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem растянутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оригиналToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem повернутьПоЧасовойСтрелкеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повернутьПротивЧасовойСтрелкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перемещениеИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проставлениеТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem построенияГрафикаToolStripMenuItem;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRegime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWhatToDo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWho;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonCh;
        private System.Windows.Forms.RadioButton radioButtonF;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TextBox textBoxKolLines;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTextBoxKolLines;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelKolPoints;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonGrp;
        private System.Windows.Forms.RadioButton radioButtonPnt;
        private System.Windows.Forms.RadioButton radioButtonImg;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFingers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelError;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem показатьСеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьМелкуюСеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображенияToolStripMenuItem;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxColorPoints;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxColorLines;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLenght;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перемещениеИзображенияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem разметкаИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построениеГрафикаToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonForeign;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxHelpBuild;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem открытьНесколькоToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem изменитьШагМасштабированияToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMasshtab;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMasshtab;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxHand;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxfilename;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxName;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИмяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator показатьГрафикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьГрафикиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.LinkLabel linkLabelCopyright;
        private System.Windows.Forms.ToolStripMenuItem разработчикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem piskarewnikolayramblerruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vkcompiskarewnikolayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    }
}

