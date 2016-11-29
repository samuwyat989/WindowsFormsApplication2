using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Graphics g2;
        Bitmap bm;
        int x = 675;
        int y = 50;
        int drop = 115;
        int lineUp = 283;
        int lineDown = 283;
        int lineRight = 330;
        int lineLeft = 330;
        Point[] port = { new Point(305, 132), new Point(355, 132), new Point(345, 152), new Point(315, 152) };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.Black);
            bm = new Bitmap(this.Width, this.Height);
            g2 = Graphics.FromImage(bm);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            g2.Clear(Color.Black);
            g.DrawImage(bm, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pen pen2 = new Pen(Color.Lime);
            pen2.Width = 27;

            for (int i = 0; i <= 314; i++)
            {
                if (i >= 0 && i <= 60)
                {
                    g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                    g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                    g2.DrawLine(Pens.White, 325, 153, 325, 275);
                    g2.DrawLine(Pens.White, 335, 153, 335, 275);
                    g2.DrawPolygon(Pens.White, port);
                    g2.FillRectangle(Brushes.White, x, y, 30, 10);
                    x -= 5;
                    y++;
                    g.DrawImage(bm, 0, 0);
                    g2.Clear(Color.Black);
                }

                else if (i >= 60 && i <= 116)
                {
                    g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                    g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                    g2.DrawLine(Pens.White, 325, 153, 325, 275);
                    g2.DrawLine(Pens.White, 335, 153, 335, 275);
                    g2.DrawPolygon(Pens.White, port);
                    g2.FillRectangle(Brushes.White, x, 110, 30, 10);
                    x--;
                    g.DrawImage(bm, 0, 0);
                    g2.Clear(Color.Black);
                }

                else if (i >= 116 && i <= 202)
                {
                    g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                    g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                    g2.DrawLine(Pens.White, 325, 153, 325, 275);
                    g2.DrawLine(Pens.White, 335, 153, 335, 275);
                    g2.DrawPolygon(Pens.White, port);
                    g2.FillRectangle(Brushes.White, x, 110, 30, 10);
                    g2.FillRectangle(Brushes.White, 327, drop, 7, 7);
                    x--;
                    drop += 2;
                    g.DrawImage(bm, 0, 0);
                    g2.Clear(Color.Black);
                }

                else if (i >= 202 && i <= 314)
                {
                    g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                    g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                    g2.DrawLine(Pens.White, 325, 153, 325, 275);
                    g2.DrawLine(Pens.White, 335, 153, 335, 275);
                    g2.DrawPolygon(Pens.White, port);

                    g2.FillRectangle(Brushes.White, x, y, 30, 10);

                    g2.DrawLine(pen2, 330, 283, lineRight, lineUp);
                    g2.DrawLine(pen2, 330, 283, 330, lineUp);
                    g2.DrawLine(pen2, 330, 283, lineRight, 283);

                    g2.DrawLine(pen2, 330, 283, lineLeft, lineUp);
                    g2.DrawLine(pen2, 330, 283, lineLeft, 283);
                    g2.DrawLine(pen2, 330, 283, lineLeft, lineDown);
                    g2.DrawLine(pen2, 330, 283, 330, lineDown);
                    g2.DrawLine(pen2, 330, 283, lineRight, lineDown);
                    lineUp--;
                    lineRight++;
                    lineLeft--;
                    lineDown++;
                    x -= 3;
                    y--;
                    g.DrawImage(bm, 0, 0);
                    g2.Clear(Color.Black);
                }
                timer1.Stop();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawImage(bm, 0, 0);
        }
    }
}

