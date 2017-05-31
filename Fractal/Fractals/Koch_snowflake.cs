using System.Drawing;
using System.Windows.Forms;
using Fractal.Utility;
using System;

namespace Fractal
{
    public class Koch_snowflake : abstract_fractal
    {
        private double Koch_depth = 3;
        private Pen pen = new Pen(Color.Green);
        Panel panel;

        public class Koch_snowflake_obj
        {
            Point p4, p5, p6;
            public Koch_snowflake_obj(Point p1, Point p2, Koch_snowflake k, int branch_depth)
            {
                Point d = new Point();
                if (branch_depth == (int)k.Koch_depth)
                    return;
                branch_depth++;

                d = MyPoint.sub(p1, p2);
                d = MyPoint.divide_by_scalar(d, 3.0);

                p4 = MyPoint.sub(p1, d);
                p5 = MyPoint.add(p2, d);
                p6 = MyPoint.rotate(d, -120.0);
                p6 = MyPoint.add(p4, p6);

                k.pen.Color = k.panel.BackColor;
                k.pen.Width = 3;
                k.g.DrawLine(k.pen, p4, p5);
                k.pen.Color = Color.Blue;
                k.pen.Width = 1;
                k.g.DrawLine(k.pen, p1, p4);
                k.g.DrawLine(k.pen, p4, p6);
                k.g.DrawLine(k.pen, p5, p6);
                k.g.DrawLine(k.pen, p5, p2);

                new Koch_snowflake_obj(p1, p4, k, branch_depth);
                new Koch_snowflake_obj(p4, p6, k, branch_depth);
                new Koch_snowflake_obj(p6, p5, k, branch_depth);
                new Koch_snowflake_obj(p5, p2, k, branch_depth);
            }
        }

        private Bitmap bp;

        public Koch_snowflake(Form1 form)
        {
            panel = form.panel1;
            g = panel.CreateGraphics();
            panel = form.panel1;
            width = panel.Width/2;
            height = panel.Height/2;
            X = 0;
            Y = 0;
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

        public override void draw()
        {
            bp = new Bitmap(panel.Width, panel.Height);
            g = Graphics.FromImage(bp);
            g.FillRectangle(new SolidBrush(panel.BackColor), 0, 0, panel.Width, panel.Height);
            Triangle t;
            t = make_first_triangle();
            new Koch_snowflake_obj(t.P1, t.P2, this, 0);
            new Koch_snowflake_obj(t.P2, t.P3, this, 0);
            new Koch_snowflake_obj(t.P3, t.P1, this, 0);
            panel.BackgroundImage = bp;
        }

        private double zoom = 1.2;
        private double d_depth = 0.2;

        public override void increase()
        {
            if (Koch_depth < 12)
            {
                Koch_depth = Koch_depth + d_depth;
                width = (int)(zoom * width);
                height = (int)(zoom * height);
                draw();
            }
        }

        public override void decrease()
        {
            if (width > 10)
            {
                Koch_depth = Koch_depth - d_depth;
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
