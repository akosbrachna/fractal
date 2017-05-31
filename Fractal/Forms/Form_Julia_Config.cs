using System;
using System.Windows.Forms;

namespace Fractal.Forms
{
    public partial class Form_Julia_Config : Form
    {
        private Fractal.Julia julia;

        public Form_Julia_Config(Fractal.Julia jule)
        {
            julia = jule;
            InitializeComponent();

            txt_real.Text = julia.cRe.ToString();
            txt_imaginery.Text = julia.cIm.ToString();
            hsc_real.Value = (int)((julia.cRe * 1000 / 3.0) + 500);
            hsc_imaginery.Value = (int)((julia.cIm * 1000 / 3.0) + 500);
            txt_width.Text = julia.w.ToString();
            txt_height.Text = julia.h.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double.TryParse(txt_real.Text, out julia.cRe);
            Double.TryParse(txt_imaginery.Text, out julia.cIm);
            int.TryParse(txt_width.Text, out julia.w);
            int.TryParse(txt_width.Text, out julia.h);
            hsc_real.Value = (int)((julia.cRe * 1000 / 3.0) + 500);
            hsc_imaginery.Value = (int)((julia.cIm * 1000 / 3.0) + 500);
            if (julia.h > 600 || julia.w > 600 || julia.h < 100 || julia.w < 100)
            {
                MessageBox.Show("Please choose width and height values between 100 and 600.");
                return;
            }
            julia.draw();
        }

        private void hsc_real_Scroll(object sender, ScrollEventArgs e)
        {
            julia.cRe = 3.0 * (hsc_real.Value - 500)/1000;
            txt_real.Text = julia.cRe.ToString();
            julia.draw();
        }

        private void hsc_imaginery_Scroll(object sender, ScrollEventArgs e)
        {
            julia.cIm = 3.0 * (hsc_imaginery.Value - 500) / 1000;
            txt_imaginery.Text = julia.cIm.ToString();
            julia.draw();
        }
    }
}
