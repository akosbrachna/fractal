using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private abstract_fractal fractal = null;

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (fractal != null) fractal.terminate();
            switch (comboBox1.Text)
            {
                case "Julia":
                    fractal = new Julia( this );
                    break;
                case "Mandelbrot":
                    fractal = new Mandelbrot(this);
                    break;
                case "Sierpinski recursive function":
                    fractal = new Sierpinski(this);
                    break;
                case "Sierpinski object chain":
                    fractal = new Sierpinski_2(this);
                    break;
                case "Koch Snowflake":
                    fractal = new Koch_snowflake(this);
                    break;
                case "Polygon":
                    fractal = new Polygon(this);
                    break;
            }
            fractal.draw();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (fractal == null) return true;

            if (keyData == Keys.Up)
            {
                fractal.up();
                return true;
            }
            if (keyData == Keys.Down)
            {
                fractal.down();
                return true;
            }
            if (keyData == Keys.Left)
            {
                fractal.left();
                return true;
            }
            if (keyData == Keys.Right)
            {
                fractal.right();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int mouse_X;
        private int mouse_Y;

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            fractal.mouse_X = mouse_X;
            fractal.mouse_Y = mouse_Y;
            if (e.Delta > 0)
                fractal.increase();
            else fractal.decrease();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_X = e.Location.X;
            mouse_Y = e.Location.Y;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            fractal.mouse_X = e.Location.X;
            fractal.mouse_Y = e.Location.Y;
            fractal.select();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            fractal.config();
        }
    }
}
