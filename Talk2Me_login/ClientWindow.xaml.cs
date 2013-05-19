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
using System.ComponentModel;
using System.Diagnostics;
namespace Talk2Me_login
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    /// 

    public partial class ClientWindow : Window
    {
        public Users user;
        Label selectedlabel;
        bool firsttime;
        public List<GroupsFriends> list_gf;
        public MainWindow parrentwdw { get; set;}
        bool signout;
        public ClientWindow()
        {
            signout = false;
            firsttime = true;
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
                        newlabel.ContextMenu = new ContextMenu();
                        MenuItem mi = new MenuItem();
                        mi.Header="Remove user";
                        mi.Click+=new RoutedEventHandler(MiRemoveUser_Click);
                        newlabel.ContextMenu.Items.Add(mi);
                        mi = new MenuItem();
                        mi.Header = "View profile";
                        mi.Click += new RoutedEventHandler(MiViewProfile_Click);
                        newlabel.ContextMenu.Items.Add(mi);
                        newlabel.Height = 40;
                        newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                        newlabel.Width = 234;
                        newlabel.ToolTip = "Dorm!";
                        newlabel.Content = friends[k];
                        newlabel.MouseLeftButtonUp+= new MouseButtonEventHandler(Label_MouseLeftButtonUp_1);
                        newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);
                            // new MouseButtonEventHandler(label1_MouseRightButtonDown);
                        
                        newgf.friends.Add(friends[k]);
                        listBox1.Items.Add(newlabel);
                    }
                list_gf.Add(newgf);
                
            }
            //   MessageBox.Show(groups.Length.ToString());
            //Label Height="40" HorizontalAlignment="Center" Width="234" FontWeight="ExtraBold" Content="Friends" Name="friends"

        }

        void newlabel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.selectedlabel = (Label)sender;

            //MessageBox.Show(this.selectedlabel.Content.ToString());
        }

        void MiViewProfile_Click(object sender, RoutedEventArgs e)
        {
            ConnSQL connSQL = new ConnSQL();
            ViewAccount vacc = new ViewAccount();
            Users user = connSQL.getUser(this.selectedlabel.Content.ToString());
            vacc.currentUser = user;
            vacc.initializeFields();
            vacc.Show();
        }

        public void updateContactListBox()
        {
            listBox1.Items.Clear();
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
                        newlabel.ContextMenu = new ContextMenu();
                        MenuItem mi = new MenuItem();
                        mi.Header = "Remove user";
                        mi.Click += new RoutedEventHandler(MiRemoveUser_Click);
                        newlabel.ContextMenu.Items.Add(mi);
                        mi = new MenuItem();
                        mi.Header = "View profile";
                        mi.Click += new RoutedEventHandler(MiViewProfile_Click);
                        newlabel.ContextMenu.Items.Add(mi);
                        newlabel.Height = 40;
                        newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                        newlabel.Width = 234;
                        newlabel.ToolTip = "Dorm!";
                        newlabel.Content = friends[k];
                        newlabel.MouseLeftButtonUp += new MouseButtonEventHandler(Label_MouseLeftButtonUp_1);
                        newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);
                        // new MouseButtonEventHandler(label1_MouseRightButtonDown);

                        newgf.friends.Add(friends[k]);
                        listBox1.Items.Add(newlabel);
                    }
                list_gf.Add(newgf);

            }
        }
        void MiRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.selectedlabel.Content.ToString());
            ConnSQL connSQL = new ConnSQL();

            this.user.GroupsFriends=this.user.GroupsFriends.Replace(this.selectedlabel.Content.ToString(), "");
            MessageBox.Show(this.user.GroupsFriends);
            connSQL.updateGF(user.Username, user.GroupsFriends);
            updateContactListBox();

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
                    newlabel.Content = list_gf[i].group;
                 
                    listBox1.Items.Add(newlabel);

                    for (int j = 0; j < list_gf[i].friends.Count(); j++)
                    {
                        if (list_gf[i].friends[j].Contains(textBox1.Text))
                        {
                            newlabel = new Label();
                            newlabel.ContextMenu = new ContextMenu();
                            MenuItem mi = new MenuItem();
                            mi.Header = "Remove user";
                            mi.Click += new RoutedEventHandler(MiRemoveUser_Click);
                            newlabel.ContextMenu.Items.Add(mi);
                            mi = new MenuItem();
                            mi.Header = "View profile";
                            mi.Click += new RoutedEventHandler(MiViewProfile_Click);
                            newlabel.ContextMenu.Items.Add(mi);
                            newlabel.ToolTip = "Dorm!";
                            
                            newlabel.Height = 40;
                            newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                            newlabel.Width = 234;
                            newlabel.FontSize = 14;
                            newlabel.Content = list_gf[i].friends[j];
                            newlabel.MouseLeftButtonUp += new MouseButtonEventHandler(Label_MouseLeftButtonUp_1);
                            newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);
                            listBox1.Items.Add(newlabel);
                        }
                    }
                }


            }

        }

     
        private void label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
          
           ConnSQL connSQL = new ConnSQL();
           
            Label chatPartnerLable = (Label)sender;
            Users user = connSQL.getUser(chatPartnerLable.Content.ToString());
            
            if (user == null) MessageBox.Show("An error has occurred. You might have accesed a user that does not exist anymore.", "Talk2Me Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            else
            {
                ChatWindow cw = new ChatWindow();
                cw.label1.Content = chatPartnerLable.Content.ToString()+"("+user.FirstName+" "+user.LastName+")";
                cw.currentUser = this.user;
            //    MessageBox.Show(chatPartnerLable.Content.ToString());
                cw.setConversationPartnerUser ( user);
             //   MessageBox.Show(cw.conversationPartnerUser.FirstName);
                cw.Show();
                ClientServerCommunicator.cw = cw;

            }
        }
        protected override void OnClosing( CancelEventArgs e)
        {
            if (signout == false)
            {
                MessageBoxResult msgboxresult = MessageBox.Show("Are you sure you want to exit Talk2Me?", "Talk2Me", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgboxresult == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                    Process.GetCurrentProcess().Kill();
                }
                else e.Cancel = true;
            }
        }
        private void MenuItemSignOut_Click(object sender, RoutedEventArgs e)
        {
            parrentwdw.Show();
            signout = true;
            this.Close();
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgboxresult = MessageBox.Show("Are you sure you want to exit Talk2Me?", "Talk2Me", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (msgboxresult == MessageBoxResult.Yes)
                Application.Current.Shutdown();
          
        }

        private void MenuItemEditContactDetails_Click(object sender, RoutedEventArgs e)
        {
           
            UpdateAccount updateacc ;
            updateacc = new UpdateAccount();
            updateacc.currentUser = this.user;
            updateacc.initializeFields();
            updateacc.Show();


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();

        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBoxTalkToMe about = new AboutBoxTalkToMe();
            about.Show();

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConnSQL connSQL = new ConnSQL();

            connSQL.update(user.Username, (comboBox1.SelectedItem as ComboBoxItem).Content.ToString());
            if ((comboBox1.SelectedItem as ComboBoxItem).Content.ToString().CompareTo("Offline") == 0)
            {

                StateStatus mess = new StateStatus();
                mess.Id = 1;
                mess.State = "Offline";
                mess.Status = "";
                mess.User = user.Username;
                byte[] buff = mess.Serialize();

                ClientServerCommunicator.SendData(ClientServerCommunicator.server_socket, buff, 5);

                parrentwdw.Show();
                signout = true;
                this.Close();
            }

            if ((comboBox1.SelectedItem as ComboBoxItem).Content.ToString().CompareTo("Available") == 0)
            {
                


                StateStatus mess = new StateStatus() ;
                mess.Id = 1;
                mess.State ="Available";
                mess.Status = "";
                mess.User = user.Username;
                byte[] buff = mess.Serialize();

                ClientServerCommunicator.SendData(ClientServerCommunicator.server_socket, buff, 5);
            }


            if ((comboBox1.SelectedItem as ComboBoxItem).Content.ToString().CompareTo("Invisible") == 0)
            {
                

                StateStatus mess = new StateStatus();
                mess.Id = 1;
                mess.State = "Invisible";
                mess.Status = "";
                mess.User = user.Username;
                byte[] buff = mess.Serialize();

                ClientServerCommunicator.SendData(ClientServerCommunicator.server_socket, buff, 5);
            }
        }

        private void label1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }


        private void MenuItemManageContacts_Click(object sender, RoutedEventArgs e)
        {
            Manage_Contacts mc = new Manage_Contacts();
            mc.setUser(this.user); 
            
            mc.setParrentWindow(this);
            mc.SelectGroupComboBox.Text = "Select group";
            mc.Show();
        }

        private void WhatAreYouDoingTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (firsttime == true)
            {
                WhatAreYouDoingTextBox.Text = "";
                WhatAreYouDoingTextBox.FontStyle = FontStyles.Normal;
                WhatAreYouDoingTextBox.Foreground = new SolidColorBrush(Colors.Black);
                firsttime = false;
            }
           
        }

        private void WhatAreYouDoingTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void WhatAreYouDoingTextBox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void WhatAreYouDoingTextBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void WhatAreYouDoingTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (WhatAreYouDoingTextBox.Text.Equals(""))
            {
                WhatAreYouDoingTextBox.Text = "What are you doing?";
                WhatAreYouDoingTextBox.FontStyle = FontStyles.Oblique;
                WhatAreYouDoingTextBox.Foreground = new SolidColorBrush(Colors.Gray);
                firsttime = true;

            }
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
