using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBuilder
{
    class Car
    {
        public Engine CarEngine { get; private set; }
        public Transmission CarTransmission { get; private set; }
        public  Color CarColor { get; private set; }

        public Car()
        {
            this.CarEngine = new Engine();
            this.CarTransmission = new Transmission();
            this.CarColor = new Color();
        }

        public Car(Engine newEngine, Transmission newTransmission, Color newColor)
        {
            this.CarEngine = newEngine;
            this.CarTransmission = newTransmission;
            this.CarColor = newColor;
        }

        public void SwapEngine(Engine newEngine)
        {
            Console.WriteLine("Engine have been changed\n");
            this.CarEngine = newEngine;
        }

        public void PrintCar()
        {
            Console.WriteLine($"Car: \nEngine:{this.CarEngine.ToString()}, \nTransmission:{this.CarTransmission.ToString()}" +
                              $"\nColor:{this.CarColor.ToString()};\n");
        }
    }
}
