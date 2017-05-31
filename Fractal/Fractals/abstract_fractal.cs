using System.Drawing;

namespace Fractal
{
    public abstract class abstract_fractal
    {
        public int X;
        public int Y;
        public int width;
        public int height;
        public int mouse_X;
        public int mouse_Y;

        public struct Triangle
        {
            public Point P1;
            public Point P2;
            public Point P3;
        }
        protected Graphics g;

        public abstract void draw();
        
        public abstract void increase();
        
        public abstract void decrease();

        public abstract void up();
        public abstract void down();
        public abstract void left();
        public abstract void right();

        public abstract void select();

        public abstract void terminate();

        public abstract void config();
    }
}
