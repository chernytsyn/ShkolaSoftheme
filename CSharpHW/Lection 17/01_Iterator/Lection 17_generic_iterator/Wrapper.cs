namespace Lection_17_generic_iterator
{
    class Wrapper
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        public Wrapper()
            :this("default name",0)
        {  }
        public Wrapper(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
        public override string ToString()
        {
            return Name + ", value = " + Value;
        }
    }
}
