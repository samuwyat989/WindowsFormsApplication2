///Created on November 29, 2016 by Sam Wyatt
///Unit 4 Summative. Uses loops to display graphics
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
using System.Media; 

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Graphics g; //On-screen graphics associateed with Form
        Graphics g2; //Off-screen graphics associated with the bitmap stored in memory 
        Bitmap bm; //Memory for the off-screen buffer 
        int x = 675; //Starting position of ship, x-axis
        int y = 50; //Starting position of ship, y-axis
        int drop = 115; //Starting position of torpedoe, y-axis
        int lineUp = 283; //Center of circle, y-axis
        int lineDown = 283; //Center of circle, y-axis
        int lineRight = 330; //Center of circle, x-axis
        int lineLeft = 330; //Center of circle, x-axis
        Point[] port = { new Point(305, 132), new Point(355, 132), new Point(345, 152), new Point(315, 152) }; //Shape of the port 
        SoundPlayer sound = new SoundPlayer(Properties.Resources.Explosion_U); //Created sound player for sound effects 
        SoundPlayer sound2 = new SoundPlayer(Properties.Resources.Photon_Torpedo); //Created sound player for sound effects 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch; // Image is not wide enough to fit the screen, this forces it to be
            g = this.CreateGraphics(); //Sets up on-screen graphics
            bm = new Bitmap(this.Width, this.Height); //Sets bit map area to the whole screen
            g2 = Graphics.FromImage(bm); //Sets off-screen graphics to the bit map
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            sound2.Play();
            Font messageT = new Font("Courier New", 20); // Create title font 
            Font messageM = new Font("Courier New", 12); // Create message (paragraph) font
            g.Clear(Color.Black);// Gets rid of background
            g.DrawString("The Mission", messageT, Brushes.Gold, 20, 20);// Draws title
            g.DrawString(
              "The battle station is heavily shielded and carries a"
            + "\nfirepower greater than half the star fleet. It's"
            + "\ndefenses are designed around a direct large-scale"
            + "\nassault. A small one-man fighter should be able to"
            + "\npenetrate the outer defense. The Empire doesn't"
            + "\nconsider a small one-man fighter to be any threat."
            + "\n\nYou are required to maneuver straight down a"
            + "\ntrench and skim the surface. The target area is"
            + "\nonly two meters wide. It's a small thermal exhaust"
            + "\nport, right below the main port. The shaft leads"
            + "\ndirectly to the reactor system. A precise hit will"
            + "\nstart a chain reaction which should destroy the "
            + "\nstation. The shaft is ray-shielded, so you'll have"
            + "\nto use proton torpedoes.", messageM, Brushes.White, 20, 80); // Draws paragraph

            Thread.Sleep(5000); // Pauses for the reader
            sound2.Stop(); // Stops sound
            Thread.Sleep(30000); // Pauses for the reader

            timer1.Enabled = true; //Starts timer 
            g2.Clear(Color.Black); //Clears off-screen graphics 
            g.DrawImage(bm, 0, 0); //Clears on-screen graphics 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pen pen2 = new Pen(Color.Lime); // Creates pen
            pen2.Width = 27; // Sets pen width

            for (int i = 0; i <= 314; i++) //Sets up for loop
            {               
                if (i >= 0 && i <= 60) // For the first 60 ticks of the timer draw death star and make ship move towards it
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

                else if (i >= 60 && i <= 116) // For the next 56 ticks of the timer move the ship across the trench 
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

                else if (i >= 116 && i <= 202) //For the next 86 ticks of the timer contiue moving the ship left and shoot torpedoe
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
                    sound.Play(); // Plays explosion later in program, it is unknown to me how to play it where you want  
                }

                else if (i >= 202 && i <= 314) //For the next 112 ticks of the timer move the ship away from the death star and create explosion 
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
            }

            for (int i = 0; i <= 2; i++) // Make new loop which makes explosion flash 3 times
            {
                g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                g2.DrawLine(Pens.White, 325, 153, 325, 275);
                g2.DrawLine(Pens.White, 335, 153, 335, 275);
                g2.DrawPolygon(Pens.White, port);

                pen2.Color = Color.Black;
                g2.DrawLine(pen2, 330, 283, lineRight, lineUp);
                g2.DrawLine(pen2, 330, 283, 330, lineUp);
                g2.DrawLine(pen2, 330, 283, lineRight, 283);
                g2.DrawLine(pen2, 330, 283, lineLeft, lineUp);
                g2.DrawLine(pen2, 330, 283, lineLeft, 283);
                g2.DrawLine(pen2, 330, 283, lineLeft, lineDown);
                g2.DrawLine(pen2, 330, 283, 330, lineDown);
                g2.DrawLine(pen2, 330, 283, lineRight, lineDown);
                g.DrawImage(bm, 0, 0);
                g2.Clear(Color.Black);

                Thread.Sleep(500);

                g2.DrawEllipse(Pens.White, 180, 130, 300, 300);
                g2.DrawEllipse(Pens.White, 322, 275, 16, 16);
                g2.DrawLine(Pens.White, 325, 153, 325, 275);
                g2.DrawLine(Pens.White, 335, 153, 335, 275);
                g2.DrawPolygon(Pens.White, port);

                pen2.Color = Color.Lime;
                g2.DrawLine(pen2, 330, 283, lineRight, lineUp);
                g2.DrawLine(pen2, 330, 283, 330, lineUp);
                g2.DrawLine(pen2, 330, 283, lineRight, 283);
                g2.DrawLine(pen2, 330, 283, lineLeft, lineUp);
                g2.DrawLine(pen2, 330, 283, lineLeft, 283);
                g2.DrawLine(pen2, 330, 283, lineLeft, lineDown);
                g2.DrawLine(pen2, 330, 283, 330, lineDown);
                g2.DrawLine(pen2, 330, 283, lineRight, lineDown);
                g.DrawImage(bm, 0, 0);
                g2.Clear(Color.Black);
                Thread.Sleep(500);
            }
            timer1.Stop(); // Stop timer to stop animations 
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawImage(bm, 0, 0); //Display in paint for smooth graphics 
        }
    }
}

