using System;
using System.Xml.Serialization;

namespace Lection_26_subStringChanger
{
    [Serializable]
    public class Stats
    {
        [XmlIgnore]
        private DateTime _timeOfChange;
        public string TimeOfChange
        {
            get { return _timeOfChange.ToString("dd-MM-yyyy"); }
            set { _timeOfChange = DateTime.Parse(value); }
        }

        public string Path { get; private set; }
        public int LineNumber { get; private set; }
        public string PreviousValue { get; private set; }
        public string NewValue { get; private set; }

        public Stats()
        { 
        }
        public Stats(string path, int line, string prevValue, string value)
        {
            this.TimeOfChange = DateTime.Now.ToString();
            this.Path = path;
            this.LineNumber = line;
            this.PreviousValue = prevValue;
            this.NewValue = value;
        }
    }
}
