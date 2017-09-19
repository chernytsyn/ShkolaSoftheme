using System;

namespace Lection4_3_shapes
{

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class ShapeDescriptor
    {
        public Point[] Points { get; set; }
        public string ShapeType { get; set; }

        public ShapeDescriptor()
        {
            var p = new Point(1,1);
            Point[] ps = new Point[1];
            ps[0] = p;
            this.Points = ps;
            this.ShapeType = "Point";
        }

        public ShapeDescriptor(params Point[] points)
        {
            Point[] ps = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                ps[i] = points[i];
            }
            this.Points = ps;
            this.ShapeType = "Points";
        }

        public ShapeDescriptor(Point p, string shapeType)
        {
            Point[] ps = new Point[1];
            ps[0] = p;
            this.Points = ps;
            this.ShapeType = shapeType;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // ctor without parameters
            var sd = new ShapeDescriptor();
            Console.WriteLine("Ctor without parameters \n");
            Console.WriteLine($"sd point coord x={sd.Points[0].X}, y={sd.Points[0].Y} \n" 
                + $"sd point type : {sd.ShapeType} \n");

            // creating array of point to test ctor with params array 
            var p1 = new Point(1,1);
            var p2 = new Point(2, 2);
            Point[] points = new Point[2];
            points[0] = p1;
            points[1] = p2;

            var sd2 = new ShapeDescriptor(p1, p2); // using ShapeDescriptor(params Point[] points)

            Console.WriteLine("Ctor with array of parameters \n");
            for (int i = 0; i < sd2.Points.Length; i++ )
            {
                Console.WriteLine($"{i}: x={sd2.Points[i].X}, y={sd2.Points[i].Y}");
            }
            Console.WriteLine($"sd2 point type : {sd.ShapeType} \n");

            Console.WriteLine("Ctor with few different parameters \n");
            var sd3 = new ShapeDescriptor(p1,"Super point");
            Console.WriteLine($"sd3 point coord : x={sd3.Points[0].X} , y={sd3.Points[0].Y} \n"
                + $"sd3 point type : {sd3.ShapeType}");

            Console.ReadKey();
        }
    }
}
