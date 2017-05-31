using System.Windows.Forms;
using System.Drawing;
using System;

namespace Fractal
{ 
    public class Sierpinski : abstract_fractal
    {
        private double Sierpinski_depth = 5;
        private Pen pen = new Pen(Color.Black);
        Panel panel;

        public Sierpinski( Form1 form)
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
            g.FillRectangle(new SolidBrush(panel.BackColor), 0, 0, panel.Width, panel.Height);

            Triangle triangle = make_first_triangle();
            
            draw_lines(triangle);
            build_Sierpinski_fractal(triangle, 0);
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

        // recursing function
        private void build_Sierpinski_fractal(Triangle triangle, int branch_depth)
        {
            if (branch_depth == (int)Sierpinski_depth)
                return;
            branch_depth++;

            Triangle T, T1, T2, T3;

            T = divide_lines(triangle);

            T1.P1 = triangle.P1;
            T1.P2 = T.P1;
            T1.P3 = T.P3;
            pen.Color = Color.Red;
            build_Sierpinski_fractal(T1, branch_depth);
            
            T2.P1 = triangle.P2;
            T2.P2 = T.P1;
            T2.P3 = T.P2;
            pen.Color = Color.Blue;
            build_Sierpinski_fractal(T2, branch_depth);

            T3.P1 = triangle.P3;
            T3.P2 = T.P3;
            T3.P3 = T.P2;
            pen.Color = Color.Green;
            build_Sierpinski_fractal(T3, branch_depth);
        }

        private Triangle divide_lines(Triangle Tin)
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

        private void draw_lines(Triangle triangle)
        {
            g.DrawLine(pen, triangle.P1, triangle.P2);
            g.DrawLine(pen, triangle.P1, triangle.P3);
            g.DrawLine(pen, triangle.P2, triangle.P3);
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
                width = (int)( width / zoom );
                height = (int)( height / zoom );
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
        }

        public override void terminate()
        {
        }

        public override void config()
        {

        }
    }
}
