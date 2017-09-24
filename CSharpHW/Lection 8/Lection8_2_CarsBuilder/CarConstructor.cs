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
