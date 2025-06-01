﻿namespace PointForSIgn
{
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"x = {X}, y = {Y}";
        }
    }
}