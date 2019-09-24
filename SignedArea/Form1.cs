using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignedArea
{
    public partial class Form1 : Form
    {
        int pointCount = 0;
        Point a;
        Point b;
        Point c;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointCount == 0)
            {
                a.X = e.X;
                a.Y = e.Y;
                pointCount++;

            }
            else if (pointCount == 1)
            {
                b.X = e.X;
                b.Y = e.Y;
                pointCount++;
            }
            else
            {
                c.X = e.X;
                c.Y = e.Y;
                

                int num = SignedArea(a, b, c);


                if (num > 1000)
                {

                    label_out.Text = "Positve "+ num ;
                }
                else if (num < -1000)
                {
                    label_out.Text = "Nagtive " + num;
                }
                else {
                    label_out.Text = "In Line " + num;
                }
             
            }
            panel1.Refresh();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var myColour = Color.Red;
            var myPen = new Pen(myColour);
            if (pointCount >= 1)
            {
                e.Graphics.DrawLine(myPen, a.X - 5, a.Y, a.X + 5, a.Y);


                e.Graphics.DrawLine(myPen, a.X, a.Y - 5, a.X, a.Y + 5);

            }
            if (pointCount >= 2)
            {
                e.Graphics.DrawLine(myPen, b.X - 5, b.Y, b.X + 5, b.Y);


                e.Graphics.DrawLine(myPen, b.X, b.Y - 5, b.X, b.Y + 5);

                myPen.Color = Color.Blue;
                e.Graphics.DrawLine(myPen, a, b);
            }

            if (pointCount >= 2)
            {
                e.Graphics.DrawLine(myPen, c.X - 5, c.Y, c.X + 5, c.Y);


                e.Graphics.DrawLine(myPen, c.X, c.Y - 5, c.X, c.Y + 5);

                myPen.Color = Color.Blue;
                e.Graphics.DrawLine(myPen, a, b);
            }
        }
        
        private int SignedArea(Point a, Point b, Point c) {

            return a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
