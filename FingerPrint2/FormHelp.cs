using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerPrint2
{
    public partial class FormHelp : Form
    {
        string fileImg1 = Application.StartupPath + "\\help\\" + "c1.jpg";
        string fileImg2 = Application.StartupPath + "\\help\\" + "c4.jpg";
        string fileImg3 = Application.StartupPath + "\\help\\" + "c5.jpg";
        
        Size StartSize;
        public FormHelp()
        {
            InitializeComponent();
            StartSize = pictureBox1.Size;

            //pictureBox1.MouseWheel += new MouseEventHandler(MyMouseWhell);
            trackBar1.Value = 0;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
           
        }

        
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                OpenImg(fileImg1);
            }
            else if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                OpenImg(fileImg2);
            }
            else if (radioButton3.Checked)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                OpenImg(fileImg3);
            }
        }

        void OpenImg(string loc)
        {
            Image image = Image.FromFile(loc);
            int width = image.Width;
            int height = image.Height;
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            pictureBox1.Image = new Bitmap(image, width, height);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            
            pictureBox1.Size = new Size(Convert.ToInt16(StartSize.Width / 0.8), Convert.ToInt16(StartSize.Height / 0.8));
        }

        int offsetX = 0;
        int offsetY = 0;
        bool MoveImage;

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
            

            int mx = Convert.ToInt32(e.X);
            int my = Convert.ToInt32(e.Y);

            if (MoveImage)
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
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            OpenImg(fileImg1);
            
        }

        void MyMouseWhell(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pictureBox1.Width = StartSize.Width * e.Delta;
                pictureBox1.Height = StartSize.Height * e.Delta;
            }
            else if (e.Delta == 0)
            { }
            else if (e.Delta < 0)
            {
                pictureBox1.Width = StartSize.Width / e.Delta;
                pictureBox1.Height = StartSize.Height / e.Delta;
            }
        }

        bool isFirstMiddleClick = true;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && isFirstMiddleClick)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                isFirstMiddleClick = false;
            }
            else if (e.Button == MouseButtons.Middle && !isFirstMiddleClick)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                isFirstMiddleClick = true;
            }
        }

        int lastValue = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            Bitmap result = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(result);
            
            int k = 100;
            if (lastValue < trackBar1.Value && trackBar1.Value < trackBar1.Maximum)
            {
                //g.DrawImage(image, 10, 10, image.Width + k, image.Height + k);
                pictureBox1.Width += k;
                pictureBox1.Height += k;
                g.DrawImageUnscaled(image, 0, 0);
            }
            else if (lastValue > trackBar1.Value && trackBar1.Value > trackBar1.Minimum)
            {
                //g.DrawImage(image, 0, 0, image.Width - k, image.Height - k);
                pictureBox1.Width -= k;
                pictureBox1.Height -= k;
                g.DrawImageUnscaled(image, 0, 0);
            }
            lastValue = trackBar1.Value;
        }

    }
}
