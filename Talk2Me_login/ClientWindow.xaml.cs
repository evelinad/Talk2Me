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
    /// 

    public partial class ClientWindow : Window
    {
        public Users user;
        public List<GroupsFriends> list_gf;

        public ClientWindow()
        {
            list_gf = new List<GroupsFriends>();
            InitializeComponent();
         

        }
        
        public void setUser(Users user)
        {
            this.user = user;

            hellouser.Text = "Hi, " + user.FirstName;
            comboBox1.Text = user.Status;
            // MessageBox.Show(user.GroupsFriends);
            string str = user.GroupsFriends;
            string delimit = ",";
            string[] groups = null;
            Label newlabel;
            groups = str.Split(delimit.ToCharArray());
            for (int i = 0; i < groups.Length; i++)
            {
                string group = groups[i];
                delimit = "[] ";
                string[] friends = group.Split(delimit.ToCharArray());
                newlabel = new Label();
                newlabel.Height = 40;
                newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                newlabel.Width = 234;
                newlabel.FontSize = 14;
                newlabel.Foreground = new SolidColorBrush(Colors.Blue);
                GroupsFriends newgf = new GroupsFriends();

                newlabel.FontWeight = FontWeights.ExtraBold;
                newlabel.Content = friends[0];
                newgf.group = friends[0];
                listBox1.Items.Add(newlabel);
                for (int k = 1; k < friends.Length; k++)
                    if (friends[k].CompareTo(" ") != 0 && friends[k].CompareTo("") != 0)
                    {
                       
                        newlabel = new Label();
                        newlabel.Height = 40;
                        newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                        newlabel.Width = 234;
                        
                        newlabel.Content = friends[k];
                        newlabel.MouseLeftButtonUp+= new MouseButtonEventHandler(Label_MouseLeftButtonUp_1);
                        newgf.friends.Add(friends[k]);
                        listBox1.Items.Add(newlabel);
                    }
                list_gf.Add(newgf);
                
            }
            //   MessageBox.Show(groups.Length.ToString());
            //Label Height="40" HorizontalAlignment="Center" Width="234" FontWeight="ExtraBold" Content="Friends" Name="friends"

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Clear();
                List<string> newfr = new List<string>();
                ListItem li = new ListItem();
                Label newlabel;
                for (int i = 0; i < list_gf.Count(); i++)
                {
                    newlabel = new Label();
                    newlabel.Height = 40;
                    newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                    newlabel.Width = 234;
                    newlabel.FontSize = 14;
                    newlabel.Foreground = new SolidColorBrush(Colors.Blue);

                    newlabel.FontWeight = FontWeights.ExtraBold;
                    newlabel.Content = list_gf[i];
                 
                    listBox1.Items.Add(newlabel);

                    for (int j = 0; j < list_gf[i].friends.Count(); j++)
                    {
                        if (list_gf[i].friends[j].Contains(textBox1.Text))
                        {
                            newlabel = new Label();
                            newlabel.Height = 40;
                            newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                            newlabel.Width = 234;
                            newlabel.FontSize = 14;
                            newlabel.Content = list_gf[i].friends[j];
                            newlabel.MouseLeftButtonUp += new MouseButtonEventHandler(Label_MouseLeftButtonUp_1);
                            listBox1.Items.Add(newlabel);
                        }
                    }
                }


            }

        }

        //private void listBox1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{

        //}
        private void label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            
            Label chatPartnerLable = (Label)sender;
            ChatWindow cw = new ChatWindow();

            
            cw.label1.Content = chatPartnerLable.Content.ToString();
            cw.Show();
           
        }
    }
    public class GroupsFriends
    {
        public string group;
        public List<string> friends;
        public GroupsFriends()
        {
            group = "";
            friends = new List<string>();
        }
    }
}
