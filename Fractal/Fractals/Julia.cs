using System.Drawing;
using System.Windows.Forms;
using Fractal.Utility.Graphics;
using Fractal.Forms;
using System;

namespace Fractal
{
    public class Julia : abstract_fractal
    {
        Panel panel;
        Form1 form1;

        private Form_Julia_Config config_form;

        public Julia( Form1 form )
        {
            form1 = form;
            form.btn_config.Visible = true;
            panel = form.panel1;
            g = panel.CreateGraphics();
            panel = form.panel1;
        }

        public override void draw()
        {
            draw_julia();
        }

        private double zoom = 1, move_x = 0, move_y = 0;
        public int w = 500, h = 500;
        public double cRe = -0.7, cIm = 0.27015, interval_x, interval_y;
        private int maxIterations = 300;
        
        private void draw_julia()
        {
            MyColor color = new MyColor();
            Color[] cs = new Color[256];
            cs = ColorMap.GetColors(13);
            double newRe, newIm, oldRe, oldIm, Im, step_y, step_x; 
            Bitmap bp = new Bitmap(w, h);
            int i;

            interval_x = 3.0 / zoom;
            if (w >= h) interval_y = (w / h) * interval_x;
            else interval_y = (h / w) * interval_x;

            double origo_x = (interval_x / 2.0) - move_x;
            double origo_y = (interval_y / 2.0) - move_y;
            step_x = interval_x / w;
            step_y = interval_y / h;
            
            for (int y = 0; y < h; y++)
            {
                Im = y * step_y - origo_y;
                for (int x = 0; x < w; x++)
                {
                    newRe = x * step_x - origo_x;
                    newIm = Im;
                    i = 0;
                    while (i < maxIterations)
                    {
                        oldRe = newRe;
                        oldIm = newIm;
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;
                        if ((newRe * newRe + newIm * newIm) > 2) break;
                        i++;
                    }
                    double perc = i / ((double)(maxIterations));
                    int val = ((int)(perc * 255));
                    bp.SetPixel(x, y, cs[val]);
                }
            }

            var graphics = Graphics.FromImage(bp);

            graphics.DrawLine(Pens.Black, w / 2, 0, w / 2, h);
            graphics.DrawLine(Pens.Black, 0, h / 2, w , h / 2);

            panel.BackgroundImage = bp;
            
        }

        public override void decrease()
        {
            zoom /= 2;
            move_x = (4 * mouse_X - 1.5 * w) / (w * zoom);
            move_y = (2 * h - 4 * mouse_Y) / (h * zoom);
            draw();
        }

        public override void increase()
        {
            move_x -= interval_x * (mouse_X / (w*zoom) - 0.5)/zoom;
            move_y -= interval_y * (mouse_Y / (h*zoom) - 0.5)/zoom;
            zoom *= 2;
            //moveX = (4 * mouse_X - 2 * w) / (w * zoom);
            //moveY = (2 * h - 4 * mouse_Y) / (h * zoom);
            draw();
        }

        public override void up()
        {
            move_y += 0.5 / zoom;
            draw();
        }

        public override void down()
        {
            move_y -= 0.5 / zoom;
            draw();
        }

        public override void left()
        {
            move_x += 0.5 / zoom;
            draw();
        }

        public override void right()
        {
            move_x -= 0.5 / zoom;
            draw();
        }

        public override void terminate()
        {
            if (config_form != null)
                config_form.Dispose();
            form1.btn_config.Visible = false;
        }

        public override void config()
        {
            config_form = new Form_Julia_Config(this);
            config_form.Show();
        }

        public override void select()
        {
        }
    }
}
