using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("--------------------");

            List<IShape> shapes = new List<IShape>() {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.5),
                new Square(10),
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("--------------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("--------------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            Console.WriteLine("All circles");
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("--------------------");

            Console.WriteLine("Circles with area < 30");
            IEnumerable<Circle> filteredCircles = shapes.OfType<Circle>().Where(circle => circle.Area < 30);
            foreach (Circle circle in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("--------------------");

            Console.WriteLine("Grouping By Area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            Console.WriteLine(groupByArea.GetType());
            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("--------------------");

            Console.WriteLine("Group By Type");
            var groupByType = shapes.OrderBy(shape => shape.Area).GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("--------------------");


            Console.ReadKey();
        }
    }
}
