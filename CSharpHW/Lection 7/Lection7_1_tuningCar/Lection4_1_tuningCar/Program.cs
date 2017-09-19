using System;

namespace Lection4_1_tuningCar
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Car()
        {
            this.Model = "Toyota";
            this.Color = "Black";
            this.Year = 2017;
        }
        public Car(string model, string color, int year) {
            this.Model = model;
            this.Color = color;
            this.Year = year;
        }

    }
    public static class TuningAtelier
    {
        public static void TuneCar(Car car)
        {
            car.Color = "Red";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            Console.WriteLine("Before tuning");
            Console.WriteLine($"Model : {car.Model}, year : {car.Year}, color : {car.Color}");

            TuningAtelier.TuneCar(car); // using static method of static class TuningAtelier

            Console.WriteLine("After tuning");
            Console.WriteLine($"Model : {car.Model}, year : {car.Year}, color : {car.Color}");

            Console.ReadKey();
        }
    }
}
