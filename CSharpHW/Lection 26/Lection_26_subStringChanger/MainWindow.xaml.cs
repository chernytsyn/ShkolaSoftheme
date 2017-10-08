using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;


namespace Lection_26_subStringChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path { get; private set; }
        public string[] AllFilePathes { get; private set; }
        public ConcurrentBag<Stats> AllStats { get; private set; }
        
        public string PreviousValue { get; private set; }
        public string NewValue { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            this.AllStats = new ConcurrentBag<Stats>();
        }

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            this.Path = dialog.SelectedPath;
            this.PathTextBlock.Text = this.Path;
            GetAllFilePathes();
        }

        private void GetAllFilePathes()
        {
            var allPathes = Directory.GetFileSystemEntries(this.Path, "*", SearchOption.AllDirectories);
            var tempPathes = new List<string>();

            foreach (string s in allPathes)
            {
                if (File.Exists(s))
                {
                    tempPathes.Add(s);
                }
            }
            this.AllFilePathes = tempPathes.ToArray();
            ListOfFilesDataGrid.ItemsSource = GetFileNames();
        }

        private string[] GetFileNames()
        {
            var namesArray = new string[this.AllFilePathes.Length];
            for (var i = 0; i < AllFilePathes.Length; i++)
            {
                namesArray[i] = System.IO.Path.GetFileName(AllFilePathes[i]);
            }
            return namesArray;
        }

        private void SubmitChangeButton_Click(object sender, RoutedEventArgs e)
        {
            this.PreviousValue = ValueToEditTextBox.Text;
            this.NewValue = NewValueTextBox.Text;

            var tempList = new List<string>();

            foreach (string path in AllFilePathes)
            {
                if (path.EndsWith(FileTypeTextBox.Text))
                {
                    tempList.Add(path);
                }
            }
            var tempPathes = tempList.ToArray();

            Parallel.For(0, tempPathes.Length, (i, state) => ReplaceAll(tempPathes[i]));

            var window = new LogFile(AllStats.ToList());
        }

        private void ReplaceAll(string path)
        {
            var statsTemp = new List<Stats>();
            var counter = 0;
            var textLine = string.Empty;
            var text = string.Empty;
            string textForReplace = PreviousValue;
            string newValue = NewValue;

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    textLine = sr.ReadLine();
                    text += textLine + Environment.NewLine;
                    counter++;
                    if (textLine.Contains(textForReplace))
                    {
                        statsTemp.Add(new Stats(path,
                                                counter, 
                                                textLine, 
                                                textLine.Replace(textForReplace, newValue)));
                    }
                }
            }
            text = text.Replace(textForReplace, newValue);

            File.WriteAllText(path, text);

            foreach (Stats stat in statsTemp)
            {
                this.AllStats.Add(stat);
            }
        }

        private void textBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (FileTypeTextBox.Text != null)
            {
                SubmitChangeButton.IsEnabled = true;
            }
        }

        private void OpenLogButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new LogFile();
            window.Show();
        }
    }
}
