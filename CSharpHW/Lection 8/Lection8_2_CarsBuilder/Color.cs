namespace CarsBuilder
{
    class Color
    {
        public string CarColor { get; private set; }

        public Color()
        {
            this.CarColor = "black";
        }

        public Color(string newColor)
        {
            this.CarColor = newColor;
        }
        public override string ToString()
        {
            return this.CarColor;
        }
    }
}
