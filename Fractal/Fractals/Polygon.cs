using System;
using System.Drawing;
using System.Windows.Forms;
using Fractal.Utility;

namespace Fractal
{
    public class Polygon : abstract_fractal
    {
        private int size = 100;
        private Point p1 = new Point(), t = new Point(300, 300);
        Pen pen = new Pen(Color.Black);
        private double alfa, rot = 20.0;
        private int n = 3;
        Panel panel;

        public Polygon(Form1 form)
        {
            panel = form.panel1;
            g = panel.CreateGraphics();
            panel = form.panel1;
            p1.X = size;
            p1.Y = 0;
        }

        private void calc()
        {
            Point p2 = new Point();
            Point p3 = new Point();
            double d_angle = 0.0;
            alfa = (360.0 / n);
            p3.X = p1.X;
            p3.Y = p1.Y;

            for (int i = 0; i <= n; i++)
            {
                d_angle = ((i) * (alfa) + rot);
                p2 = MyPoint.rotate(p1, d_angle);
                if (i != 0)
                {
                    g.DrawLine(pen, MyPoint.add(p2, t), MyPoint.add(p3, t));
                }
                p3.X = p2.X;
                p3.Y = p2.Y;
            }
        }

        public override void draw()
        {
            g.FillRectangle(new SolidBrush(panel.BackColor), 0, 0, panel.Width, panel.Height);
            pen.Color = Color.Red;
            pen.Width = 3;
            calc();
        }

        public override void decrease()
        {
            rot -= 5;
            draw();
        }

        public override void increase()
        {
            rot += 5;
            draw();
        }

        public override void left()
        {
            if (size > 10)
            {
                size -= 10;
                p1.X = size;
            }
            draw();
        }

        public override void right()
        {
            if (size < 400)
            {
                size += 10;
                p1.X = size;
            }
            draw();
        }

        public override void up()
        {
            if (n < 20)
            {
                n++;
            }
            draw();
        }

        public override void down()
        {
            if (n > 3)
            {
                n--;
            }
            draw();
        }
        
        public override void terminate()
        {
        }

        public override void config()
        {
        }

        public override void select()
        {
            throw new NotImplementedException();
        }
    }
}
