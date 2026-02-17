using System;

namespace ShapeManagerApp
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public string GetShapeInfo()
        {
            return $"Круг с радиусом {Radius}, площадь: {Area():F2}";
        }

        public override string ToString()
        {
            return GetShapeInfo();
        }
    }
}