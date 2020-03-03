using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace Aflevering1WPF
{
 
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        private User p1;

        public MainWindow()
        {

            InitializeComponent();

            p1 = new User("Bo", 55, 30,10);

            users = new ObservableCollection<User>() {
               p1,
                new User("John", 34, 70, 108),
                new User("Ib", 11, 320, 102),
            };
            listBox.ItemsSource = users;
            gridOuter.DataContext = users;

        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {

                string sFileName = openFileDialog.FileName;
                string line;

                System.IO.StreamReader file =
        new System.IO.StreamReader(sFileName);

                while ((line = file.ReadLine()) != null)

                {
                    var splitLine = line.Split(';');
                    users.Add(new User(splitLine[0], int.Parse(splitLine[1]), int.Parse(splitLine[2]), int.Parse(splitLine[3])));
                }
                listBox.ItemsSource = users;

                ListCount.Content = listBox.Items.Count;
                LastUpdate.Content = "Last update:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                file.Close();
            }
            {

            }
        }

        private void updateList_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Refresh();
        }
    }
}
