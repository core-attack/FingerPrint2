using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; // для работы с текстовыми файлами
using System.Drawing.Printing;
using ZedGraph;

namespace FingerPrint2
{
    public partial class Form1 : Form
    {
        // есть ли изображение на поле
        bool notImg = true;
        //загрузка всех данных из файлов
        bool fastGraph = false;
        string filename = "";
        string defaultFormat = ".jpg";
        // для вывода изображения
        bool isFirstMiddleClick = true;
        // для уникальности сохранения временных файлов 
        int numFile = 0;
        // для определения режима работы
        bool SetPoints = false;
        // для координат начала отрезков
        int oldPointX = 0;
        int oldPointY = 0;

        int newPointX = 0;
        int newPointY = 0;

        static int[] kolAllPoint = {42, 0, 38};
        int currentType = 2;
        int kolclicks = 0;

        //List<int[]> allFixedPoints = new List<int[]>();

        string[] men = { "Мать", "Отец", "Ребёнок" };

        string filenameLog = Application.StartupPath + "/txt/log.txt";
        string filekolExp = Application.StartupPath + "/txt/numExp.txt";
        string defaultImg = Application.StartupPath + "/temp/nothing.jpg";
        List<string> listLog = new List<string>();
        List<string> avtosaveList = new List<string>();
        // для сохранения списков координат точек
        string previousMan = "";
        string currentMan = "";
        bool leftHand = true;

        //public Man Mother = new Man();
        //public Man Father = new Man();
        //public Man Child = new Man();

        public Man man = new Man();

        List<Point> list1l = new List<Point>();
        List<Point> list2l = new List<Point>();
        List<Point> list3l = new List<Point>();
        List<Point> list4l = new List<Point>();
        List<Point> list5l = new List<Point>();

        List<Point> list1r = new List<Point>();
        List<Point> list2r = new List<Point>();
        List<Point> list3r = new List<Point>();
        List<Point> list4r = new List<Point>();
        List<Point> list5r = new List<Point>();
        LineItem myCurve1;
        LineItem myCurve2;
        LineItem myCurve3;
        LineItem myCurve4;
        PointPairList listPP1 = new PointPairList();
        PointPairList listPP2 = new PointPairList();
        PointPairList listPP3 = new PointPairList();
        PointPairList listPP4 = new PointPairList();

        Point[] firstSecondPoints = new Point[2];

        string[] myColorsPoints = { "Чёрные точки", "Синие точки", "Красные точки", "Оранжевые точки", "Голубые точки", "Зелёные точки", "Жёлтые точки", "Пурпурные точки", "Шоколадные точки" };
        string[] myColorsLines = { "Чёрные линии", "Синие линии", "Красные линии", "Оранжевые линии", "Голубые линии", "Зелёные линии", "Жёлтые линии", "Пурпурные линии", "Шоколадные линии" };
        string[] myHands = { "левая", "правая"};
        string[] myFingers = { "большой", "указательный", "средний", "безымянный", "мизинец" };
        string[] regimes = { "Режим перемещения изображения |", "Режим разметки изображения |", "Режим построения графика |" };
        string[] types = { "Дуговые", "Завитковые", "Петлевые"};

        // для разнообразия цветов на графиках
        int numColor = 0; 

        // для открытия сразу нескольких изображений
        bool openAllImg = false;
        // для всех картинок загруженных в listView
        List<string> listAllImgs = new List<string>();

        // названия файлов
        string[] linkImg1 = new string[10];
        string[] linkImg2 = new string[10];
        string[] linkImg3 = new string[10];
        string[] linkImg4 = new string[10];

        //для коротких названий файлов
        List<string> listSmalllinkImg1 = new List<string>();
        List<string> listSmalllinkImg2 = new List<string>();
        List<string> listSmalllinkImg3 = new List<string>();
        List<string> listSmalllinkImg4 = new List<string>();
        // списки изображений
        ImageList imgList1 = new ImageList();
        ImageList imgList2 = new ImageList();
        ImageList imgList3 = new ImageList();
        ImageList imgList4 = new ImageList();
        
        //для trackbar'a
        int lastValue = 0;
        //для масштабирования проставления точек
        //int delta = 0;
        int kolScroll = 0;
        int minusInterval = -250;

        int defaultPictureBoxWidth = 0;
        int defaultPictureBoxHeight = 0;

        //для перемещения изображения
        int offsetX = 0;
        int offsetY = 0;
        bool MoveImage;

        // для загружаемых из файлов значений
        List<List<double>> listDowloads = new List<List<double>>();

        public Form1()
        {
            InitializeComponent();

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

            toolStripComboBoxType.Text = types[2];

            pictureBox1.Cursor = Cursors.SizeAll;
            toolStripStatusLabelRegime.Text = regimes[0];
            radioButtonImg.Checked = true;
            radioButtonM.Checked = true;
            toolStripStatusLabelKolPoints.Text = "| "+0.ToString();
            SetError("");
            listLog.Add("__________________________________________________________________________");
            listLog.Add(DateTime.Now.ToString());
            firstSecondPoints[0] = new Point(0, 0);
            firstSecondPoints[1] = new Point(0, 0);
            SetAlltoolStripComboBox();
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            trackBar1.Value = lastValue =10;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            defaultPictureBoxWidth = pictureBox1.Width;
            defaultPictureBoxHeight = pictureBox1.Height;
            //разворачиваем на весь экран так, чтобы была видна статусная строка
            this.Bounds = Screen.PrimaryScreen.WorkingArea;
        }

        void SetAlltoolStripComboBox()
        {
            for (int i = 0; i < myFingers.Length; i++)
                toolStripComboBoxFingers.Items.Add(myFingers[i]);
            for (int i = 0; i < myColorsPoints.Length; i++)
                toolStripComboBoxColorPoints.Items.Add(myColorsPoints[i]);
            for (int i = 0; i < myColorsLines.Length; i++)
                toolStripComboBoxColorLines.Items.Add(myColorsLines[i]);
            
            toolStripComboBoxHand.Items.Add(myHands[0]);
            toolStripComboBoxHand.Items.Add(myHands[1]);

            toolStripComboBoxType.Items.Add(types[0]);
            toolStripComboBoxType.Items.Add(types[1]);
            toolStripComboBoxType.Items.Add(types[2]);
        }

        Color switchColor(int n)
        {
            switch (n)
            {
                case 0: return Color.Black;
                case 1: return Color.DarkBlue;
                case 2: return Color.Red;
                case 3: return Color.Orange;
                case 4: return Color.Cyan;
                case 5: return Color.Green;
                case 6: return Color.Yellow;
                case 7: return Color.Magenta;
                case 8: return Color.Chocolate;
                default: return Color.DarkBlue; 
            }
        }

        Brush switchBrushColor(int n)
        {
            switch (n)
            {
                case 0: return Brushes.Black;
                case 1: return Brushes.DarkBlue;
                case 2: return Brushes.Red;
                case 3: return Brushes.Orange;
                case 4: return Brushes.Cyan;
                case 5: return Brushes.Green;
                case 6: return Brushes.Yellow;
                case 7: return Brushes.Magenta;
                case 8: return Brushes.Chocolate;
                default: return Brushes.Red;
            }
        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openAllImg = false;
            //MyOpen();
            kolclicks = 0;
            toolStripComboBoxHand.Text = myHands[0];
            OpenMoreImg();
        }

        void MyClear()
        {
            try
            {
                list1l.Clear();
                list2l.Clear();
                list3l.Clear();
                list4l.Clear();
                list5l.Clear();
                list1r.Clear();
                list2r.Clear();
                list3r.Clear();
                list4r.Clear();
                list5r.Clear();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла какая-то очень страшная ошибка. Скорей всего Вы поторопились закрыть проект. Вот текст ошибки: "+e.Message);
                return;
            }
        }

