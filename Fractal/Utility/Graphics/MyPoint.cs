using System;
using System.Drawing;
using System.Numerics;

namespace Fractal.Utility
{
    public static class MyPoint
    {
        public static Point add(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point sub(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point divide_by_scalar(Point p, double scalar)
        {
            return new Point((int)(p.X / scalar), (int)(p.Y / scalar));
        }

        public static Point multiply_by_scalar(Point p, double scalar)
        {
            return new Point((int)(p.X * scalar), (int)(p.Y * scalar));
        }

        public static Point rotate(Point p1, double angle)
        {
            Point p2 = new Point();
            angle = angle * Math.PI / 180.0;
            p2.X = (int)(p1.X * Math.Cos(angle) - p1.Y * Math.Sin(angle));
            p2.Y = (int)(p1.X * Math.Sin(angle) + p1.Y * Math.Cos(angle));
            return p2;
        }

        public static double length(Point p1, Point p2)
        {
            Point p = sub(p1, p2);
            return Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }
    }
}
