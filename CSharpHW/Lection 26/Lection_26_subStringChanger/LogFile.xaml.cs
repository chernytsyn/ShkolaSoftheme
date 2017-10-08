using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;


namespace Lection_26_subStringChanger
{
    /// <summary>
    /// Interaction logic for LogFile.xaml
    /// </summary>
    [Serializable]
    public partial class LogFile : Window
    {
        public List<Stats> LogStats { get; private set; }
        const string Path = "log.dat";

        public LogFile()
        {
            InitializeComponent();
            this.LogStats = new List<Stats>();
            LoadFromDatFile();
            this.dataGrid.ItemsSource = LogStats;
        }

        public LogFile(List<Stats> allstats)
        {
            InitializeComponent();
            this.LogStats = new List<Stats>();
            LoadFromDatFile();

            foreach (Stats stat in allstats)
            {
                if (!LogStats.Contains(stat))
                {
                    this.LogStats.Add(stat);
                }
            }
            SerializeToDat();

            this.dataGrid.ItemsSource = LogStats;
        }

        private void SerializeToDat()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, LogStats);
            }
        }

        private void LoadFromDatFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                var newStats = (List<Stats>)formatter.Deserialize(fs);
                this.LogStats = newStats;
            }
        }
    }
}
