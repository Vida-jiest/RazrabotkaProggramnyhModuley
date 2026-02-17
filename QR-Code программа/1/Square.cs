using System;

namespace ShapeManagerApp
{
    public class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double Area()
        {
            return Side * Side;
        }

        public string GetShapeInfo()
        {
            return $"Квадрат со стороной {Side}, площадь: {Area():F2}";
        }

        public override string ToString()
        {
            return GetShapeInfo();
        }
    }
}