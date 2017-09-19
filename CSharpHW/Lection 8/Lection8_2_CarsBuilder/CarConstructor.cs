using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CarsBuilder
{
    static class CarConstructor
    {
        public static Car Construct(Engine engine,Transmission transmission, Color color)
        {
            var newCar = new Car(engine, transmission, color);
            return newCar;
        }

        public static void Reconstruct(Car car, Engine newEngine)
        {
            car.SwapEngine(newEngine);
        }
    }
}
