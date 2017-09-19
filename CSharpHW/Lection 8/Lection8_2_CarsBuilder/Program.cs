using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingClasses();
        }

        public static void TestingClasses()
        {
            var engine = new Engine();
            var transmission = new Transmission();
            var color = new Color();

            var car = CarConstructor.Construct(engine, transmission, color);
            car.PrintCar();

            // swapping engine of the car
            CarConstructor.Reconstruct(car,new Engine("modified engine"));
            car.PrintCar();

            Console.ReadKey();
        }
    }
}
