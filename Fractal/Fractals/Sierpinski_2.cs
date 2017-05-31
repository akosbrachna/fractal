using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using Fractal.Utility;

namespace Fractal
{
    public class Sierpinski_2 : abstract_fractal
    {
        public List<Sierpinski_obj> coll;
        private double Sierpinski_depth = 5;
        private Pen pen = new Pen(Color.Green);
        Panel panel;
        private Bitmap bp;

        public class Sierpinski_obj
        {
            public Triangle T, T_new;
            public Sierpinski_obj(Triangle T_in, Sierpinski_2 s, int branch_depth)
            { 
                if (branch_depth == (int)s.Sierpinski_depth)
                    return;
                branch_depth++;

                T = s.divide_lines(T_in);

                T_new.P1 = T_in.P1;
                T_new.P2 = T.P1;
                T_new.P3 = T.P3;
                s.pen.Color = Color.Red;
                s.coll.Add(new Sierpinski_obj(T_new, s, branch_depth));

                T_new.P1 = T_in.P2;
                T_new.P2 = T.P1;
                T_new.P3 = T.P2;
                s.pen.Color = Color.Blue;
                s.coll.Add(new Sierpinski_obj(T_new, s, branch_depth));

                T_new.P1 = T_in.P3;
                T_new.P2 = T.P3;
                T_new.P3 = T.P2;
                s.pen.Color = Color.Green;
                s.coll.Add(new Sierpinski_obj(T_new, s, branch_depth));
            }
        }

        public Sierpinski_2(Form1 form)
        {
            panel = form.panel1;
            g = panel.CreateGraphics();
            panel = form.panel1;
            width = panel.Width - 2;
            height = panel.Height - 2;
            X = 0;
            Y = 0;
        }

        public override void draw()
        {
            bp = new Bitmap(panel.Width, panel.Height);
            g = Graphics.FromImage(bp);
            coll = null;
            Triangle triangle = make_first_triangle();
            draw_lines(triangle);
            coll = new List<Sierpinski_obj>();
            coll.Add(new Sierpinski_obj(triangle, this, 0));
            panel.BackgroundImage = bp;
        }

        private Triangle make_first_triangle()
        {
            Triangle triangle;
            triangle.P1 = new Point();
            triangle.P2 = new Point();
            triangle.P3 = new Point();

            triangle.P1.X = (panel.Width / 2) + X;
            triangle.P1.Y = Y;

            triangle.P2.X = triangle.P1.X - (width / 2);
            triangle.P2.Y = triangle.P1.Y + height;

            triangle.P3.X = triangle.P1.X + (width / 2);
            triangle.P3.Y = triangle.P1.Y + height;

            return triangle;
        }

        public Triangle divide_lines(Triangle Tin)
        {
            Triangle Tout;

            Tout.P1 = new Point();
            Tout.P2 = new Point();
            Tout.P3 = new Point();

            Tout.P1.X = (Tin.P1.X + Tin.P2.X) / 2;
            Tout.P1.Y = (Tin.P1.Y + Tin.P2.Y) / 2;

            Tout.P2.X = (Tin.P2.X + Tin.P3.X) / 2;
            Tout.P2.Y = (Tin.P2.Y + Tin.P3.Y) / 2;

            Tout.P3.X = (Tin.P3.X + Tin.P1.X) / 2;
            Tout.P3.Y = (Tin.P3.Y + Tin.P1.Y) / 2;

            draw_lines(Tout);

            return Tout;
        }

        private void draw_lines(Triangle t)
        {
            if (coll != null)
            {
                Point[] points = new Point[] { t.P1, t.P2, t.P3 };
                g.FillPolygon(new SolidBrush(pen.Color), points);
            }
            else
            {
                pen.Width = 3;
                g.DrawLine(pen, t.P1, t.P2);
                g.DrawLine(pen, t.P1, t.P3);
                g.DrawLine(pen, t.P2, t.P3);
            }
        }

        private double zoom = 1.2;
        private double d_depth = 0.2;

        public override void increase()
        {
            if (Sierpinski_depth < 12)
            {
                Sierpinski_depth = Sierpinski_depth + d_depth;
                width = (int)(zoom * width);
                height = (int)(zoom * height);
                draw();
            }
        }

        public override void decrease()
        {
            if (width > 10)
            {
                Sierpinski_depth = Sierpinski_depth - d_depth;
                width = (int)(width / zoom);
                height = (int)(height / zoom);
                draw();
            }
        }

        public override void up()
        {
            Y -= 100;
            draw();
        }

        public override void down()
        {
            Y += 100;
            draw();
        }

        public override void left()
        {
            X -= 100;
            draw();
        }

        public override void right()
        {
            X += 100;
            draw();
        }

        public override void select()
        {
            double pl = 0, ol = 100000.0, l1, l2, l3;
            int obj = 1;
            Point p1, p2, p3;
            Point m  = new Point(mouse_X, mouse_Y);
       
            for (int i = 0; i < coll.Count; i++)
            {
                p1 = coll[i].T.P1;
                p2 = coll[i].T.P2;
                p3 = coll[i].T.P3;

                //if (coll[i].T.P1.Y > m.Y && coll[i].T.P2.Y < m.Y)
                //{
                //    if (coll[i].T.P1.X < m.X && coll[i].T.P3.X > m.X)
                //    {
                        l1 = MyPoint.length(p1, m);
                        l2 = MyPoint.length(p2, m);
                        l3 = MyPoint.length(p3, m);
                        if (l1 < l2) pl = l1; else pl = l2;
                        if (l3 < pl) pl = l3;
                        if (pl < ol)
                        {
                            ol = pl;
                            obj = i;
                        }
                //    }
                //}
            }
            pen.Color = Color.Black;
            draw_lines(coll[obj].T);
            panel.Refresh();
        }

        public override void terminate()
        {
        }

        public override void config()
        {
        }
    }
}
