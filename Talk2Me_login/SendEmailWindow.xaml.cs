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
    /// Interaction logic for SendEmailWindow.xaml
    /// </summary>
    public partial class SendEmailWindow : Window
    {
        public Users currenUser { get; set; }
        public Users chatPartnerUser { get; set; }
        public string userpassword = "";
        public SendEmailWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox1.Password.CompareTo("") != 0)
            {
                try
                {
                    
                    GmailSender.SendMail(currenUser.Email, passwordBox1.Password, ToTextBox.Text, CCTextBox.Text, BCCtextBox.Text, SubjectTextBox.Text, MessageTextBox.Text);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                MessageBox.Show("Please provide your email password", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
