namespace CarsBuilder
{
    class Engine
    {
        public string EngineType { get; private set; }

        public Engine()
        {
            this.EngineType = "default engine";
        }

        public Engine(string engine)
        {
            this.EngineType = engine;
        }

        public void ChangeEngine(string newEngine)
        {
            this.EngineType = newEngine;
        }
        public override string ToString()
        {
            return this.EngineType;
        }
    }
}
