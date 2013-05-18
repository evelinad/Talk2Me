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
using System.Windows.Shapes;

namespace Talk2Me_login
{
    /// <summary>
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public SendEmailWindow sem;
        public PasswordWindow()
        {
            InitializeComponent();
            this.Focus();
        }

        public void setParrentWindow(SendEmailWindow sem)
        {
            this.sem = sem;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.sem.userpassword = TextBox.Text;
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }
    }
}
