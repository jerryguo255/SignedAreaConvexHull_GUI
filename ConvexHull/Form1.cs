using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHull
{
    public partial class Form1 : Form
    {
        private Point _p;
        private Point _firstPoint = new Point(0, 0);
        private Point _pivot;
        private List<Point> _points = new List<Point>();
        private List<Point> _pointsDraw = new List<Point>();
        private List<Point> _convexHullPoints = new List<Point>();
        private bool trigered;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_firstPoint.X != 0)
            {
                
                if (_points.Count != 0)
                {


                    if (trigered)
                    {

                        for (int i = 0; i < _pointsDraw.Count; i++)
                        {
                            if (i == 0)
                            {
                                e.Graphics.DrawLine(new Pen(Color.Red), _firstPoint.X - 5, _firstPoint.Y - 4, _firstPoint.X + 5, _firstPoint.Y + 4);
                                e.Graphics.DrawLine(new Pen(Color.Red), _firstPoint.X - 5, _firstPoint.Y + 4, _firstPoint.X + 5, _firstPoint.Y - 4);
                            }
                            else
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black), _pointsDraw[i].X - 5, _pointsDraw[i].Y - 4, _pointsDraw[i].X + 5, _pointsDraw[i].Y + 4);
                                e.Graphics.DrawLine(new Pen(Color.Black), _pointsDraw[i].X - 5, _pointsDraw[i].Y + 4, _pointsDraw[i].X + 5, _pointsDraw[i].Y - 4);

                               
                            }
                        }
                        _convexHullPoints = ConvexHull(FindPivot(), _points);
                        for (int i = 0; i < _convexHullPoints.Count; i++)
                        {
                            if (i == _convexHullPoints.Count - 1)
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black), _convexHullPoints[i], _convexHullPoints[0]);
                            }
                            else if (i < _convexHullPoints.Count)
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black), _convexHullPoints[i], _convexHullPoints[i + 1]);
                            }

                        }
                    }
                    else
                    {

                        for (int i = 0; i < _pointsDraw.Count; i++)
                        {
                            if (i == 0)
                            { 
                                e.Graphics.DrawLine(new Pen(Color.Red), _firstPoint.X - 5, _firstPoint.Y - 4, _firstPoint.X + 5, _firstPoint.Y + 4);
                                e.Graphics.DrawLine(new Pen(Color.Red), _firstPoint.X - 5, _firstPoint.Y + 4, _firstPoint.X + 5, _firstPoint.Y - 4);
                            }
                            else
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black), _pointsDraw[i].X - 5, _pointsDraw[i].Y - 4, _pointsDraw[i].X + 5, _pointsDraw[i].Y + 4);
                                e.Graphics.DrawLine(new Pen(Color.Black), _pointsDraw[i].X - 5, _pointsDraw[i].Y + 4, _pointsDraw[i].X + 5, _pointsDraw[i].Y - 4);

                                var _povi  = Point.Empty;
                                if (_pointsDraw.Count != 0)
                                {
                                    var a = FindPivot();
                                    if (!Equals(_povi, a))
                                    {
                                        _povi = a;
                                    }
                                }


                                 

                                e.Graphics.DrawLine(new Pen(Color.Black), _povi, _pointsDraw[i]);
                            }
                        }

                    }


                   

                   



                    
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_firstPoint.X == 0)
            {
                _firstPoint.X = e.X;
                _firstPoint.Y = e.Y;
                _points.Add(_firstPoint);
                _pointsDraw.Add(_firstPoint);
            }
            else
            {
                _p.X = e.X;
                _p.Y = e.Y;
                button1.Text = e.X + "|" + e.Y;
                _points.Add(_p);
                _pointsDraw.Add(_p);
            }
            panel1.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var ee = FindPivot();
            button1.Text = ee.X + "|" + ee.Y;
            trigered = true;

            


            panel1.Refresh();
        }





        Point FindPivot()
        {
            Point lowestLeftPoint = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].X == lowestLeftPoint.X  )
                {
                    if (_points[i].Y < lowestLeftPoint.Y)
                    {
                        lowestLeftPoint = _points[i];
                    }
                    
                } else if (_points[i].X < lowestLeftPoint.X)
                {
                    lowestLeftPoint = _points[i];
                }
            }

            //return _points.First(c => c.Y == _points.Max(x => x.Y));

            return lowestLeftPoint;
        }


        List<Point> ConvexHull(Point pivot, List<Point> points)
        {
            List<Point> Hull = new List<Point>();

            points.Remove(pivot);
            var s = new RadialSort(pivot);
            points.Sort(s);
            Hull.Add(pivot);  // first point
            Hull.Add(points[0]); // second point
            points.RemoveAt(0);
            Hull.Add(points[0]);// third point
            points.RemoveAt(0);
            while (points.Count != 0)
            {
                int value = s.SignedArea(Hull[Hull.Count - 2], Hull[Hull.Count - 1], points[0]);
                if (value < 0)
                {
                    Hull.Add(points[0]);
                    points.RemoveAt(0);
                }
                else
                {
                    Hull.RemoveAt(Hull.Count - 1);
                    //Hull.Add(points[0]);
                    // points.RemoveAt(0);
                }
            }
            return Hull;
        }
    }
}
