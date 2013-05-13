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
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
       public  Users user;
        public ClientWindow()
        {
           
            InitializeComponent();
           
        }
        public void setUser(Users user)
        {
            this.user = user;
           
            hellouser.Text = "Hi, " + user.FirstName;
            comboBox1.Text = user.Status;
            //Label Height="40" HorizontalAlignment="Center" Width="234" FontWeight="ExtraBold" Content="Friends" Name="friends"
            Label newlabel = new Label();
            newlabel.Height = 40;
            newlabel.HorizontalAlignment = HorizontalAlignment.Center;
            newlabel.Width = 234;
            newlabel.FontWeight = FontWeights.ExtraBold;
            newlabel.Content = "ceva";
            listBox1.Items.Add(newlabel);
        }
    }
}
