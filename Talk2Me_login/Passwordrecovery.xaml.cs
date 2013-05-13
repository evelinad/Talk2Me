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
    /// Interaction logic for Passwordrecovery.xaml
    /// </summary>
    public partial class Passwordrecovery : Window
    {
        public Passwordrecovery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConnSQL connSQl = new ConnSQL();
            string result =connSQl.password_recovery(UsernameTextBox.Text, SecretQuestionTextBox.Text, SecretAnswerTextBox.Text);
            if (result!=null)
            {
                string []str =result.Split(',');
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", str[0], "Talk2Me password recovery", "Your password is: "+str[1]);
                MessageBox.Show("An email has been send to your email address.", "Password recovery confirmation ", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
            else
            {
            }
        }
    }
}
