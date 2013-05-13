using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace Talk2Me_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AboutBoxTalkToMe aboutbox;
        Help helpform;
        public Users user;
        ConnSQL connSQL;
        public MainWindow()
        {
          
            
            connSQL = new ConnSQL();
            InitializeComponent();
            try
                {
                    string line;
                    System.IO.StreamReader file =
                        new System.IO.StreamReader("conf.txt");
                 
                            line = file.ReadLine();
                            if (line != null)
                            {
                                UsernameTextbox.Text = line;
                                line = file.ReadLine();
                                if (line != null)
                                {
                                    PasswordTextBox.Text = line;
                                    checkBox1.IsChecked = true;
                                    line = file.ReadLine();
                                    if (line != null && line.CompareTo("ok") == 0)
                                    {
                                        checkBox2.IsChecked = true;
                                        user = connSQL.getUser(UsernameTextbox.Text, PasswordTextBox.Text);
                                        if (user != null) MessageBox.Show("Authentication succeded", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                        else MessageBox.Show("Authentication failed", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        if (user != null)
                                        {
                      //                      this.Close();
                                            if (checkBox3.IsChecked == true)
                                            {
                                                connSQL.update(UsernameTextbox.Text, "Invisible");
                                                user.Status = "Invisible";
                                            }
                                            else
                                            {
                                                connSQL.update(UsernameTextbox.Text, "Available");
                                                user.Status = "Available";
                                            }
                                            ClientWindow clientwin = new ClientWindow();
                                            clientwin.setUser(user);
                                           
                                            clientwin.Show();
                                        }
                                    }
                                }
                            }
                        
                    
                    file.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occured:\n" + exc.ToString());
                    GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
                }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            user = connSQL.getUser(UsernameTextbox.Text, PasswordTextBox.Text);
            if (user!=null)
            {
                MessageBox.Show("Autehtication succeded", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (checkBox1.IsChecked==true)
                {
                try
                {
                    string lines = UsernameTextbox.Text + "\n" + PasswordTextBox.Text;
                    System.IO.StreamWriter file = new System.IO.StreamWriter("conf.txt");
                    file.WriteLine(UsernameTextbox.Text);
                    file.WriteLine(PasswordTextBox.Text);
                    if(checkBox2.IsChecked==true)
                        file.WriteLine("ok"); 
                    file.Close();
                    if (checkBox3.IsChecked == true)
                    {
                        connSQL.update(UsernameTextbox.Text, "Invisible");
                        user.Status = "Invisible";
                    }
                    else
                    {
                        connSQL.update(UsernameTextbox.Text, "Available");
                        user.Status = "Available";
                    }
                    //this.Close();
                    
                    
                    ClientWindow clientwin = new ClientWindow();
                    clientwin.setUser( user);
                    
                    clientwin.Show();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occured:\n"+exc.ToString());
                    GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
                }

            }
            }
            else MessageBox.Show("Authentication failed", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            helpform = new Help();
            helpform.Show();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            aboutbox = new AboutBoxTalkToMe();
            aboutbox.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Passwordrecovery pr = new Passwordrecovery();
            pr.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NewAccount newaccount = new NewAccount();
            newaccount.Show();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            checkBox2.IsEnabled = true;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("unchecked");
            try
            {
                string lines ="";
                System.IO.StreamWriter file = new System.IO.StreamWriter("conf.txt");
                file.WriteLine(lines);
                checkBox2.IsChecked = false;
                checkBox2.IsEnabled = false;
                file.Close();
                UsernameTextbox.Text = PasswordTextBox.Text = "";

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured:\n" + exc.ToString());
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", "dumitrescu.evelina@gmail.com", "Error", exc.ToString());
            }
        }
    }
}