        void MyOpen()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            dialog.FileName = "image";
            dialog.DefaultExt = defaultFormat;
            filename = dialog.FileName;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgToPicturebox(dialog.FileName);
            }
            toolStripComboBoxFingers.Focus();
        }

        void imgToPicturebox(string filename)
        {
            Image image = Image.FromFile(filename);
            int width = image.Width;
            int height = image.Height;
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            pictureBox1.Image = new Bitmap(image, width, height);
            notImg = false;
        }

        void MySave()
        {
            filename = Application.StartupPath + "\\mySavedFiles\\" + numFile.ToString() + ".jpg";
            SaveFileDialog savedialog = saveFileDialog1;
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "bmp":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
                deleteAllAvtosaveFiles();
            }
        }

        string currentHand()
        {
            if (toolStripComboBoxHand.Text == myHands[0])
                return myHands[0];
            else if (toolStripComboBoxHand.Text == myHands[1])
                return myHands[1];
            return "";
        }

        void MyLine(Point p1, Point p2)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(switchColor(toolStripComboBoxColorLines.SelectedIndex), 3);
            g.DrawLine(p, p1, p2);
            pictureBox1.Invalidate();
        }

        private void распечататьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        //точка только что поставлена
        bool isPointNowSet = false;

        // пишет в лог о завершенных методах композиций
        void SetLog()
        {
            string s = "";
            int n = 0;
            if (leftHand)
                switch (toolStripComboBoxFingers.SelectedIndex)
                {
                    case 0: n = list1l.Count;
                        break;
                    case 1: n = list2l.Count;
                        break;
                    case 2: n = list3l.Count;
                        break;
                    case 3: n = list4l.Count;
                        break;
                    case 4: n = list5l.Count;
                        break;
                    default: { n = 0; SetError("Ошибка: не выбран анализируемый палец."); }
                        break;
                }
            else
                switch (toolStripComboBoxFingers.SelectedIndex)
                {
                    case 0: n = list1r.Count;
                        break;
                    case 1: n = list2r.Count;
                        break;
                    case 2: n = list3r.Count;
                        break;
                    case 3: n = list4r.Count;
                        break;
                    case 4: n = list5r.Count;
                        break;
                    default: { n = 0; SetError("Ошибка: не выбран анализируемый палец."); }
                        break;
                }
            switch (currentType)
            {
                case 0: { 
                
                }
                    break;
                case 1: { }
                    break;
                case 2: { 
                    if (n == 2 && textBoxKolLines.Text != "" /*&& !checkBoxHelpBuild.Checked*/)
                    {
                        s = "Композиция 1 зафиксирована";
                        avtosave();
                    }
                    else if (n == 6 && !checkBoxHelpBuild.Checked)
                    {
                        s = "Композиция 2 зафиксирована";
                        avtosave();
                    }
                    else if (n == 14 && !checkBoxHelpBuild.Checked)
                    {
                        s = "Композиция 3 зафиксирована";
                        avtosave();
                    }
                    else if (n == 28 && !checkBoxHelpBuild.Checked)
                    {
                        s = "Композиция 4 зафиксирована";
                        avtosave();
                    }
                    else if (n == kolAllPoint[currentType] && !checkBoxHelpBuild.Checked)
                    {
                        s = "Композиция 5 зафиксирована";
                        avtosave();
                    }
                    if (s != "")
                        listBoxLog.Items.Add(s);
                }
                    break;
            }
            
        }

        //автосохранение
        void avtosave()
        {
            //автосохранение
            filename = Application.StartupPath + "\\temp\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
            avtosaveList.Add(filename);
            pictureBox1.Image.Save(filename);
        }

        void deleteAllAvtosaveFiles()
        {
            for (int i = 0; i < avtosaveList.Count; i++ )
                if (System.IO.File.Exists(avtosaveList[i]))
                {
                    try
                    {
                        System.IO.File.Delete(avtosaveList[i]);
                    }
                    catch (System.IO.IOException e)
                    {
                        SetError(e.Message);
                        return;
                    }
                }
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (toolStripComboBoxFingers.SelectedIndex != -1)
            {
                if (SetPoints)
                {
                    Image image = pictureBox1.Image;
                    int x = Convert.ToInt32(e.X);
                    int y = Convert.ToInt32(e.Y);
                    //толщина точек
                    int dx = 10;
                    int dy = 10;
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    Brush b = switchBrushColor(toolStripComboBoxColorPoints.SelectedIndex);
                    //MessageBox.Show(x.ToString() + "; " + y.ToString());
                    if (e.Button == MouseButtons.Left)
                    {
                        if (textBoxKolLines.ReadOnly)
                        {
                            if (list1l.Count < kolAllPoint[currentType] && list2l.Count < kolAllPoint[currentType] && list3l.Count < kolAllPoint[currentType] &&
                                list4l.Count < kolAllPoint[currentType] && list5l.Count < kolAllPoint[currentType] ||
                                list1r.Count < kolAllPoint[currentType] && list2r.Count < kolAllPoint[currentType] && list3r.Count < kolAllPoint[currentType] &&
                                list4r.Count < kolAllPoint[currentType] && list5r.Count < kolAllPoint[currentType])
                            {
                                if (kolclicks <= kolAllPoint[currentType])
                                {
                                    g.FillEllipse(b, x - dx / 2, y - dy / 2, dx, dy);
                                    pictureBox1.Invalidate();
                                }
                                //проставленная точка
                                Point myPoint = new Point(x, y);
                                kolScroll = (trackBar1.Maximum - trackBar1.Value);
                                //SetMyPoint(image.Width - (defaultPictureBoxWidth - x) + minusInterval * kolScroll, image.Height - (defaultPictureBoxHeight - y) + minusInterval * kolScroll);
                                
                                SetMyPoint(x, y);
                                if (!checkBoxHelpBuild.Checked && kolclicks < kolAllPoint[currentType])
                                {
                                    kolclicks++;
                                    if (leftHand)
                                        switch (toolStripComboBoxFingers.SelectedIndex)
                                        {
                                            case 0: list1l.Add(myPoint);
                                                break;
                                            case 1: list2l.Add(myPoint);
                                                break;
                                            case 2: list3l.Add(myPoint);
                                                break;
                                            case 3: list4l.Add(myPoint);
                                                break;
                                            case 4: list5l.Add(myPoint);
                                                break;
                                            default: SetError("Ошибка: не выбран анализируемый палец.");
                                                break;
                                        }
                                    else
                                        switch (toolStripComboBoxFingers.SelectedIndex)
                                        {
                                            case 0: list1r.Add(myPoint);
                                                break;
                                            case 1: list2r.Add(myPoint);
                                                break;
                                            case 2: list3r.Add(myPoint);
                                                break;
                                            case 3: list4r.Add(myPoint);
                                                break;
                                            case 4: list5r.Add(myPoint);
                                                break;
                                            default: SetError("Ошибка: не выбран анализируемый палец.");
                                                break;
                                        }
                                }
                                switch (currentType)
                                {
                                    case 0:
                                        {
                                            if (list1l.Count == 2 || list2l.Count == 2 || list3l.Count == 2 || list4l.Count == 2 || list5l.Count == 2 ||
                                                list1r.Count == 2 || list2r.Count == 2 || list3r.Count == 2 || list4r.Count == 2 || list5r.Count == 2)
                                            {
                                                if (textBoxKolLines.Text == "")
                                                {
                                                    textBoxKolLines.ReadOnly = false;
                                                    textBoxKolLines.Focus();
                                                }
                                            }
                                        }
                                        break;
                                    case 1: { }
                                        break;
                                    case 2:
                                        { 
                                        if (list1l.Count == 2 || list2l.Count == 2 || list3l.Count == 2 || list4l.Count == 2 || list5l.Count == 2 ||
                                            list1r.Count == 2 || list2r.Count == 2 || list3r.Count == 2 || list4r.Count == 2 || list5r.Count == 2)
                                        {
                                            if (textBoxKolLines.Text == "")
                                            {
                                                textBoxKolLines.ReadOnly = false;
                                                textBoxKolLines.Focus();
                                            }
                                        }
                                    }
                                        break;
                                }
                                SetLog();
                                if (!isPointNowSet)
                                {
                                    isPointNowSet = true;
                                    oldPointX = x;
                                    oldPointY = y;
                                }
                                else
                                {
                                    isPointNowSet = false;
                                    newPointX = x;
                                    newPointY = y;
                                }
                                buttonLine.Focus();
                            }
                        }
                        else if (!textBoxKolLines.ReadOnly)
                        {
                            pictureBox1.Cursor = Cursors.No;
                            toolStripStatusLabelWhatToDo.Text = "| Введите количество пересекаемых линий";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите анализируемый палец!");
            }
            if (e.Button == MouseButtons.Middle && isFirstMiddleClick)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                isFirstMiddleClick = false;
            }
            else if (e.Button == MouseButtons.Middle && !isFirstMiddleClick)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                isFirstMiddleClick = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                offsetX = e.Location.X;
                offsetY = e.Location.Y;
                MoveImage = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MoveImage = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            WhatToDo();
           
            int mx = Convert.ToInt32(e.X);
            int my = Convert.ToInt32(e.Y);
            toolStripStatusLabelCoord.Text = "oX:" + mx.ToString() + "; oY:" + my.ToString();

            if (MoveImage && !SetPoints)
            {
                int x = Cursor.Position.X - (this.Left + (this.Size.Width - this.ClientSize.Width) / 2) - offsetX;
                int y = Cursor.Position.Y - (this.Top + (this.Size.Height - this.ClientSize.Height - 4)) - offsetY;
                //if (x > 0 && x < this.ClientSize.Width - pictureBox1.Width)
                    pictureBox1.Left = x;
                //else
                //    pictureBox1.Left = x > 0 ? x = this.ClientSize.Width - pictureBox1.Width : 0;
                //if (y > 0 && y < this.ClientSize.Height - pictureBox1.Height)
                    pictureBox1.Top = y;
                //else
                //    pictureBox1.Top = y > 0 ? y = this.ClientSize.Height - pictureBox1.Height : 0;
            }
            else if (SetPoints && isPointNowSet)
            {
                isPointNowSet = false;
                Graphics g = pictureBox1.CreateGraphics();
                Pen p = Pens.Blue;
                newPointX = mx;
                newPointY = my;
                //g.DrawLine(p, oldPointX, oldPointY, newPointX, newPointY);
            }
        }

        // устанавливает режим проставления точек
        void SetPointRegime()
        {
            if (!notImg)
            {
                SetPoints = true;
                pictureBox1.Cursor = Cursors.Cross;
                toolStripStatusLabelRegime.Text = regimes[1];
            }
            else
            {
                MessageBox.Show("Сначала откройте изображение!");
                toolStripStatusLabelRegime.Text = regimes[1];
                radioButtonImg.Checked = true;
            }
        }

        // устанавливает режим перемещения изображения
        void SetImageRegime()
        {
            SetPoints = false;
            pictureBox1.Cursor = Cursors.SizeAll;
            toolStripStatusLabelRegime.Text = regimes[0];
        }

        private void WriteTxtFile(string file)
        {
            //создание нового файла или перезапись существующего
            //StreamWriter outStream =
            //  new StreamWriter(filename);
            //outStream - созданный нами объект

            //открытие существующего файла на чтение
            //StreamReader inStream =
            //new StreamReader(@"C:\Users\Николай\Desktop\newtxt.txt");
            //inStream - созданный нами объект

            StreamWriter outStream;
            FileInfo fi = new FileInfo(file);//для дописывания в конец файла
            outStream = fi.AppendText();
            outStream.WriteLine("");
            for (int j = 0; j < listLog.Count; j++)
                outStream.WriteLine(listLog[j]);
            outStream.WriteLine("");
            outStream.Close();

            //inStream.Close();
        }

        // сообщает пользователю что нужно делать через toolStripStatusLabelWhatToDo
        void WhatToDo()
        {
            string s = "";
            if (toolStripStatusLabelRegime.Text == regimes[1])
            {
                string s1 = "";
                string s2 = "";
                string s3 = "";
                string s4 = "";
                string s5 = "";
                string s6 = "| Укажите ";
                switch (currentType)
                {
                    case 0:
                        {
                            s1 = " (композиция количества пересекаемых линий)";
                            s2 = " (композиция косинуса угла)";
                            s3 = " (композиция отношения площадей треугольников)";
                            s4 = " (композиция отношения площадей трапеции и треугольника)";
                            s5 = " (композиция отношения площадей эллипса и треугольника)";
                        }
                        break;
                    case 1:
                        {
                            s1 = "";
                            s2 = "";
                            s3 = "";
                            s4 = "";
                            s5 = "";
                        }
                        break;
                    case 2:
                        {
                            s1 = " (композиция количества пересекаемых линий)";
                            s2 = " (композиция отношения косинусов углов)";
                            s3 = " (композиция отношения косинусов углов)";
                            s4 = " (композиция отношения площадей трапеций)";
                            s5 = " (композиция отношения площадей треугольников)";
                        }
                        break;
                }
                int n = 0;
                if (leftHand)
                    switch (toolStripComboBoxFingers.SelectedIndex)
                    {
                        case 0: n = list1l.Count;
                            break;
                        case 1: n = list2l.Count;
                            break;
                        case 2: n = list3l.Count;
                            break;
                        case 3: n = list4l.Count;
                            break;
                        case 4: n = list5l.Count;
                            break;
                        default: { n = 0; SetError("Ошибка: не выбран анализируемый палец."); }
                            break;
                    }
                else
                    switch (toolStripComboBoxFingers.SelectedIndex)
                    {
                        case 0: n = list1r.Count;
                            break;
                        case 1: n = list2r.Count;
                            break;
                        case 2: n = list3r.Count;
                            break;
                        case 3: n = list4r.Count;
                            break;
                        case 4: n = list5r.Count;
                            break;
                        default: { n = 0; SetError("Ошибка: не выбран анализируемый палец."); }
                            break;
                    }
                switch (currentType)
                {
                    case 0: {
                        switch (n)
                        {
                            //композиция количества пересекаемых линий
                            case 0: s = s6 + "первый конец отрезка" + s1;
                                break;
                            case 1: s = s6 + "второй конец отрезка" + s1;
                                break;
                            //композиция отношения косинусов углов
                            case 2: s = s6 + "первый конец катета для левого угла" + s2;
                                break;
                            case 3: s = s6 + "второй конец катета для левого угла" + s2;
                                break;
                            case 4: s = s6 + "первый конец гипотенузы левого угла" + s2;
                                break;
                            case 5: s = s6 + "второй конец гипотенузы левого угла" + s2;
                                break;
                            case 6: s = s6 + "первый конец катета для правого угла" + s2;
                                break;
                            case 7: s = s6 + "второй конец катета для правого угла" + s2;
                                break;
                            case 8: s = s6 + "первый конец гипотенузы правого угла" + s2;
                                break;
                            case 9: s = s6 + "второй конец гипотенузы правого угла" + s2;
                                break;
                            //композиция отношения площадей треугольников
                            case 10: s = s6 + "первый конец основания большого треугольника" + s3;
                                break;
                            case 11: s = s6 + "второй конец основания большого треугольника" + s3;
                                break;
                            case 12: s = s6 + "первый конец левой боковой строны большего треугольника" + s3;
                                break;
                            case 13: s = s6 + "второй конец левой боковой строны большего треугольника" + s3;
                                break;
                            case 14: s = s6 + "первый конец правой боковой стороны большего треугольника" + s3;
                                break;
                            case 15: s = s6 + "второй конец правой боковой стороны большего треугольника" + s3;
                                break;
                            case 16: s = s6 + "первый конец основания меньшего треугольника (боковой стороны большего треугольника)" + s3;
                                break;
                            case 17: s = s6 + "второй конец основания меньшего треугольника (боковой стороны большего треугольника)" + s3;
                                break;
                            case 18: s = s6 + "первый конец высоты меньшего треугольника" + s3;
                                break;
                            case 19: s = s6 + "второй конец высоты меньшего треугольника" + s3;
                                break;
                            //композиция отношения площадей трапеции и треугольника
                            case 20: s = s6 + "первый конец нижнего основания трапеции" + s4;
                                break;
                            case 21: s = s6 + "второй конец нижнего основания трапеции" + s4;
                                break;
                            case 22: s = s6 + "первый конец правой боковой стороны трапеции" + s4;
                                break;
                            case 23: s = s6 + "второй конец правой боковой стороны трапеции" + s4;
                                break;
                            case 24: s = s6 + "первый конец верхнего основания трапеции" + s4;
                                break;
                            case 25: s = s6 + "второй конец верхнего основания трапеции" + s4;
                                break;
                            case 26: s = s6 + "первый конец левой боковой стороны трапеции" + s4;
                                break;
                            case 27: s = s6 + "второй конец левой боковой стороны трапеции" + s4;
                                break;
                            case 28: s = s6 + "первый конец правой боковой стороны треугольника" + s4;
                                break;
                            case 29: s = s6 + "второй конец правой боковой стороны треугольника" + s4;
                                break;
                            case 30: s = s6 + "первый конец левой боковой стороны треугольника" + s4;
                                break;
                            case 31: s = s6 + "второй конец левой боковой стороны треугольника" + s4;
                                break;
                            //композиция отношения площадей эллипса и треугольника
                            case 32: s = s6 + "первый конец основания треугольника" + s5;
                                break;
                            case 33: s = s6 + "второй конец основания треугольника" + s5;
                                break;
                            case 34: s = s6 + "первый конец правой боковой стороны треугольника" + s5;
                                break;
                            case 35: s = s6 + "второй конец правой боковой стороны треугольника" + s5;
                                break;
                            case 36: s = s6 + "первый конец левой боковой стороны треугольника" + s5;
                                break;
                            case 37: s = s6 + "второй конец левой боковой стороны треугольника" + s5;
                                break;
                            case 38: s = s6 + "первый конец половины большой полуоси эллипса" + s5;
                                break;
                            case 39: s = s6 + "второй конец половины большой полуоси эллипса" + s5;
                                break;
                            case 40: s = s6 + "первый конец половины меньшей полуоси эллипса" + s5;
                                break;
                            case 41: s = s6 + "второй конец половины меньшей полуоси эллипса" + s5;
                                break;
                        }
                        toolStripStatusLabelKolPoints.Text = "| " + n.ToString();
                        if (list1l.Count == 2 || list1l.Count == kolAllPoint[currentType] || list1r.Count == 2 || list1r.Count == kolAllPoint[currentType])
                            if (!textBoxKolLines.ReadOnly)
                            {
                                pictureBox1.Cursor = Cursors.No;

                                toolStripStatusLabelWhatToDo.Text = "| Введите количество пересекаемых линий";
                            }
                    }
                        break;
                    case 1: { }
                        break;
                    case 2:
                        {
                            switch (n)
                            {
                                //метод количества пересекаемых линий
                                case 0: s = s6 + "первый конец отрезка" + s1;
                                    break;
                                case 1: s = s6 + "второй конец отрезка" + s1;
                                    break;
                                // метод косинуса угла
                                case 2: s = s6 + "первый конец катета" + s2;
                                    break;
                                case 3: s = s6 + "второй конец катета" + s2;
                                    break;
                                case 4: s = s6 + "первый конец гипотенузы" + s2;
                                    break;
                                case 5: s = s6 + "второй конец гипотенузы" + s2;
                                    break;
                                // метод отношения косинусов углов
                                case 6: s = s6 + "первый конец катета для левого угла" + s3;
                                    break;
                                case 7: s = s6 + "второй конец катета для левого угла" + s3;
                                    break;
                                case 8: s = s6 + "первый конец гипотенузы левого угла" + s3;
                                    break;
                                case 9: s = s6 + "второй конец гипотенузы левого угла" + s3;
                                    break;
                                case 10: s = s6 + "первый конец катета для правого угла" + s3;
                                    break;
                                case 11: s = s6 + "второй конец катета для правого угла" + s3;
                                    break;
                                case 12: s = s6 + "первый конец гипотенузы правого угла" + s3;
                                    break;
                                case 13: s = s6 + "второй конец гипотенузы правого угла" + s3;
                                    break;
                                // метод отношения площадей трапеций
                                case 14: s = s6 + "первый конец нижнего основания обеих трапеций" + s4;
                                    break;
                                case 15: s = s6 + "второй конец нижнего основания обеих трапеций" + s4;
                                    break;
                                case 16: s = s6 + "первый конец правой боковой стороны левой трапеции" + s4;
                                    break;
                                case 17: s = s6 + "второй конец правой боковой стороны левой трапеции" + s4;
                                    break;
                                case 18: s = s6 + "первый конец верхнего основания левой трапеции" + s4;
                                    break;
                                case 19: s = s6 + "второй конец верхнего основания левой трапеции" + s4;
                                    break;
                                case 20: s = s6 + "первый конец левой боковой стороны левой трапеции" + s4;
                                    break;
                                case 21: s = s6 + "второй конец левой боковой стороны левой трапеции" + s4;
                                    break;
                                case 22: s = s6 + "первый конец правой боковой стороны правой трапеции" + s4;
                                    break;
                                case 23: s = s6 + "второй конец правой боковой стороны правой трапеции" + s4;
                                    break;
                                case 24: s = s6 + "первый конец верхнего основания правой трапеции" + s4;
                                    break;
                                case 25: s = s6 + "второй конец верхнего основания правой трапеции" + s4;
                                    break;
                                case 26: s = s6 + "первый конец левой боковой стороны правой трапеции" + s4;
                                    break;
                                case 27: s = s6 + "второй конец левой боковой стороны правой трапеции" + s4;
                                    break;
                                // метод отношения площадей треугольников
                                case 28: s = s6 + "первый конец основания большого треугольника" + s5;
                                    break;
                                case 29: s = s6 + "второй конец основания большого треугольника" + s5;
                                    break;
                                case 30: s = s6 + "первый конец левой боковой строны большего треугольника" + s5;
                                    break;
                                case 31: s = s6 + "второй конец левой боковой строны большего треугольника" + s5;
                                    break;
                                case 32: s = s6 + "первый конец основания меньшего треугольника" + s5;
                                    break;
                                case 33: s = s6 + "второй конец основания меньшего треугольника" + s5;
                                    break;
                                case 34: s = s6 + "первый конец правой боковой стороны меньшего треугольника (боковой стороны большего треугольника)" + s5;
                                    break;
                                case 35: s = s6 + "второй конец правой боковой стороны меньшего треугольника (боковой стороны большего треугольника)" + s5;
                                    break;
                                case 36: s = s6 + "первый конец высоты меньшего треугольника" + s5;
                                    break;
                                case 37: s = s6 + "второй конец высоты меньшего треугольника" + s5;
                                    break;
                            }
                            toolStripStatusLabelKolPoints.Text = "| " + n.ToString();
                            if (list1l.Count == 2 || list1l.Count == kolAllPoint[currentType] || list1r.Count == 2 || list1r.Count == kolAllPoint[currentType])
                                if (!textBoxKolLines.ReadOnly)
                                {
                                    pictureBox1.Cursor = Cursors.No;

                                    toolStripStatusLabelWhatToDo.Text = "| Введите количество пересекаемых линий";
                                }
                        }
                        break;
                }
            }
            else 
            {
                s = "| Откройте изображения и выберите анализируемый палец";
            }
            toolStripStatusLabelWhatToDo.Text = s;
        }
        
        private void увеличитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("Изображение не выбрано!");
                MyOpen();
            }
            else
            {
                Image myBitmap = pictureBox1.Image;
                this.pictureBox1.Size = new Size(myBitmap.Width, myBitmap.Height);
                Size nSize = new Size(pictureBox1.Image.Width * 2, pictureBox1.Image.Height * 2);
                Image gdi = new Bitmap(nSize.Width, nSize.Height);
                Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                ZoomInGraphics.DrawImage(pictureBox1.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), pictureBox1.Image.Size), GraphicsUnit.Pixel);
                ZoomInGraphics.Dispose();
                pictureBox1.Image = gdi;
                pictureBox1.Size = gdi.Size;
            }
        }

        private void уменьшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("Изображение не выбрано!");
                MyOpen();
            }
            else
            {
                Image myBitmap = pictureBox1.Image;
                this.pictureBox1.Size = new Size(myBitmap.Width, myBitmap.Height);
                Size nSize = new Size(pictureBox1.Image.Width / 2, pictureBox1.Image.Height / 2);
                Image gdi = new Bitmap(nSize.Width, nSize.Height);
                Graphics ZoomInGraphics = Graphics.FromImage(gdi);
                ZoomInGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                ZoomInGraphics.DrawImage(pictureBox1.Image, new Rectangle(new Point(0, 0), nSize), new Rectangle(new Point(0, 0), pictureBox1.Image.Size), GraphicsUnit.Pixel);
                ZoomInGraphics.Dispose();
                pictureBox1.Image = gdi;
                pictureBox1.Size = gdi.Size;
            }
        }

        private void центрироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void растянутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void оригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kolclicks = 0;
            MyOpen(); 
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notImg)
                MessageBox.Show("Нечего сохранять. Сначала откройте изображение ;)");
            else
                MySave();
        }

        private void выйтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Уверены?", "Подтвердите выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
            {
                WriteNewNumExp();
                Close();
            }
        }

        private void перемещениеИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetImageRegime();
        }

        private void проставлениеТочекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPointRegime();
        }

        private void построениеГрафикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCreateGraphRegime();
        }


        private void printDoc(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Times New Roman", 30))
            {
                PrintDocument doc = new PrintDocument();
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;
                float lineHeight = font.GetHeight(e.Graphics);

                e.Graphics.DrawString("Время печати: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + ";", font, Brushes.Black, x, y);
                y += lineHeight;
                e.Graphics.DrawString("Анализируемый человек: " + currentMan + ";", font, Brushes.Black, x, y);
                y += lineHeight;
                e.Graphics.DrawString("Рука: " + currentHand() + ";", font, Brushes.Black, x, y);
                y += lineHeight;
                e.Graphics.DrawString("Палец: " + GetFinger(toolStripComboBoxFingers.SelectedIndex) + ";", font, Brushes.Black, x, y);
                y += lineHeight;
                e.Graphics.DrawString("Тип папиллярных линий: " + types[currentType] + ";", font, Brushes.Black, x, y);
                y += lineHeight;
                e.Graphics.DrawImage(pictureBox1.Image, x, y);
                y += lineHeight;
                e.Graphics.DrawString("Подробнее: ", font, Brushes.Black, x, y);
                for (int i = 0; i < listLog.Count; i++)
                {
                    e.Graphics.DrawString(listLog[i], font, Brushes.Black, x, y);
                    y += lineHeight;
                }
                Font fontCopyright = new Font("Times New Roman", 12);
                e.Graphics.DrawString("Разработчик: Пискарев Николай Сергеевич. Контактная информация: http://vk.com/piskarew_nikolay.", fontCopyright, Brushes.Black, x, y);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

            PrintDocument doc = new PrintDocument();

        }

        private void toolStripComboBoxAlreadyOpenImg_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonMens_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonM.Checked)
            {
                radioButtonF.Checked = false;
                radioButtonCh.Checked = false;
                radioButtonForeign.Checked = false;
                toolStripStatusLabelWho.Text = "| "+ radioButtonM.Text;
                currentMan = radioButtonM.Text;
                
            }
            else if (radioButtonF.Checked)
            {
                radioButtonM.Checked = false;
                radioButtonCh.Checked = false;
                radioButtonForeign.Checked = false;
                toolStripStatusLabelWho.Text = "| " + radioButtonF.Text;
                currentMan = radioButtonF.Text;
            }
            else if (radioButtonCh.Checked)
            {
                radioButtonM.Checked = false;
                radioButtonF.Checked = false;
                radioButtonForeign.Checked = false;
                toolStripStatusLabelWho.Text = "| " + radioButtonCh.Text;
                currentMan = radioButtonCh.Text;
            }
            else if (radioButtonForeign.Checked)
            {
                radioButtonM.Checked = false;
                radioButtonF.Checked = false;
                radioButtonCh.Checked = false;
                toolStripStatusLabelWho.Text = "| " + radioButtonForeign.Text;
                currentMan = radioButtonForeign.Text;
            }
            listLog.Add("");
            listLog.Add(currentMan);
            listLog.Add("");
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxKolLines.ReadOnly = false;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBoxKolLines_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxKolLines.ReadOnly = true;
                pictureBox1.Cursor = Cursors.Cross;
            }
        }

        private void textBoxKolLines_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (!textBoxKolLines.ReadOnly)
                pictureBox1.Cursor = Cursors.No;
        }

        private void radioButtonRegimes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonImg.Checked)
            {
                radioButtonPnt.Checked = false;
                radioButtonGrp.Checked = false;
                zedGraphControl1.Visible = false;
                SetImageRegime();
            }
            else if (radioButtonPnt.Checked)
            {
                radioButtonImg.Checked = false;
                radioButtonGrp.Checked = false;
                zedGraphControl1.Visible = false;
                SetPointRegime();
            }
            else if (radioButtonGrp.Checked)
            {
                radioButtonImg.Checked = false;
                radioButtonPnt.Checked = false;
                SetCreateGraphRegime();
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            MyOpen();
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxFingers.SelectedIndex != -1)
            {
                if (buttonBuild.Text == "Просчитать")
                {
                    Build();
                    SaveAllResult(currentMan);
                    MyClear();
                    toolStripStatusLabelWhatToDo.Text = "Данные сохранены.";
                    textBoxKolLines.Text = "";
                }
                else
                {
                    fastGraph = false;
                    zedGraphControl1.Visible = false;
                    buttonBuild.Text = "Просчитать";
                    radioButtonImg.Checked = true;
                }
            }
            else if (buttonBuild.Text != "Просчитать")
            {
                zedGraphControl1.Visible = false;
                buttonBuild.Text = "Просчитать";
                radioButtonImg.Checked = true;
            }
            else
                SetError("Укажите анализируемый палец!");
        }

        List<Point> myRandom()
        {
            List<Point> listAllPoint = new List<Point>();
            listAllPoint.Clear();
            Random r = new Random();
            int dx = 10;
            int dy = 10;
            Graphics g = pictureBox1.CreateGraphics();
            Brush b = Brushes.Red;
            for (int i = 0; i <= kolAllPoint[currentType]; i++)
            {
                Point pnt = new Point(r.Next(899),r.Next(482));
                listAllPoint.Add(pnt);
                listLog.Add("("+pnt.X.ToString()+","+pnt.Y.ToString()+")");
                g.FillEllipse(b, pnt.X, pnt.Y, dx, dy);
            }
            return listAllPoint;
        }

        
        void SetError(string s)
        {
            toolStripStatusLabelError.Text = s;
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        // возвращает список точек при заданных номере пальца и классе композиций
        PointPairList GetPPList(int num_finger, Compositions c)
        {
            PointPairList list = new PointPairList();
            switch (num_finger)
            {
                case 1:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            list.Add(i, c.ratio_c1[0]);
                            list.Add(i, c.ratio_c2[0]);
                            list.Add(i, c.ratio_c3[0]);
                            list.Add(i, c.ratio_c4[0]);
                            list.Add(i, c.ratio_c5[0]);
                        }
                        return list;
                    }
                case 2:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            list.Add(i, c.ratio_c1[1]);
                            list.Add(i, c.ratio_c2[1]);
                            list.Add(i, c.ratio_c3[1]);
                            list.Add(i, c.ratio_c4[1]);
                            list.Add(i, c.ratio_c5[1]);
                        }
                        return list;
                    }

                case 3:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            list.Add(i, c.ratio_c1[2]);
                            list.Add(i, c.ratio_c2[2]);
                            list.Add(i, c.ratio_c3[2]);
                            list.Add(i, c.ratio_c4[2]);
                            list.Add(i, c.ratio_c5[2]);
                        }
                        return list;
                    }
                case 4:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            list.Add(i, c.ratio_c1[3]);
                            list.Add(i, c.ratio_c2[3]);
                            list.Add(i, c.ratio_c3[3]);
                            list.Add(i, c.ratio_c4[3]);
                            list.Add(i, c.ratio_c5[3]);
                        }
                        return list;
                    }
                case 5:
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            list.Add(i, c.ratio_c1[4]);
                            list.Add(i, c.ratio_c2[4]);
                            list.Add(i, c.ratio_c3[4]);
                            list.Add(i, c.ratio_c4[4]);
                            list.Add(i, c.ratio_c5[4]);
                        }
                        return list;
                    }
                default: { return list; }
            }
        }

        
        // находит расстояние между двумя точками
        double distance(Point p1, Point p2/*, string s*/)
        {
            double a = Math.Pow((p1.X - p2.X), 2);
            double b = Math.Pow((p1.Y - p2.Y), 2);
            double c = Math.Sqrt(a + b);
            listLog.Add(c.ToString());
            return c;
        }

        void setDistance(int currentFinger, string hand)
        {
            switch (currentType)
            {
                case 0: { 
                    switch (hand)
                    {
                        case "левая":
                            switch (currentFinger)
                            {
                                case 0:
                                    {
                                        listLog.Add("man.arrFingers[0]:");
                                        man.arrFingersLeftHand[0].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list1l[0], list1l[1]),
                                            distance(list1l[2], list1l[3]),
                                            distance(list1l[4], list1l[5]),
                                            distance(list1l[6], list1l[7]),
                                            distance(list1l[8], list1l[9]),
                                            distance(list1l[10], list1l[11]),
                                            distance(list1l[12], list1l[13]),
                                            distance(list1l[14], list1l[15]),
                                            distance(list1l[16], list1l[17]),
                                            distance(list1l[18], list1l[19]),
                                            distance(list1l[20], list1l[21]),
                                            distance(list1l[22], list1l[23]),
                                            distance(list1l[24], list1l[25]),
                                            distance(list1l[26], list1l[27]),
                                            distance(list1l[28], list1l[29]),
                                            distance(list1l[30], list1l[31]),
                                            distance(list1l[32], list1l[33]),
                                            distance(list1l[34], list1l[35]),
                                            distance(list1l[36], list1l[37]),
                                            distance(list1l[38], list1l[39]),
                                            distance(list1l[40], list1l[41])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 1:
                                    {//2
                                        listLog.Add("man.arrFingers[1]:");
                                        man.arrFingersLeftHand[1].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list2l[0], list2l[1]),
                                            distance(list2l[2], list2l[3]),
                                            distance(list2l[4], list2l[5]),
                                            distance(list2l[6], list2l[7]),
                                            distance(list2l[8], list2l[9]),
                                            distance(list2l[10], list2l[11]),
                                            distance(list2l[12], list2l[13]),
                                            distance(list2l[14], list2l[15]),
                                            distance(list2l[16], list2l[17]),
                                            distance(list2l[18], list2l[19]),
                                            distance(list2l[20], list2l[21]),
                                            distance(list2l[22], list2l[23]),
                                            distance(list2l[24], list2l[25]),
                                            distance(list2l[26], list2l[27]),
                                            distance(list2l[28], list2l[29]),
                                            distance(list2l[30], list2l[31]),
                                            distance(list2l[32], list2l[33]),
                                            distance(list2l[34], list2l[35]),
                                            distance(list2l[36], list2l[37]),
                                            distance(list2l[38], list2l[39]),
                                            distance(list2l[40], list2l[41])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 2:
                                    {//3
                                        listLog.Add("man.arrFingers[2]:");
                                        man.arrFingersLeftHand[2].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list3l[0], list3l[1]),
                                            distance(list3l[2], list3l[3]),
                                            distance(list3l[4], list3l[5]),
                                            distance(list3l[6], list3l[7]),
                                            distance(list3l[8], list3l[9]),
                                            distance(list3l[10], list3l[11]),
                                            distance(list3l[12], list3l[13]),
                                            distance(list3l[14], list3l[15]),
                                            distance(list3l[16], list3l[17]),
                                            distance(list3l[18], list3l[19]),
                                            distance(list3l[20], list3l[21]),
                                            distance(list3l[22], list3l[23]),
                                            distance(list3l[24], list3l[25]),
                                            distance(list3l[26], list3l[27]),
                                            distance(list3l[28], list3l[29]),
                                            distance(list3l[30], list3l[31]),
                                            distance(list3l[32], list3l[33]),
                                            distance(list3l[34], list3l[35]),
                                            distance(list3l[36], list3l[37]),
                                            distance(list3l[38], list3l[39]),
                                            distance(list3l[40], list3l[41])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 3:
                                    {//4
                                        listLog.Add("man.arrFingers[3]:");
                                        man.arrFingersLeftHand[3].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list4l[0], list4l[1]),
                                            distance(list4l[2], list4l[3]),
                                            distance(list4l[4], list4l[5]),
                                            distance(list4l[6], list4l[7]),
                                            distance(list4l[8], list4l[9]),
                                            distance(list4l[10], list4l[11]),
                                            distance(list4l[12], list4l[13]),
                                            distance(list4l[14], list4l[15]),
                                            distance(list4l[16], list4l[17]),
                                            distance(list4l[18], list4l[19]),
                                            distance(list4l[20], list4l[21]),
                                            distance(list4l[22], list4l[23]),
                                            distance(list4l[24], list4l[25]),
                                            distance(list4l[26], list4l[27]),
                                            distance(list4l[28], list4l[29]),
                                            distance(list4l[30], list4l[31]),
                                            distance(list4l[32], list4l[33]),
                                            distance(list4l[34], list4l[35]),
                                            distance(list4l[36], list4l[37]),
                                            distance(list4l[38], list4l[39]),
                                            distance(list4l[40], list4l[41])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 4:
                                    {//5
                                        listLog.Add("man.arrFingers[4]:");
                                        man.arrFingersLeftHand[4].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list5l[0], list5l[1]),
                                            distance(list5l[2], list5l[3]),
                                            distance(list5l[4], list5l[5]),
                                            distance(list5l[6], list5l[7]),
                                            distance(list5l[8], list5l[9]),
                                            distance(list5l[10], list5l[11]),
                                            distance(list5l[12], list5l[13]),
                                            distance(list5l[14], list5l[15]),
                                            distance(list5l[16], list5l[17]),
                                            distance(list5l[18], list5l[19]),
                                            distance(list5l[20], list5l[21]),
                                            distance(list5l[22], list5l[23]),
                                            distance(list5l[24], list5l[25]),
                                            distance(list5l[26], list5l[27]),
                                            distance(list5l[28], list5l[29]),
                                            distance(list5l[30], list5l[31]),
                                            distance(list5l[32], list5l[33]),
                                            distance(list5l[34], list5l[35]),
                                            distance(list5l[36], list5l[37]),
                                            distance(list5l[38], list5l[39]),
                                            distance(list5l[40], list5l[41])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                        listLog.Add("Рисуем график человека.");
                                    }
                                    break;
                                default: SetError("Вы не выбрали палец.");
                                    break;
                            }
                            break;
                        case "правая": 
                            switch (currentFinger)
                            {
                                case 0:
                                    {
                                    listLog.Add("man.arrFingers[0]:");
                                    man.arrFingersRightHand[0].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list1r[0], list1r[1]),
                                        distance(list1r[2], list1r[3]),
                                        distance(list1r[4], list1r[5]),
                                        distance(list1r[6], list1r[7]),
                                        distance(list1r[8], list1r[9]),
                                        distance(list1r[10], list1r[11]),
                                        distance(list1r[12], list1r[13]),
                                        distance(list1r[14], list1r[15]),
                                        distance(list1r[16], list1r[17]),
                                        distance(list1r[18], list1r[19]),
                                        distance(list1r[20], list1r[21]),
                                        distance(list1r[22], list1r[23]),
                                        distance(list1r[24], list1r[25]),
                                        distance(list1r[26], list1r[27]),
                                        distance(list1r[28], list1r[29]),
                                        distance(list1r[30], list1r[31]),
                                        distance(list1r[32], list1r[33]),
                                        distance(list1r[34], list1r[35]),
                                        distance(list1r[36], list1r[37]),
                                        distance(list1r[38], list1r[39]),
                                        distance(list1r[40], list1r[41])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 1:
                                    {//2
                                    listLog.Add("man.arrFingers[1]:");
                                    man.arrFingersRightHand[1].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list2r[0], list2r[1]),
                                        distance(list2r[2], list2r[3]),
                                        distance(list2r[4], list2r[5]),
                                        distance(list2r[6], list2r[7]),
                                        distance(list2r[8], list2r[9]),
                                        distance(list2r[10], list2r[11]),
                                        distance(list2r[12], list2r[13]),
                                        distance(list2r[14], list2r[15]),
                                        distance(list2r[16], list2r[17]),
                                        distance(list2r[18], list2r[19]),
                                        distance(list2r[20], list2r[21]),
                                        distance(list2r[22], list2r[23]),
                                        distance(list2r[24], list2r[25]),
                                        distance(list2r[26], list2r[27]),
                                        distance(list2r[28], list2r[29]),
                                        distance(list2r[30], list2r[31]),
                                        distance(list2r[32], list2r[33]),
                                        distance(list2r[34], list2r[35]),
                                        distance(list2r[36], list2r[37]),
                                        distance(list2r[38], list2r[39]),
                                        distance(list2r[40], list2r[41])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 2:
                                    {//3
                                    listLog.Add("man.arrFingers[2]:");
                                    man.arrFingersRightHand[2].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list3r[0], list3r[1]),
                                        distance(list3r[2], list3r[3]),
                                        distance(list3r[4], list3r[5]),
                                        distance(list3r[6], list3r[7]),
                                        distance(list3r[8], list3r[9]),
                                        distance(list3r[10], list3r[11]),
                                        distance(list3r[12], list3r[13]),
                                        distance(list3r[14], list3r[15]),
                                        distance(list3r[16], list3r[17]),
                                        distance(list3r[18], list3r[19]),
                                        distance(list3r[20], list3r[21]),
                                        distance(list3r[22], list3r[23]),
                                        distance(list3r[24], list3r[25]),
                                        distance(list3r[26], list3r[27]),
                                        distance(list3r[28], list3r[29]),
                                        distance(list3r[30], list3r[31]),
                                        distance(list3r[32], list3r[33]),
                                        distance(list3r[34], list3r[35]),
                                        distance(list3r[36], list3r[37]),
                                        distance(list3r[38], list3r[39]),
                                        distance(list3r[40], list3r[41])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 3:
                                    {//4
                                    listLog.Add("man.arrFingers[3]:");
                                    man.arrFingersRightHand[3].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list4r[0], list4r[1]),
                                        distance(list4r[2], list4r[3]),
                                        distance(list4r[4], list4r[5]),
                                        distance(list4r[6], list4r[7]),
                                        distance(list4r[8], list4r[9]),
                                        distance(list4r[10], list4r[11]),
                                        distance(list4r[12], list4r[13]),
                                        distance(list4r[14], list4r[15]),
                                        distance(list4r[16], list4r[17]),
                                        distance(list4r[18], list4r[19]),
                                        distance(list4r[20], list4r[21]),
                                        distance(list4r[22], list4r[23]),
                                        distance(list4r[24], list4r[25]),
                                        distance(list4r[26], list4r[27]),
                                        distance(list4r[28], list4r[29]),
                                        distance(list4r[30], list4r[31]),
                                        distance(list4r[32], list4r[33]),
                                        distance(list4r[34], list4r[35]),
                                        distance(list4r[36], list4r[37]),
                                        distance(list4r[38], list4r[39]),
                                        distance(list4r[40], list4r[41])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 4:
                                    {//5
                                    listLog.Add("man.arrFingers[4]:");
                                    man.arrFingersRightHand[4].SetAllDug(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list5r[0], list5r[1]),
                                        distance(list5r[2], list5r[3]),
                                        distance(list5r[4], list5r[5]),
                                        distance(list5r[6], list5r[7]),
                                        distance(list5r[8], list5r[9]),
                                        distance(list5r[10], list5r[11]),
                                        distance(list5r[12], list5r[13]),
                                        distance(list5r[14], list5r[15]),
                                        distance(list5r[16], list5r[17]),
                                        distance(list5r[18], list5r[19]),
                                        distance(list5r[20], list5r[21]),
                                        distance(list5r[22], list5r[23]),
                                        distance(list5r[24], list5r[25]),
                                        distance(list5r[26], list5r[27]),
                                        distance(list5r[28], list5r[29]),
                                        distance(list5r[30], list5r[31]),
                                        distance(list5r[32], list5r[33]),
                                        distance(list5r[34], list5r[35]),
                                        distance(list5r[36], list5r[37]),
                                        distance(list5r[38], list5r[39]),
                                        distance(list5r[40], list5r[41])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    listLog.Add("Рисуем график человека.");
                                    }
                                    break;
                                default: SetError("Вы не выбрали палец.");
                                    break;
                            }
                            break;
                        }
                        break;
                    }
                    break;
                case 1: { 
                
                ////////////////////////////////////////
                
                }
                    break;
                case 2:
                    switch (hand)
                    {
                        case "левая":
                            switch (currentFinger)
                            {
                                case 0:
                                    {
                                        listLog.Add("man.arrFingers[0]:");
                                        man.arrFingersLeftHand[0].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list1l[0], list1l[1]),
                                            distance(list1l[2], list1l[3]),
                                            distance(list1l[4], list1l[5]),
                                            distance(list1l[6], list1l[7]),
                                            distance(list1l[8], list1l[9]),
                                            distance(list1l[10], list1l[11]),
                                            distance(list1l[12], list1l[13]),
                                            distance(list1l[14], list1l[15]),
                                            distance(list1l[16], list1l[17]),
                                            distance(list1l[18], list1l[19]),
                                            distance(list1l[20], list1l[21]),
                                            distance(list1l[22], list1l[23]),
                                            distance(list1l[24], list1l[25]),
                                            distance(list1l[26], list1l[27]),
                                            distance(list1l[28], list1l[29]),
                                            distance(list1l[30], list1l[31]),
                                            distance(list1l[32], list1l[33]),
                                            distance(list1l[34], list1l[35]),
                                            distance(list1l[36], list1l[37])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 1:
                                    {//2
                                        listLog.Add("man.arrFingers[1]:");
                                        man.arrFingersLeftHand[1].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list2l[0], list2l[1]),
                                            distance(list2l[2], list2l[3]),
                                            distance(list2l[4], list2l[5]),
                                            distance(list2l[6], list2l[7]),
                                            distance(list2l[8], list2l[9]),
                                            distance(list2l[10], list2l[11]),
                                            distance(list2l[12], list2l[13]),
                                            distance(list2l[14], list2l[15]),
                                            distance(list2l[16], list2l[17]),
                                            distance(list2l[18], list2l[19]),
                                            distance(list2l[20], list2l[21]),
                                            distance(list2l[22], list2l[23]),
                                            distance(list2l[24], list2l[25]),
                                            distance(list2l[26], list2l[27]),
                                            distance(list2l[28], list2l[29]),
                                            distance(list2l[30], list2l[31]),
                                            distance(list2l[32], list2l[33]),
                                            distance(list2l[34], list2l[35]),
                                            distance(list2l[36], list2l[37])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 2:
                                    {//3
                                        listLog.Add("man.arrFingers[2]:");
                                        man.arrFingersLeftHand[2].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list3l[0], list3l[1]),
                                            distance(list3l[2], list3l[3]),
                                            distance(list3l[4], list3l[5]),
                                            distance(list3l[6], list3l[7]),
                                            distance(list3l[8], list3l[9]),
                                            distance(list3l[10], list3l[11]),
                                            distance(list3l[12], list3l[13]),
                                            distance(list3l[14], list3l[15]),
                                            distance(list3l[16], list3l[17]),
                                            distance(list3l[18], list3l[19]),
                                            distance(list3l[20], list3l[21]),
                                            distance(list3l[22], list3l[23]),
                                            distance(list3l[24], list3l[25]),
                                            distance(list3l[26], list3l[27]),
                                            distance(list3l[28], list3l[29]),
                                            distance(list3l[30], list3l[31]),
                                            distance(list3l[32], list3l[33]),
                                            distance(list3l[34], list3l[35]),
                                            distance(list3l[36], list3l[37])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 3:
                                    {//4
                                        listLog.Add("man.arrFingers[3]:");
                                        man.arrFingersLeftHand[3].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list4l[0], list4l[1]),
                                            distance(list4l[2], list4l[3]),
                                            distance(list4l[4], list4l[5]),
                                            distance(list4l[6], list4l[7]),
                                            distance(list4l[8], list4l[9]),
                                            distance(list4l[10], list4l[11]),
                                            distance(list4l[12], list4l[13]),
                                            distance(list4l[14], list4l[15]),
                                            distance(list4l[16], list4l[17]),
                                            distance(list4l[18], list4l[19]),
                                            distance(list4l[20], list4l[21]),
                                            distance(list4l[22], list4l[23]),
                                            distance(list4l[24], list4l[25]),
                                            distance(list4l[26], list4l[27]),
                                            distance(list4l[28], list4l[29]),
                                            distance(list4l[30], list4l[31]),
                                            distance(list4l[32], list4l[33]),
                                            distance(list4l[34], list4l[35]),
                                            distance(list4l[36], list4l[37])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 4:
                                    {//5
                                        listLog.Add("man.arrFingers[4]:");
                                        man.arrFingersLeftHand[4].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                            distance(list5l[0], list5l[1]),
                                            distance(list5l[2], list5l[3]),
                                            distance(list5l[4], list5l[5]),
                                            distance(list5l[6], list5l[7]),
                                            distance(list5l[8], list5l[9]),
                                            distance(list5l[10], list5l[11]),
                                            distance(list5l[12], list5l[13]),
                                            distance(list5l[14], list5l[15]),
                                            distance(list5l[16], list5l[17]),
                                            distance(list5l[18], list5l[19]),
                                            distance(list5l[20], list5l[21]),
                                            distance(list5l[22], list5l[23]),
                                            distance(list5l[24], list5l[25]),
                                            distance(list5l[26], list5l[27]),
                                            distance(list5l[28], list5l[29]),
                                            distance(list5l[30], list5l[31]),
                                            distance(list5l[32], list5l[33]),
                                            distance(list5l[34], list5l[35]),
                                            distance(list5l[36], list5l[37])
                                            );
                                        listLog.Add("");
                                        listLog.Add("Вычисление расстояний между точками закончено.");
                                        listLog.Add("----------------------------------------------");
                                        listLog.Add("Рисуем график человека.");
                                    }
                                    break;
                                default: SetError("Вы не выбрали палец.");
                                    break;
                            }
                            break;
                        case "правая": 
                            switch (currentFinger)
                            {
                                case 0:
                                    {
                                    listLog.Add("man.arrFingers[0]:");
                                    man.arrFingersRightHand[0].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list1r[0], list1r[1]),
                                        distance(list1r[2], list1r[3]),
                                        distance(list1r[4], list1r[5]),
                                        distance(list1r[6], list1r[7]),
                                        distance(list1r[8], list1r[9]),
                                        distance(list1r[10], list1r[11]),
                                        distance(list1r[12], list1r[13]),
                                        distance(list1r[14], list1r[15]),
                                        distance(list1r[16], list1r[17]),
                                        distance(list1r[18], list1r[19]),
                                        distance(list1r[20], list1r[21]),
                                        distance(list1r[22], list1r[23]),
                                        distance(list1r[24], list1r[25]),
                                        distance(list1r[26], list1r[27]),
                                        distance(list1r[28], list1r[29]),
                                        distance(list1r[30], list1r[31]),
                                        distance(list1r[32], list1r[33]),
                                        distance(list1r[34], list1r[35]),
                                        distance(list1r[36], list1r[37])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 1:
                                    {//2
                                    listLog.Add("man.arrFingers[1]:");
                                    man.arrFingersRightHand[1].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list2r[0], list2r[1]),
                                        distance(list2r[2], list2r[3]),
                                        distance(list2r[4], list2r[5]),
                                        distance(list2r[6], list2r[7]),
                                        distance(list2r[8], list2r[9]),
                                        distance(list2r[10], list2r[11]),
                                        distance(list2r[12], list2r[13]),
                                        distance(list2r[14], list2r[15]),
                                        distance(list2r[16], list2r[17]),
                                        distance(list2r[18], list2r[19]),
                                        distance(list2r[20], list2r[21]),
                                        distance(list2r[22], list2r[23]),
                                        distance(list2r[24], list2r[25]),
                                        distance(list2r[26], list2r[27]),
                                        distance(list2r[28], list2r[29]),
                                        distance(list2r[30], list2r[31]),
                                        distance(list2r[32], list2r[33]),
                                        distance(list2r[34], list2r[35]),
                                        distance(list2r[36], list2r[37])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 2:
                                    {//3
                                    listLog.Add("man.arrFingers[2]:");
                                    man.arrFingersRightHand[2].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list3r[0], list3r[1]),
                                        distance(list3r[2], list3r[3]),
                                        distance(list3r[4], list3r[5]),
                                        distance(list3r[6], list3r[7]),
                                        distance(list3r[8], list3r[9]),
                                        distance(list3r[10], list3r[11]),
                                        distance(list3r[12], list3r[13]),
                                        distance(list3r[14], list3r[15]),
                                        distance(list3r[16], list3r[17]),
                                        distance(list3r[18], list3r[19]),
                                        distance(list3r[20], list3r[21]),
                                        distance(list3r[22], list3r[23]),
                                        distance(list3r[24], list3r[25]),
                                        distance(list3r[26], list3r[27]),
                                        distance(list3r[28], list3r[29]),
                                        distance(list3r[30], list3r[31]),
                                        distance(list3r[32], list3r[33]),
                                        distance(list3r[34], list3r[35]),
                                        distance(list3r[36], list3r[37])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 3:
                                    {//4
                                    listLog.Add("man.arrFingers[3]:");
                                    man.arrFingersRightHand[3].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list4r[0], list4r[1]),
                                        distance(list4r[2], list4r[3]),
                                        distance(list4r[4], list4r[5]),
                                        distance(list4r[6], list4r[7]),
                                        distance(list4r[8], list4r[9]),
                                        distance(list4r[10], list4r[11]),
                                        distance(list4r[12], list4r[13]),
                                        distance(list4r[14], list4r[15]),
                                        distance(list4r[16], list4r[17]),
                                        distance(list4r[18], list4r[19]),
                                        distance(list4r[20], list4r[21]),
                                        distance(list4r[22], list4r[23]),
                                        distance(list4r[24], list4r[25]),
                                        distance(list4r[26], list4r[27]),
                                        distance(list4r[28], list4r[29]),
                                        distance(list4r[30], list4r[31]),
                                        distance(list4r[32], list4r[33]),
                                        distance(list4r[34], list4r[35]),
                                        distance(list4r[36], list4r[37])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    }
                                    break;
                                case 4:
                                    {//5
                                    listLog.Add("man.arrFingers[4]:");
                                    man.arrFingersRightHand[4].SetAll(Convert.ToInt16(textBoxKolLines.Text),
                                        distance(list5r[0], list5r[1]),
                                        distance(list5r[2], list5r[3]),
                                        distance(list5r[4], list5r[5]),
                                        distance(list5r[6], list5r[7]),
                                        distance(list5r[8], list5r[9]),
                                        distance(list5r[10], list5r[11]),
                                        distance(list5r[12], list5r[13]),
                                        distance(list5r[14], list5r[15]),
                                        distance(list5r[16], list5r[17]),
                                        distance(list5r[18], list5r[19]),
                                        distance(list5r[20], list5r[21]),
                                        distance(list5r[22], list5r[23]),
                                        distance(list5r[24], list5r[25]),
                                        distance(list5r[26], list5r[27]),
                                        distance(list5r[28], list5r[29]),
                                        distance(list5r[30], list5r[31]),
                                        distance(list5r[32], list5r[33]),
                                        distance(list5r[34], list5r[35]),
                                        distance(list5r[36], list5r[37])
                                        );
                                    listLog.Add("");
                                    listLog.Add("Вычисление расстояний между точками закончено.");
                                    listLog.Add("----------------------------------------------");
                                    listLog.Add("Рисуем график человека.");
                                    }
                                    break;
                                default: SetError("Вы не выбрали палец.");
                                    break;
                            }
                            break;
                    }
                    break;
            }
            
        }

        void drawMan(int currentFinger, Color color, string sman, string hand)
        {
            
            setDistance(currentFinger, hand);
            man.SetAllCompositions(currentType);
            GraphPane pane = zedGraphControl1.GraphPane;
            
            if (hand == "левая")
            {
                switch (currentFinger)
                {

                    case 0: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(1, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(1, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(1, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(1, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        }
                        break;
                    case 1: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(2, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(2, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(2, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(2, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 2: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(3, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(3, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(3, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(3, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 3: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(4, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(4, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(4, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(4, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 4: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(5, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(5, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(5, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(5, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                }
            }
            else
            {
                switch (currentFinger)
                {
                    case 0: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(6, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(6, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(6, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(6, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 1: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(7, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(7, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(7, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(7, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 2: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(8, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(8, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(8, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(8, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 3: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(9, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(9, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(9, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(9, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                    case 4: switch (currentMan)
                        {
                            case "Мать": listPP1.Add(10, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Отец": listPP2.Add(10, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Ребёнок": listPP3.Add(10, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                            case "Чужой": listPP4.Add(10, man.composition.VALUE_LEFT_HAND[currentFinger]); break;
                        } break;
                }
            }
            if (leftHand && currentFinger == 4 || !leftHand && currentFinger == 4)
            {
                switch (currentMan)
                {
                    case "Мать": myCurve1 = pane.AddCurve(sman + " (" + hand + ")", listPP1, switchColor(1), SymbolType.Circle); break;
                    case "Отец": myCurve2 = pane.AddCurve(sman + " (" + hand + ")", listPP2, switchColor(2), SymbolType.Circle); break;
                    case "Ребёнок": myCurve3 = pane.AddCurve(sman + " (" + hand + ")", listPP3, switchColor(3), SymbolType.Circle); break;
                    case "Чужой": myCurve4 = pane.AddCurve(sman + " (" + hand + ")", listPP4, switchColor(4), SymbolType.Circle); break;
                }
            }
        }

        void Build()
        {
            //выбрать палец!
            int currentFinger = toolStripComboBoxFingers.SelectedIndex;
            GraphPane pane = zedGraphControl1.GraphPane;

            drawMan(currentFinger, switchColor(numColor), currentMan, currentHand());
            if (numColor < toolStripComboBoxColorLines.Items.Count - 1)
                numColor++;
            else
                numColor = 0;
            pane.XAxis.Title.Text = "Композиции";
            pane.YAxis.Title.Text = "Отношения";
            // Горизонтальная линия на уровне y = 0 рисоваться не будет
            pane.YAxis.MajorGrid.IsZeroLine = false;
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = 1;
            pane.XAxis.Scale.Max = 5;
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 30;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        // устанавливает режим построения графика
        void SetCreateGraphRegime()
        {
            if (!notImg /*&& isAllListsFull()*/)
            {
                zedGraphControl1.Visible = true;
                toolStripStatusLabelRegime.Text = regimes[2];
                listLog.Add("Закончили рисовать");
                WriteTxtFile(filenameLog);
            }
            else if (notImg)
            {
                MessageBox.Show("Сначала откройте изображение!");
                toolStripStatusLabelRegime.Text = regimes[1];
                radioButtonImg.Checked = true;
            }
            else if (!isAllListsFull())
            {
                MessageBox.Show("Вы проставили не все узловые точки в композициях!");
                toolStripStatusLabelRegime.Text = regimes[1];
                radioButtonPnt.Checked = true;
            }
        }

        string GetFinger(int i)
        {
            switch (i)
            {
                case 0: return "Большой";
                case 1: return "Указательный";
                case 2: return "Средний";
                case 3: return "Безымянный";
                case 4: return "Мизинец";
                default: return "Большой";
            }
        }

        void BuildGraphics(ZedGraphControl zedGraphControl1, GraphPane pane, string man, string finger, double[] list, Color color)
        {
            PointPairList listPP = new PointPairList();
            for (int i = 0; i < list.Length; i++)
                listPP.Add(i+1, list[i]);
            LineItem myCurve;
            myCurve = pane.AddCurve(man+" (" + finger + ")", listPP, color, SymbolType.Circle);
        }

        private void показатьСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok;
            GraphPane pane = zedGraphControl1.GraphPane;
            if (показатьСеткуToolStripMenuItem.Text == "Показать крупную сетку")
            {
                ok = true;
                показатьСеткуToolStripMenuItem.Text = "Скрыть крупную сетку";
                // Включаем отображение сетки напротив крупных рисок по оси X
                pane.XAxis.MajorGrid.IsVisible = ok;
                // Задаем вид пунктирной линии для крупных рисок по оси X:
                // Длина штрихов равна 10 пикселям, ... 
                pane.XAxis.MajorGrid.DashOn = 10;
                // затем 5 пикселей - пропуск
                pane.XAxis.MajorGrid.DashOff = 5;
                // Включаем отображение сетки напротив крупных рисок по оси Y
                pane.YAxis.MajorGrid.IsVisible = ok;
                // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
                pane.YAxis.MajorGrid.DashOn = 10;
                pane.YAxis.MajorGrid.DashOff = 5;
                // Включаем отображение сетки напротив мелких рисок по оси X
                //pane.YAxis.MinorGrid.IsVisible = true;
                // Задаем вид пунктирной линии для крупных рисок по оси Y: 
                // Длина штрихов равна одному пикселю, ... 
                pane.YAxis.MinorGrid.DashOn = 1;
                // затем 2 пикселя - пропуск
                pane.YAxis.MinorGrid.DashOff = 2;
                // Включаем отображение сетки напротив мелких рисок по оси Y
                //pane.XAxis.MinorGrid.IsVisible = true;
                // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
                pane.XAxis.MinorGrid.DashOn = 1;
                pane.XAxis.MinorGrid.DashOff = 2;
            }
            else
            {
                ok = false;
                показатьСеткуToolStripMenuItem.Text = "Показать крупную сетку";
                pane.XAxis.MajorGrid.IsVisible = ok;
                pane.YAxis.MajorGrid.IsVisible = ok;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void мелкуюСеткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            bool ok;
            if (показатьМелкуюСеткуToolStripMenuItem.Text == "Показать мелкую сетку")
            {
                ok = true;
                показатьМелкуюСеткуToolStripMenuItem.Text = "Скрыть мелкую сетку";
            }
            else
            {
                ok = false;
                показатьМелкуюСеткуToolStripMenuItem.Text = "Показать мелкую сетку";
            }
            // Включаем/выключаем отображение сетки напротив мелких рисок по оси X
            pane.YAxis.MinorGrid.IsVisible = ok;
            // Включаем/выключаем отображение сетки напротив мелких рисок по оси Y
            pane.XAxis.MinorGrid.IsVisible = ok;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxFingers.SelectedIndex != -1)
            {
                MyLine(firstSecondPoints[0], firstSecondPoints[1]);
                toolStripStatusLabelLenght.Text = "| " + distance(firstSecondPoints[0], firstSecondPoints[1]).ToString() + "px";
            }
            else
                SetError("Укажите анализируемый палец!");
        }

        bool isAllListsFull()
        {
            if (list1l.Count != kolAllPoint[currentType] || list2l.Count != kolAllPoint[currentType] || list3l.Count != kolAllPoint[currentType] || list4l.Count != kolAllPoint[currentType] || list5l.Count != kolAllPoint[currentType] ||
                list1r.Count != kolAllPoint[currentType] || list2r.Count != kolAllPoint[currentType] || list3r.Count != kolAllPoint[currentType] || list4r.Count != kolAllPoint[currentType] || list5r.Count != kolAllPoint[currentType])
                return false;
            return true;
        }

        int kolPointInArray = 0;
        void SetMyPoint(int x, int y)
        {
            if (kolPointInArray == 0)
                firstSecondPoints[0] = new Point(x, y);
            else if (kolPointInArray == 1)
                firstSecondPoints[1] = new Point(x, y);
            else
            {
                kolPointInArray = 0;
                firstSecondPoints[0] = new Point(x, y);
            }
            kolPointInArray++;
        }

        //чтобы не дублировать код в методе toolStripComboBoxFingers_SelectedIndexChanged
        void indexChangetOpenImg(string[] allimg, int index)
        {
            Image image = null;
            if (allimg[index] != null)
            {
                image = Image.FromFile(allimg[index]);
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                pictureBox1.Image = new Bitmap(image, width, height);
                notImg = false;
            }
        }

        private void toolStripComboBoxFingers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WriteNewNumExp();
                kolclicks = 0;
                textBoxKolLines.Text = "";
                textBoxKolLines.ReadOnly = true;
                listBoxLog.Items.Clear();
                trackBar1.Value = 10;
                if (openAllImg)
                {
                    string[] allimg = switchManImg();
                    if (allimg.Length == 10)
                        switch (currentHand())
                        {
                            case "левая":
                            {
                                SetError("");
                                indexChangetOpenImg(allimg, toolStripComboBoxFingers.SelectedIndex);
                            }
                            break;
                            case "правая":
                            {
                                SetError("");
                                indexChangetOpenImg(allimg, toolStripComboBoxFingers.SelectedIndex + 5);
                            }
                            break;
                        }
                }
                else
                    if (toolStripComboBoxFingers.SelectedIndex != -1)
                        SetError("");
                    else
                        SetError("Выберете анализируемый палец!");
            }
            catch (Exception ex)
            {
                SetError(ex.Message); 
                return;
            }
        }
        // возвращает список изображений для определенного человека
        string[] switchManImg()
        {
            switch (currentMan)
            {
                case "Мать": return linkImg1;
                case "Отец": return linkImg2;
                case "Ребёнок": return linkImg3;
                case "Чужой": return linkImg4;
                default: return linkImg4;
            }
        }

        private void перемещениеИзображенияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            radioButtonImg.Checked = true;
            radioButtonPnt.Checked = false;
            radioButtonGrp.Checked = false;
            zedGraphControl1.Visible = false;
            SetImageRegime();
        }

        private void разметкаИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButtonPnt.Checked = true;
            radioButtonImg.Checked = false;
            radioButtonGrp.Checked = false;
            zedGraphControl1.Visible = false;
            SetPointRegime();
            
        }

        private void построениеГрафикаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            radioButtonGrp.Checked = true;
            radioButtonImg.Checked = false;
            radioButtonPnt.Checked = false;
            SetCreateGraphRegime();
            
        }

        private void toolStripComboBoxColorLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            numColor = toolStripComboBoxColorLines.SelectedIndex;
        }

        private void zedGraphControl1_VisibleChanged(object sender, EventArgs e)
        {
            buttonBuild.Text = "Скрыть";
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        // обрабатывает масштабирование изображения через ползунок 
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            Bitmap result = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(result);
            kolScroll = (trackBar1.Maximum - trackBar1.Value);
            if (lastValue < trackBar1.Value && trackBar1.Value < trackBar1.Maximum)
            {
                //g.DrawImage(image, 10, 10, image.Width + k, image.Height + k);
                pictureBox1.Width = image.Width - minusInterval * kolScroll; // минус на минус дает плюс
                pictureBox1.Height = image.Height - minusInterval * kolScroll;
                g.DrawImageUnscaled(image, 0, 0);

                Image newImage = pictureBox1.Image;
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                pictureBox1.Image = new Bitmap(newImage, width, height);
                //delta += minusInterval;
            }
            else if (lastValue > trackBar1.Value /*&& trackBar1.Value > trackBar1.Minimum*/)
            {
                //g.DrawImage(image, 0, 0, image.Width - k, image.Height - k);
                pictureBox1.Width = image.Width + minusInterval * kolScroll;
                pictureBox1.Height = image.Height + minusInterval * kolScroll;
                g.DrawImageUnscaled(image, 0, 0);

                Image newImage = pictureBox1.Image;
                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                if (width > 0 && height > 0)
                    pictureBox1.Image = new Bitmap(newImage, width, height);
                //delta -= minusInterval;
            }
            lastValue = trackBar1.Value;
        }

        private void toolStripTextBoxMasshtab_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int m = Convert.ToInt16(toolStripTextBoxMasshtab.Text);
                if (m < 500)
                    minusInterval = -m;
                else
                {
                    minusInterval = -999;
                    toolStripTextBoxMasshtab.Text = "499";
                }
            }
        }

        private void toolStripComboBoxHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxHand.Text == myHands[0])
                leftHand = true;
            else if (toolStripComboBoxHand.Text == myHands[1])
                leftHand = false;
        }

        void SaveAllResult(string human)
        {
            string filename = "";
            switch (human)
            {
                case "Мать":
                    {
                        filename = Application.StartupPath + "\\txt\\mother.txt";
                    }
                    break;
                case "Отец":
                    {
                        filename = Application.StartupPath + "\\txt\\father.txt";
                    }
                    break;
                case "Ребёнок":
                    {
                        filename = Application.StartupPath + "\\txt\\child.txt";
                    }
                    break;
                case "Чужой":
                    {
                        filename = Application.StartupPath + "\\txt\\foreign.txt";
                    }
                    break;
            }
            saveToTxtMan(filename);

            //inStream.Close();
        }

        void saveToTxtMan(string filename)
        {
            StreamWriter outStream;
            //для дописывания в конец файла
            FileInfo fi = new FileInfo(filename);
            outStream = fi.AppendText();
            outStream.WriteLine("");
            outStream.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            outStream.WriteLine("");
            outStream.WriteLine("ЭКСПЕРИМЕНТ №" + GetExpNum().ToString());
            outStream.WriteLine("");
            outStream.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            outStream.WriteLine("");
            outStream.WriteLine("Время начала записи:" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            outStream.WriteLine("Координаты узловых точек:");
            for (int j = 0; j < list1l.Count; j++)
                outStream.WriteLine("большой палец левой руки: " + list1l[j]);
            for (int j = 0; j < list2l.Count; j++)
                outStream.WriteLine("указательный палец левой руки: " + list2l[j]);
            for (int j = 0; j < list3l.Count; j++)
                outStream.WriteLine("средний палец левой руки: " + list3l[j]);
            for (int j = 0; j < list4l.Count; j++)
                outStream.WriteLine("безымянный палец левой руки: " + list4l[j]);
            for (int j = 0; j < list5l.Count; j++)
                outStream.WriteLine("мизинец палец левой руки: " + list5l[j]);
            for (int j = 0; j < list1r.Count; j++)
                outStream.WriteLine("большой палец правой руки: " + list1r[j]);
            for (int j = 0; j < list2r.Count; j++)
                outStream.WriteLine("указательный палец правой руки: " + list2r[j]);
            for (int j = 0; j < list3r.Count; j++)
                outStream.WriteLine("средний палец правой руки: " + list3r[j]);
            for (int j = 0; j < list4r.Count; j++)
                outStream.WriteLine("безымянный палец правой руки: " + list4r[j]);
            for (int j = 0; j < list5r.Count; j++)
                outStream.WriteLine("мизинец палец правой руки: " + list5r[j]);
            outStream.WriteLine("");
            outStream.WriteLine("Длины сторон левой руки:");
            for (int i = 0; i < man.arrFingersLeftHand.Length; i++)
            {
                switch (currentType)
                {
                    case 0: { }
                        break;
                    case 1: { }
                        break;
                    case 2: {
                        outStream.WriteLine("название пальца");
                        outStream.WriteLine(man.arrFingersLeftHand[i].name);
                        outStream.WriteLine("количество пересекаемых линий");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m1kolPerLines);
                        outStream.WriteLine("длина пересекающего отрезка");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m1lengthLine);
                        outStream.WriteLine("");
                        outStream.WriteLine("метод косинуса угла");
                        outStream.WriteLine("длина катета");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m2lengthKatet);
                        outStream.WriteLine("длина гипотенузы");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m2lengthGipotenus);
                        outStream.WriteLine("");
                        outStream.WriteLine("метод отношения косинусов углов");
                        outStream.WriteLine("длина катета для левого угла");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m3lengthKatetLeft);
                        outStream.WriteLine("длина гипотенузы левого угла");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m3lengthGipotenusLeft);
                        outStream.WriteLine("длина катета правого угла");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m3lengthKatetRight);
                        outStream.WriteLine("длина гипотенузы правого угла");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m3lengthGipotenusRight);
                        outStream.WriteLine("");
                        outStream.WriteLine("метод отношения площадей трапеций");
                        outStream.WriteLine("длина нижнего основания обеих трапеций");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthOsnObTrap);
                        outStream.WriteLine("длина правой боковой стороны левой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthRightBokSLeftTrap);
                        outStream.WriteLine("длина верхнего основания левой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthUpLeftTrap);
                        outStream.WriteLine("длина левой боковой стороны левой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthLeftBokSLeftTrap);
                        outStream.WriteLine("длина правой боковой стороны правой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthRightBokSRightTrap);
                        outStream.WriteLine("длина верхнего основания правой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthUpRightTrap);
                        outStream.WriteLine("длина левой боковой стороны правой трапеции");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m4lengthLeftBokSRightTrap);
                        outStream.WriteLine("");
                        outStream.WriteLine("метод отношения площадей треугольников");
                        outStream.WriteLine("длина стороны большого основания ");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m5lengthBigOsn);
                        outStream.WriteLine("длина левой стороны от угла альфа");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m5lengthLeftAlp);
                        outStream.WriteLine("длина меньшего основания");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m5lengthminOsn);
                        outStream.WriteLine("длина стороны справа от бета");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m5lengthRightBeta);
                        outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                        outStream.WriteLine(man.arrFingersLeftHand[i].m5lengthOppositeBeta);
                    }
                        break;
                }
            }
            outStream.WriteLine("");
            outStream.WriteLine("Длины сторон правой руки:");
            for (int i = 0; i < man.arrFingersRightHand.Length; i++)
            {
                switch (currentType)
                {
                    case 0: { }
                        break;
                    case 1: { }
                        break;
                    case 2:
                        {
                            outStream.WriteLine("название пальца");
                            outStream.WriteLine(man.arrFingersRightHand[i].name);
                            outStream.WriteLine("количество пересекаемых линий");
                            outStream.WriteLine(man.arrFingersRightHand[i].m1kolPerLines);
                            outStream.WriteLine("длина пересекающего отрезка");
                            outStream.WriteLine(man.arrFingersRightHand[i].m1lengthLine);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод косинуса угла");
                            outStream.WriteLine("длина катета");
                            outStream.WriteLine(man.arrFingersRightHand[i].m2lengthKatet);
                            outStream.WriteLine("длина гипотенузы");
                            outStream.WriteLine(man.arrFingersRightHand[i].m2lengthGipotenus);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения косинусов углов");
                            outStream.WriteLine("длина катета для левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[i].m3lengthKatetLeft);
                            outStream.WriteLine("длина гипотенузы левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[i].m3lengthGipotenusLeft);
                            outStream.WriteLine("длина катета правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[i].m3lengthKatetRight);
                            outStream.WriteLine("длина гипотенузы правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[i].m3lengthGipotenusRight);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей трапеций");
                            outStream.WriteLine("длина нижнего основания обеих трапеций");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthOsnObTrap);
                            outStream.WriteLine("длина правой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthRightBokSLeftTrap);
                            outStream.WriteLine("длина верхнего основания левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthUpLeftTrap);
                            outStream.WriteLine("длина левой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthLeftBokSLeftTrap);
                            outStream.WriteLine("длина правой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthRightBokSRightTrap);
                            outStream.WriteLine("длина верхнего основания правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthUpRightTrap);
                            outStream.WriteLine("длина левой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[i].m4lengthLeftBokSRightTrap);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей треугольников");
                            outStream.WriteLine("длина стороны большого основания ");
                            outStream.WriteLine(man.arrFingersRightHand[i].m5lengthBigOsn);
                            outStream.WriteLine("длина левой стороны от угла альфа");
                            outStream.WriteLine(man.arrFingersRightHand[i].m5lengthLeftAlp);
                            outStream.WriteLine("длина меньшего основания");
                            outStream.WriteLine(man.arrFingersRightHand[i].m5lengthminOsn);
                            outStream.WriteLine("длина стороны справа от бета");
                            outStream.WriteLine(man.arrFingersRightHand[i].m5lengthRightBeta);
                            outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                            outStream.WriteLine(man.arrFingersRightHand[i].m5lengthOppositeBeta);
                        }
                        break;
                }
                
            }
            outStream.WriteLine("");
            outStream.WriteLine("композиция 1");
            for (int i = 0; i < man.composition.ratio_c1.Length; i++)
            {
                outStream.WriteLine(man.composition.ratio_c1[i]);
            }
            outStream.WriteLine("");
            outStream.WriteLine("композиция 2");
            for (int i = 0; i < man.composition.ratio_c2.Length; i++)
            {
                outStream.WriteLine(man.composition.ratio_c2[i]);
            }
            outStream.WriteLine("");
            outStream.WriteLine("композиция 3");
            for (int i = 0; i < man.composition.ratio_c3.Length; i++)
            {
                outStream.WriteLine(man.composition.ratio_c3[i]);
            }
            outStream.WriteLine("");
            outStream.WriteLine("композиция 4");
            for (int i = 0; i < man.composition.ratio_c4.Length; i++)
            {
                outStream.WriteLine(man.composition.ratio_c4[i]);
            }
            outStream.WriteLine("");
            outStream.WriteLine("композиция 5");
            for (int i = 0; i < man.composition.ratio_c5.Length; i++)
            {
                outStream.WriteLine(man.composition.ratio_c5[i]);
            }
            outStream.WriteLine("");
            outStream.WriteLine("значения для левой руки");
            for (int i = 0; i < man.composition.VALUE_LEFT_HAND.Length; i++)
            {
                outStream.WriteLine(man.composition.VALUE_LEFT_HAND[i]);
            }

            outStream.WriteLine("значения для правой руки");
            for (int i = 0; i < man.composition.VALUE_RIGHT_HAND.Length; i++)
            {
                outStream.WriteLine(man.composition.VALUE_RIGHT_HAND[i]);
            }

            outStream.WriteLine("");
            outStream.WriteLine("Время завершения записи:" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            outStream.WriteLine("");
            outStream.Close();
        }

        void saveToTxtFinger(string filename)
        {
            StreamWriter outStream;
            //для дописывания в конец файла
            FileInfo fi = new FileInfo(filename);
            outStream = fi.AppendText();
            outStream.WriteLine("");
            outStream.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            outStream.WriteLine("");
            outStream.WriteLine("ЭКСПЕРИМЕНТ №" + GetExpNum().ToString());
            outStream.WriteLine("");
            outStream.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            outStream.WriteLine("");
            outStream.WriteLine("Время начала записи:" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            outStream.WriteLine("");
            outStream.WriteLine("Анализируемый субъект:");
            outStream.WriteLine(currentMan);
            outStream.WriteLine("");
            outStream.WriteLine("Координаты узловых точек:");

            int currentFinger = toolStripComboBoxFingers.SelectedIndex;
            string hand = currentHand();
            switch (hand)
            {
                case "левая":{
                    switch (GetFinger(currentFinger))
                    {
                        case "Большой": for (int j = 0; j < list1l.Count; j++)
                outStream.WriteLine("большой палец левой руки: " + list1l[j]);
                            break;
                        case "Указательный": for (int j = 0; j < list2l.Count; j++)
                outStream.WriteLine("указательный палец левой руки: " + list2l[j]);
                            break;
                        case "Средний": for (int j = 0; j < list3l.Count; j++)
                outStream.WriteLine("средний палец левой руки: " + list3l[j]);
                            break;
                        case "Безымянный": for (int j = 0; j < list4l.Count; j++)
                outStream.WriteLine("безымянный палец левой руки: " + list4l[j]);
                            break;
                        case "Мизинец": for (int j = 0; j < list5l.Count; j++)
                outStream.WriteLine("мизинец палец левой руки: " + list5l[j]);
                            break;
                        default: for (int j = 0; j < list1l.Count; j++)
                outStream.WriteLine("большой палец левой руки: " + list1l[j]);
                            break;
                    }
                }
                break;
                case "правая":{
                    switch (GetFinger(toolStripComboBoxFingers.SelectedIndex))
                    {
                        case "Большой": for (int j = 0; j < list1r.Count; j++)
                outStream.WriteLine("большой палец правой руки: " + list1r[j]);
                            break;
                        case "Указательный": for (int j = 0; j < list2r.Count; j++)
                outStream.WriteLine("указательный палец правой руки: " + list2r[j]);
                            break;
                        case "Средний": for (int j = 0; j < list3r.Count; j++)
                outStream.WriteLine("средний палец правой руки: " + list3r[j]);
                            break;
                        case "Безымянный": for (int j = 0; j < list4r.Count; j++)
                outStream.WriteLine("безымянный палец правой руки: " + list4r[j]);
                            break;
                        case "Мизинец": for (int j = 0; j < list5r.Count; j++)
                outStream.WriteLine("мизинец палец правой руки: " + list5r[j]);
                            break;
                        default: for (int j = 0; j < list1l.Count; j++)
                outStream.WriteLine("большой палец левой руки: " + list1l[j]);
                            break;
                    }
                }
                break;
            }
            setDistance(currentFinger, currentHand());
            switch (hand)
            {
                case "левая":{
                    switch (currentType)
                    {
                        case 0: {
                            outStream.WriteLine("");
                            outStream.WriteLine("Длины сторон левой руки:");
                            outStream.WriteLine("название пальца");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].name);
                            outStream.WriteLine("количество пересекаемых линий");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m1kolPerLines);
                            outStream.WriteLine("длина пересекающего отрезка");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m1lengthLine);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения косинусов углов");
                            outStream.WriteLine("длина катета для левого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthKatetLeft);
                            outStream.WriteLine("длина гипотенузы левого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft);
                            outStream.WriteLine("длина катета правого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthKatetRight);
                            outStream.WriteLine("длина гипотенузы правого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthGipotenusRight);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей треугольников");
                            outStream.WriteLine("длина стороны большого основания ");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthBigOsn);
                            outStream.WriteLine("длина левой стороны от угла альфа");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthLeftAlp);
                            outStream.WriteLine("длина меньшего основания");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthminOsn);
                            outStream.WriteLine("длина стороны справа от бета");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthRightBeta);
                            outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthOppositeBeta);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площади треугольника к площади трапеции");
                            outStream.WriteLine("длина большего основания трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6bottomOsnTrap);
                            outStream.WriteLine("длина правой боковой стороны трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6rightTrap);
                            outStream.WriteLine("длина верхнего основания трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6upOsnTrap);
                            outStream.WriteLine("длина левой боковой стороны трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6leftTrap);
                            outStream.WriteLine("длина правой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6rightTriangle);
                            outStream.WriteLine("длина левой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m6leftTriangle);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площади треугольника к площади эллипса");
                            outStream.WriteLine("длина основания треугольника");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m7osnTriangle);
                            outStream.WriteLine("длина правой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m7rightTriangle);
                            outStream.WriteLine("длина левой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m7leftTriangle);
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m7halfBigHalfAxis);
                            outStream.WriteLine("длина половины большей полуоси эллипса");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m7halfSmallHalfAxis);
                            outStream.WriteLine("");

                            man.SetAllCompositions(currentFinger, hand);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 1");
                                outStream.WriteLine(man.composition.ratio_c1[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 2");
                                outStream.WriteLine(man.composition.ratio_c3[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 3");
                                outStream.WriteLine(man.composition.ratio_c5[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 4");
                                outStream.WriteLine(man.composition.ratio_c6[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 5");
                                outStream.WriteLine(man.composition.ratio_c7[currentFinger]);
                                outStream.WriteLine("");
                        }
                            break;
                        case 1: { }
                            break;
                        case 2: { 
                            outStream.WriteLine("");
                            outStream.WriteLine("Длины сторон левой руки:");
                            outStream.WriteLine("название пальца");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].name);
                            outStream.WriteLine("количество пересекаемых линий");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m1kolPerLines);
                            outStream.WriteLine("длина пересекающего отрезка");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m1lengthLine);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод косинуса угла");
                            outStream.WriteLine("длина катета");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m2lengthKatet);
                            outStream.WriteLine("длина гипотенузы");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m2lengthGipotenus);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения косинусов углов");
                            outStream.WriteLine("длина катета для левого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthKatetLeft);
                            outStream.WriteLine("длина гипотенузы левого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthGipotenusLeft);
                            outStream.WriteLine("длина катета правого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthKatetRight);
                            outStream.WriteLine("длина гипотенузы правого угла");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m3lengthGipotenusRight);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей трапеций");
                            outStream.WriteLine("длина нижнего основания обеих трапеций");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthOsnObTrap);
                            outStream.WriteLine("длина правой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthRightBokSLeftTrap);
                            outStream.WriteLine("длина верхнего основания левой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthUpLeftTrap);
                            outStream.WriteLine("длина левой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthLeftBokSLeftTrap);
                            outStream.WriteLine("длина правой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthRightBokSRightTrap);
                            outStream.WriteLine("длина верхнего основания правой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthUpRightTrap);
                            outStream.WriteLine("длина левой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m4lengthLeftBokSRightTrap);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей треугольников");
                            outStream.WriteLine("длина стороны большого основания ");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthBigOsn);
                            outStream.WriteLine("длина левой стороны от угла альфа");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthLeftAlp);
                            outStream.WriteLine("длина меньшего основания");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthminOsn);
                            outStream.WriteLine("длина стороны справа от бета");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthRightBeta);
                            outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                            outStream.WriteLine(man.arrFingersLeftHand[currentFinger].m5lengthOppositeBeta); 
                            man.SetAllCompositions(currentFinger, hand);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 1");
                            outStream.WriteLine(man.composition.ratio_c1[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 2");
                            outStream.WriteLine(man.composition.ratio_c2[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 3");
                            outStream.WriteLine(man.composition.ratio_c3[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 4");
                            outStream.WriteLine(man.composition.ratio_c4[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 5");
                            outStream.WriteLine(man.composition.ratio_c5[currentFinger]);
                            outStream.WriteLine("");}
                            break;
                           
                    }
                    
                }
                break;
                case "правая":{
                    switch (currentType)
                    {
                        case 0:
                            {
                                outStream.WriteLine("");
                            outStream.WriteLine("Длины сторон левой руки:");
                            outStream.WriteLine("название пальца");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].name);
                            outStream.WriteLine("количество пересекаемых линий");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m1kolPerLines);
                            outStream.WriteLine("длина пересекающего отрезка");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m1lengthLine);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения косинусов углов");
                            outStream.WriteLine("длина катета для левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthKatetLeft);
                            outStream.WriteLine("длина гипотенузы левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthGipotenusLeft);
                            outStream.WriteLine("длина катета правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthKatetRight);
                            outStream.WriteLine("длина гипотенузы правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthGipotenusRight);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей треугольников");
                            outStream.WriteLine("длина стороны большого основания ");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthBigOsn);
                            outStream.WriteLine("длина левой стороны от угла альфа");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthLeftAlp);
                            outStream.WriteLine("длина меньшего основания");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthminOsn);
                            outStream.WriteLine("длина стороны справа от бета");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthRightBeta);
                            outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthOppositeBeta);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площади треугольника к площади трапеции");
                            outStream.WriteLine("длина большего основания трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6bottomOsnTrap);
                            outStream.WriteLine("длина правой боковой стороны трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6rightTrap);
                            outStream.WriteLine("длина верхнего основания трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6upOsnTrap);
                            outStream.WriteLine("длина левой боковой стороны трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6leftTrap);
                            outStream.WriteLine("длина правой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6rightTriangle);
                            outStream.WriteLine("длина левой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m6leftTriangle);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площади треугольника к площади эллипса");
                            outStream.WriteLine("длина основания треугольника");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m7osnTriangle);
                            outStream.WriteLine("длина правой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m7rightTriangle);
                            outStream.WriteLine("длина левой боковой стороны треугольника");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m7leftTriangle);
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m7halfBigHalfAxis);
                            outStream.WriteLine("длина половины большей полуоси эллипса");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m7halfSmallHalfAxis);
                            outStream.WriteLine("");

                            man.SetAllCompositions(currentFinger, hand);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 1");
                                outStream.WriteLine(man.composition.ratio_c1[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 2");
                                outStream.WriteLine(man.composition.ratio_c3[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 3");
                                outStream.WriteLine(man.composition.ratio_c5[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 4");
                                outStream.WriteLine(man.composition.ratio_c6[currentFinger]);
                                outStream.WriteLine("");
                                outStream.WriteLine("композиция 5");
                                outStream.WriteLine(man.composition.ratio_c7[currentFinger]);
                                outStream.WriteLine("");
                            }
                            break;
                        case 1: { 
                        man.SetAllCompositions(currentFinger, hand);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 1");
                            outStream.WriteLine(man.composition.ratio_c1[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 2");
                            outStream.WriteLine(man.composition.ratio_c2[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 3");
                            outStream.WriteLine(man.composition.ratio_c3[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 4");
                            outStream.WriteLine(man.composition.ratio_c4[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 5");
                            outStream.WriteLine(man.composition.ratio_c5[currentFinger]);
                            outStream.WriteLine("");
                        }
                            break;
                        case 2: { 
                            outStream.WriteLine("");
                            outStream.WriteLine("Длины сторон правой руки:");
                            outStream.WriteLine("название пальца");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].name);
                            outStream.WriteLine("количество пересекаемых линий");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m1kolPerLines);
                            outStream.WriteLine("длина пересекающего отрезка");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m1lengthLine);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод косинуса угла");
                            outStream.WriteLine("длина катета");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m2lengthKatet);
                            outStream.WriteLine("длина гипотенузы");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m2lengthGipotenus);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения косинусов углов");
                            outStream.WriteLine("длина катета для левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthKatetLeft);
                            outStream.WriteLine("длина гипотенузы левого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthGipotenusLeft);
                            outStream.WriteLine("длина катета правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthKatetRight);
                            outStream.WriteLine("длина гипотенузы правого угла");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m3lengthGipotenusRight);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей трапеций");
                            outStream.WriteLine("длина нижнего основания обеих трапеций");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthOsnObTrap);
                            outStream.WriteLine("длина правой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthRightBokSLeftTrap);
                            outStream.WriteLine("длина верхнего основания левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthUpLeftTrap);
                            outStream.WriteLine("длина левой боковой стороны левой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthLeftBokSLeftTrap);
                            outStream.WriteLine("длина правой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthRightBokSRightTrap);
                            outStream.WriteLine("длина верхнего основания правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthUpRightTrap);
                            outStream.WriteLine("длина левой боковой стороны правой трапеции");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m4lengthLeftBokSRightTrap);
                            outStream.WriteLine("");
                            outStream.WriteLine("метод отношения площадей треугольников");
                            outStream.WriteLine("длина стороны большого основания ");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthBigOsn);
                            outStream.WriteLine("длина левой стороны от угла альфа");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthLeftAlp);
                            outStream.WriteLine("длина меньшего основания");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthminOsn);
                            outStream.WriteLine("длина стороны справа от бета");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthRightBeta);
                            outStream.WriteLine("длина стороны напротив угла альфа (бета)");
                            outStream.WriteLine(man.arrFingersRightHand[currentFinger].m5lengthOppositeBeta);
                    
                            man.SetAllCompositions(currentFinger, hand);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 1");
                            outStream.WriteLine(man.composition.ratio_c1[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 2");
                            outStream.WriteLine(man.composition.ratio_c2[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 3");
                            outStream.WriteLine(man.composition.ratio_c3[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 4");
                            outStream.WriteLine(man.composition.ratio_c4[currentFinger]);
                            outStream.WriteLine("");
                            outStream.WriteLine("композиция 5");
                            outStream.WriteLine(man.composition.ratio_c5[currentFinger]);
                            outStream.WriteLine("");
                        }
                            break;
                    }
                    
                }
                break;
            }
            
            
            switch (hand)
            {
                case "левая":{
                        outStream.WriteLine("значения для левой руки: "+GetFinger(currentFinger));
                        outStream.WriteLine(man.composition.VALUE_LEFT_HAND[currentFinger]);}
                    break;
                case "правая":{
                        outStream.WriteLine("значения для правой руки: "+GetFinger(currentFinger));
                        outStream.WriteLine(man.composition.VALUE_RIGHT_HAND[currentFinger]);
                }
                    break;
            }
            outStream.WriteLine("");
            outStream.WriteLine("Время завершения записи:" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            outStream.WriteLine("");
            outStream.Close();
        }

        // возвращает номер последнего эксперимента
        int GetExpNum() 
        {
            int i = 0;
            string str = "";
            StreamReader inStream =
              new StreamReader(filekolExp);
            
            while (!inStream.EndOfStream)
            {
                str = inStream.ReadLine();
                if (str != "")
                    i = Convert.ToInt16(str);
            }
            inStream.Close();
            return i;
        }

        //печатает в файл новый порядковый номер эксперимента
        private void WriteNewNumExp()
        {
            int i = GetExpNum();
            StreamWriter outStream =
              new StreamWriter(filekolExp);
            //заменяет предыдущую цифру на новую (во избежание длинных строк в файле)
            outStream.WriteLine(Convert.ToString(i + 1));
            outStream.Close();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            list1l = myRandom();
            list2l = myRandom();
            list3l = myRandom();
            list4l = myRandom();
            list5l = myRandom();

            list1r = myRandom();
            list2r = myRandom();
            list3r = myRandom();
            list4r = myRandom();
            list5r = myRandom();

            Random r = new Random();
            textBoxKolLines.Text = r.Next(20).ToString();
            int currentFinger = toolStripComboBoxFingers.SelectedIndex;
            GraphPane pane = zedGraphControl1.GraphPane;
            for (int i = 0; i < 5; i++ )
                drawMan(i, switchColor(numColor), currentMan, "левая");
            for (int i = 0; i < 5; i++)
                drawMan(i, switchColor(numColor), currentMan, "правая");

            if (numColor < toolStripComboBoxColorLines.Items.Count - 1)
                numColor++;
            else
                numColor = 0;
            pane.XAxis.Title.Text = "Композиции";
            pane.YAxis.Title.Text = "Отношения";
            // Горизонтальная линия на уровне y = 0 рисоваться не будет
            pane.YAxis.MajorGrid.IsZeroLine = false;
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = 1;
            pane.XAxis.Scale.Max = 5;
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 30;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgToPicturebox(listAllImgs[listView1.FocusedItem.Index]);

            //if (!notImg)
            //    if (MessageBox.Show("Cохранить изображение?", "Нажимая \"нет\" вы рискуете потерять плод Вашей кропотливой работы.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
            //    {
            //        MySave();
            //    }
            
            // по идее для каждого из открытых изображений нужно сохранять масштабирование
            //switch (currentMan)
            //{
            //    case "Мать": imgToPicturebox(linkImg1[listView1.FocusedItem.Index]);
            //        break;
            //    case "Отец": imgToPicturebox(linkImg2[listView1.FocusedItem.Index]);
            //        break;
            //    case "Ребёнок": imgToPicturebox(linkImg3[listView1.FocusedItem.Index]);
            //        break;
            //    case "Чужой": imgToPicturebox(linkImg4[listView1.FocusedItem.Index]);
            //        break;
            //    default: imgToPicturebox(linkImg1[listView1.FocusedItem.Index]); // придумать что-нибудь интересное
            //        break;
            //}
            

        }

        private void открытьСразуНесклькоИзображенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kolclicks = 0;
            OpenMoreImg();
        }

        void OpenMoreImg()
        {
            openAllImg = true;
            openImg();
            switch (currentMan)
            {
                case "Мать":
                    {
                        listView1.SmallImageList = imgList1;
                        for (int i = 0; i < imgList1.Images.Count; i++)
                            listView1.Items.Add(listSmalllinkImg1[i], i);
                    }
                    break;
                case "Отец":
                    {
                        listView1.SmallImageList = imgList2;
                        for (int i = 0; i < imgList2.Images.Count; i++)
                            listView1.Items.Add(listSmalllinkImg2[i], i);
                    }
                    break;
                case "Ребёнок":
                    {
                        listView1.SmallImageList = imgList3;
                        for (int i = 0; i < imgList3.Images.Count; i++)
                            listView1.Items.Add(listSmalllinkImg3[i], i);
                    }
                    break;
                case "Чужой":
                    {
                        listView1.SmallImageList = imgList4;
                        for (int i = 0; i < imgList4.Images.Count; i++)
                            listView1.Items.Add(listSmalllinkImg4[i], i);
                    }
                    break;
            }
        }

        // открывает сразу несколько изображений
        void openImg()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            dialog.FileName = "image";
            dialog.DefaultExt = defaultFormat;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {

                        listAllImgs.Add(file);
                        addLinkImg(file);
                        Image img = Image.FromFile(file);
                        switch (currentMan)
                        {
                            case "Мать": imgList1.Images.Add(img);
                                break;
                            case "Отец": imgList2.Images.Add(img);
                                break;
                            case "Ребёнок": imgList3.Images.Add(img);
                                break;
                            case "Чужой": imgList4.Images.Add(img);
                                break;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                        return;
                    }
                }
                imgToPicturebox(dialog.FileNames[dialog.FileNames.Length - 1]);
            }
        }
        // добавляет полный путь к изображению для определенного человека
        void addLinkImg(string ss)
        {
            string s = ss.ToLower();
            switch (currentMan)
            {
                case "Мать": addItem(s, ss, linkImg1);
                    break;
                case "Отец": addItem(s, ss, linkImg2);
                    break;
                case "Ребёнок": addItem(s, ss, linkImg3);
                    break;
                case "Чужой": addItem(s, ss, linkImg4);
                    break;
            }
        }

        // ищет в названиях файлов ключевые символы, чтобы потом проассоциировать с combobox'oм
        void addItem(string s, string ss, string[] linkImg)
        {
            char[] c = new char[100];
            int i;
            while (s.IndexOf("\\") != -1)
            {
                i = s.IndexOf("\\");
                s = s.Substring(i + 1);
            }

            if (s.IndexOf("1") != -1 || s.IndexOf(myFingers[0]) != -1 && s.IndexOf("л ") != -1)
            {
                linkImg[0] = ss;
            }
            else if (s.IndexOf("2") != -1 || s.IndexOf(myFingers[1]) != -1 && s.IndexOf("л ") != -1)
            {
                linkImg[1] = ss;
            }
            else if (s.IndexOf("3") != -1 || s.IndexOf(myFingers[2]) != -1 && s.IndexOf("л ") != -1)
            {
                linkImg[2] = ss;
            }
            else if (s.IndexOf("4") != -1 || s.IndexOf(myFingers[3]) != -1 && s.IndexOf("л ") != -1)
            {
                linkImg[3] = ss;
            }
            else if (s.IndexOf("5") != -1 || s.IndexOf(myFingers[4]) != -1 && s.IndexOf("л ") != -1)
            {
                linkImg[4] = ss;
            }
            if (s.IndexOf("6") != -1 || s.IndexOf(myFingers[0]) != -1 && s.IndexOf("п ") != -1)
            {
                linkImg[5] = ss;
            }
            else if (s.IndexOf("7") != -1 || s.IndexOf(myFingers[1]) != -1 && s.IndexOf("п ") != -1)
            {
                linkImg[6] = ss;
            }
            else if (s.IndexOf("8") != -1 || s.IndexOf(myFingers[2]) != -1 && s.IndexOf("п ") != -1)
            {
                linkImg[7] = ss;
            }
            else if (s.IndexOf("9") != -1 || s.IndexOf(myFingers[3]) != -1 && s.IndexOf("п ") != -1)
            {
                linkImg[8] = ss;
            }
            else if (s.IndexOf("10") != -1 || s.IndexOf(myFingers[4]) != -1 && s.IndexOf("п ") != -1)
            {
                linkImg[9] = ss;
            }

            switch (currentMan)
            {
                case "Мать": listSmalllinkImg1.Add(s);
                    break;
                case "Отец": listSmalllinkImg2.Add(s);
                    break;
                case "Ребёнок": listSmalllinkImg3.Add(s);
                    break;
                case "Чужой": listSmalllinkImg4.Add(s);
                    break;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            fastGraph = false;
            listDowloads.Clear();
            MyClear();
            //myCurve1.Clear();
            //myCurve2.Clear();
            //myCurve3.Clear();
            //myCurve4.Clear();
            listPP1.Clear();
            listPP2.Clear();
            listPP3.Clear();
            listPP4.Clear();
            listLog.Clear();
            listSmalllinkImg1.Clear();
            listSmalllinkImg2.Clear();
            listSmalllinkImg3.Clear();
            listSmalllinkImg4.Clear();
            imgList1.Images.Clear();
            imgList2.Images.Clear();
            imgList3.Images.Clear();
            imgList4.Images.Clear();

            pictureBox1.Cursor = Cursors.SizeAll;

            toolStripStatusLabelRegime.Text = regimes[0];

            radioButtonImg.Checked = true;

            radioButtonM.Checked = true;
            textBoxKolLines.Text = "";

            toolStripStatusLabelKolPoints.Text = "| " + 0.ToString();
            SetError("");
            listLog.Add("__________________________________________________________________________");
            listLog.Add(DateTime.Now.ToString());

            firstSecondPoints[0] = new Point(0, 0);
            firstSecondPoints[1] = new Point(0, 0);

            pictureBox1.Image = null;
            pictureBox1.Invalidate(); 
            listView1.Clear();

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (MessageBox.Show("Не сохранять изображение?", "Нажимая \"нет\" вы рискуете потерять плод Вашей кропотливой работы.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
            {
                MySave();
            }
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = Application.StartupPath + "\\txt\\_" + toolStripTextBoxfilename.Text + ".txt";
                FileInfo fi = new FileInfo(s);
                fi.Create();
                if (System.IO.File.Exists(s))
                    saveToTxtMan(s);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
                MessageBox.Show("Некорректное имя файла.");
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Build();
            MySaveTxt();
        }

        void MySaveTxt()
        {
            filename = Application.StartupPath + "\\mySavedFiles\\" + numFile.ToString() + ".txt";
            SaveFileDialog savedialog = saveFileDialog1;
            savedialog.Title = "Сохранить как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            savedialog.ShowHelp = true;
            // If selected, save
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // Get the user-selected file name
                string fileName = savedialog.FileName;
                // Get the extension
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                // Save file
                switch (strFilExtn)
                {
                    case "txt":
                        saveToTxtFinger(fileName);
                        break;
                    default:
                        break;
                }
            }
        }


        // ищет необходимые 10 текстовых файлов и создает один с результатами, необходимыми для построения графика для одного человека
        List<double> myBuildFile(string folderName, string mans_name)
        {
            string name = mans_name;
            string[] foundFiles = new string[10];
            for (int i = 0; i < foundFiles.Length; i++)
                foundFiles[i] = "";

            string[] hands = { "л", "п" };
            string[] searchMask = new string[10];
            //для считанных значений
            List<double> listValues = new List<double>();
            try
            {
                // заполняем маску поиска
                for (int i = 0; i < searchMask.Length; i++)
                    if (i < 5)
                        searchMask[i] = hands[0] + " " + myFingers[i].ToLower() + " " + name + ".txt";
                    else
                        searchMask[i] = hands[1] + " " + myFingers[i - 5].ToLower() + " " + name + ".txt";
                DirectoryInfo directiry = new DirectoryInfo(folderName);
                foreach (FileInfo file in directiry.GetFiles("*.txt", SearchOption.AllDirectories)) //Поиск всех текстовых файлов, включая поддиректории
                {
                    for (int i = 0; i < searchMask.Length; i++)
                        if (file.Name.IndexOf(searchMask[i]) != -1)
                            foundFiles[i] = file.Name;
                }

                for (int i = 0; i < foundFiles.Length; i++)
                    if (foundFiles[i] == "")
                        foundFiles[i] = "emptyMan.txt";
                for (int i = 0; i < foundFiles.Length; i++)
                {
                    //открытие существующего файла на чтение
                    StreamReader openedFile = new StreamReader(folderName + foundFiles[i], System.Text.Encoding.UTF8);
                    string s = openedFile.ReadToEnd();
                    string sStart;
                    sStart = "значения для ";

                    string foundValue = s.Substring(s.IndexOf(sStart));
                    foundValue = foundValue.Trim();
                    string num = "";
                    for (int j = 0; j < foundValue.Length; j++)
                    {
                        if (Char.IsDigit(foundValue[j]) || foundValue[j] == ',')
                            num += foundValue[j];
                        if ((foundValue[j] == '\r' || foundValue[j] == '\n') && num != "")
                            j = foundValue.Length;

                    }
                    listValues.Add(Convert.ToDouble(num));
                    openedFile.Close();
                }
                
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
            return listValues;
        }

        private void toolStripTextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void сохранитьИмяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SetAllFoundLists(toolStripTextBoxName.Text);
        }

        private void toolStripTextBoxName_Click(object sender, EventArgs e)
        {
            toolStripTextBoxName.SelectAll();
        }


        private void toolStripTextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetAllFoundLists(toolStripTextBoxName.Text);
                toolStripTextBoxName.Text = "Имя сохранено";
                toolStripTextBoxName.SelectAll();
            }
        }
        int a = 0;
        //записывает все значения из загруженных файлов в массив 
        void SetAllFoundLists(string name)
        {
            List<double> list = new List<double>();
            list = myBuildFile(Application.StartupPath + "\\mySavedFiles\\", name);
            slowBuildGraph(name, list, switchColor(a));
            a++;
            
            
        }

        void slowBuildGraph(string name, List<double> list, Color color)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            PointPairList ppl = new PointPairList();
            for (int i = 0; i < 10; i++)
            {
                ppl.Add(i, list[i]);
            }
            LineItem curve = pane.AddCurve(name, ppl, color, SymbolType.Circle);
        }

        void fastBuildGraph()
        {
            string[] names = { "НовиковаЕВ", "НовиковаЕС", "Пискарев", "Володин" };
            for (int i = 0; i < names.Length; i++)
            {
                List<double> list = new List<double>();
                list = myBuildFile(Application.StartupPath + "\\mySavedFiles\\", names[i]);
                listDowloads.Add(list);
            }

            GraphPane pane = zedGraphControl1.GraphPane;
            PointPairList ppl0 = new PointPairList();
            PointPairList ppl1 = new PointPairList();
            PointPairList ppl2 = new PointPairList();
            PointPairList ppl3 = new PointPairList();

            for (int i = 0; i < 10; i++)
            {
                ppl0.Add(i, listDowloads[0][i]);
                ppl1.Add(i, listDowloads[1][i]);
                ppl2.Add(i, listDowloads[2][i]);
                ppl3.Add(i, listDowloads[3][i]);
            }

            LineItem curve0 = pane.AddCurve(names[0], ppl0, switchColor(1), SymbolType.Circle);
            LineItem curve1 = pane.AddCurve(names[1], ppl1, switchColor(2), SymbolType.Star);
            LineItem curve2 = pane.AddCurve(names[2], ppl2, switchColor(5), SymbolType.Triangle);
            LineItem curve3 = pane.AddCurve(names[3], ppl3, switchColor(7), SymbolType.Square);

            pane.XAxis.Title.Text = "Композиции";
            pane.YAxis.Title.Text = "Отношения";
            // Горизонтальная линия на уровне y = 0 рисоваться не будет
            pane.YAxis.MajorGrid.IsZeroLine = false;
            // Устанавливаем интересующий нас интервал по оси X
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 10;
            // Устанавливаем интересующий нас интервал по оси Y
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 15;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void показатьГрафикиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastBuildGraph();
            fastGraph = true;
            zedGraphControl1.Visible = true;
            toolStripStatusLabelRegime.Text = regimes[2];
        }

        private void toolStripComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentType = toolStripComboBoxType.SelectedIndex;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            fastGraph = true;
            zedGraphControl1.Visible = true;
            toolStripStatusLabelRegime.Text = regimes[2];
        }

        private void vkcompiskarewnikolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://vk.com/piskarew_nikolay");

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FormHelp form = new FormHelp();
            form.Show();
        }

        private void piskarewnikolayramblerruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("piskarew_nikolay@rambler.ru");
        }

        private void iCQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("390247362");
        }

    }
}
