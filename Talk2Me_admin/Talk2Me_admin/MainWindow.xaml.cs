using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Talk2Me_admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConnSQL connSQL = new ConnSQL();
            bool success = connSQL.authentication(UsernameTextbox.Text, passwordBox1.Password);
            if (success == true)
            {
                MessageBox.Show("Authentication succeded.", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                TechnicalSupport ts = new TechnicalSupport();
                ts.UsernameTextBlock.Text = UsernameTextbox.Text;
                this.Hide();
                ts.Show();
            }
            else MessageBox.Show("Authentication failed.", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }
}
