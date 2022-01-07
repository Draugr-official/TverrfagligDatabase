using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace TverrfagligDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> database = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string device = $"{DeviceLabel.Text} | {NameLabel.Text} | {RoomLabel.Text} | {ReturnDateLabel.Text}";

            Listview.Items.Add(new Label() { Content = device });
            database.Add(device);
        }

        public void ParseSave(string path)
        {
            MainWindow.database = new List<string>();

            string[] saveFile = File.ReadAllLines(path);

            foreach (string line in saveFile)
            {
                MainWindow.database.Add(line);
                Listview.Items.Add(new Label() { Content = line });
            }
        }

        public void SaveFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            File.WriteAllLines(path, MainWindow.database);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Listview.Items.Clear();
            database.Clear();
        }
    }

    class Client
    {
        public string ClientName { get; set; }

        public string PersonName { get; set; }

        public string RoomName { get; set; }

        public string ReturnDate { get; set; }
    }
}
