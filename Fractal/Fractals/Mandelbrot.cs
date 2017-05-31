using System;
using System.Drawing;
using System.Windows.Forms;
using Fractal.Utility.Graphics;

namespace Fractal
{
    public class Mandelbrot : abstract_fractal
    {
        Panel panel;
        public Mandelbrot( Form1 form )
        {
            panel = form.panel1;
            g = panel.CreateGraphics();
            panel = form.panel1;
            width = 400;
            height = 300;
            zoom = 1.0;
        }

        public override void draw()
        {
            draw_mandel();
        }

        double xmin = -2.1;
        double xmax = 1;
        double ymin = -1.3;
        double ymax = 1.3;
        double zoom;
        double n = 0.5;

        private void draw_mandel()
        {
            Color[] cs = new Color[256];
            cs = ColorMap.GetColors(5);
            Bitmap bp = new Bitmap(width, height);
            double x, y, x1, y1, xx;

            int looper, s, z = 0;
            double step_x, step_y = 0.0;
            step_x = (xmax - xmin) / width / zoom;
            step_y = (ymax - ymin) / height / zoom;
            x = xmin;

            for (s = 1; s < width; s++)
            {
                y = ymin;
                for (z = 1; z < height; z++)
                {
                    x1 = 0;
                    y1 = 0;
                    looper = 0;
                    while (looper < 100 && Math.Sqrt((x1 * x1) + (y1 * y1)) < 2)
                    {
                        looper++;
                        xx = (x1 * x1) - (y1 * y1) + x;
                        y1 = 2 * x1 * y1 + y;
                        x1 = xx;
                    }
                    double perc = looper / (100.0);
                    int val = ((int)(perc * 255));
                    bp.SetPixel(s, z, cs[val]);
                    y += step_y;
                }
                x += step_x;
            }
            panel.BackgroundImage = bp;
        }

        public override void decrease()
        {
            zoom -= Math.Pow(n, 2);
            n = Math.Pow(n, 2);
            xmin *= zoom;
            xmax *= zoom;
            ymin *= zoom;
            ymax *= zoom;
            draw();

        }

        public override void increase()
        {
            zoom += Math.Pow(n, 2);
            n = Math.Pow(n, 2);
            xmin /= zoom;
            xmax /= zoom;
            ymin /= zoom;
            ymax /= zoom;
            draw();
            move = move / 1.41;
        }

        double move = 1.0;

        public override void up()
        {
            ymin -= move;
            ymax -= move;
            draw();
        }

        public override void down()
        {
            ymin += move;
            ymax += move;
            draw();
        }

        public override void left()
        {
            xmin -= move;
            xmax -= move;
            draw();
        }

        public override void right()
        {
            xmin += move;
            xmax += move;
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
