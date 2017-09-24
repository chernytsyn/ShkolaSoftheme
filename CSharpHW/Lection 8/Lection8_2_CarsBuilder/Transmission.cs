namespace CarsBuilder
{
    class Transmission
    {
        public string TransmissionInfo { get; private set; }

        public Transmission()
        {
            this.TransmissionInfo = "default transmission";
        }

        public Transmission(string newTransmission)
        {
            this.TransmissionInfo = newTransmission;
        }
        public override string ToString()
        {
            return this.TransmissionInfo;
        }
    }
}
