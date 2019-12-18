using System;
using System.Collections.Generic;
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

namespace mokup1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file_nome = "mokup.txt";

        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = txtName.Text;
            string b = txtSurname.Text;
            var Date = dpDate.SelectedDate.Value;
            if (a == "" || b == "" || Date == null)
                throw new Exception("inserisci i valori mancanti");
            else if (Date > DateTime.Now)
                throw new Exception("non puoi essere nato nel futuro");
            else
                MessageBox.Show($"Benvenuto {a} {b} nato il {Date}");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnPrint.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string a = txtName.Text;
            string b = txtSurname.Text;
            var Date = dpDate.SelectedDate.Value;
            try 
            {
                using (StreamWriter w = new StreamWriter(file_nome, true))
                {
                    w.Write($"{a} {b} {Date}");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "errore", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
    }
}