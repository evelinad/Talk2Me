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
    /// Interaction logic for Manage_Contacts.xaml
    /// </summary>
    public partial class Manage_Contacts : Window
    {

        public Users currentUser { get; set; }
        public ClientWindow parrentCW { get; set; }
        public Manage_Contacts()
        {
            InitializeComponent();
        }
        public void setUser(Users user)
        {
            this.currentUser = user;
            SelectGroupComboBox.Items.Clear();
            string str = user.GroupsFriends;
            string delimit = ",";
            string[] groups = null;
            
            groups = str.Split(delimit.ToCharArray());
            for (int i = 0; i < groups.Length; i++)
            {
                string group = groups[i];
                delimit = "[] ";
                string[] friends = group.Split(delimit.ToCharArray());
                SelectGroupComboBox.Items.Add(friends[0]);
               
            }
      
        }
        public void setParrentWindow(ClientWindow cw)
        {
            this.parrentCW = cw;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConnSQL connSQL = new ConnSQL();
            this.currentUser.GroupsFriends += "," + AddGrouptextBox.Text + "[]";
            connSQL.updateGF(this.currentUser.Username, this.currentUser.GroupsFriends);
            parrentCW.user = currentUser;
            parrentCW.updateContactListBox();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string str = currentUser.GroupsFriends;
            string delimit = ",";
            string[] groups = null;

            groups = str.Split(delimit.ToCharArray());
            for (int i = 0; i < groups.Length; i++)
            {
                string group = groups[i];
                delimit = "[] ";

                string[] friends = group.Split(delimit.ToCharArray());
                if (friends[0].CompareTo(RemoveGrouptextBox.Text) == 0)
                {
                    str.Replace(group, "");
                    ConnSQL connSQL = new ConnSQL();
                    this.currentUser.GroupsFriends = str;
                    connSQL.updateGF(this.currentUser.Username, this.currentUser.GroupsFriends);
                    parrentCW.user = currentUser;
                    parrentCW.updateContactListBox();
                }
                break;

            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                MessageBox.Show(SelectGroupComboBox.Text);
                string str = currentUser.GroupsFriends;
                string delimit = ",";
                string[] groups = null;

                groups = str.Split(delimit.ToCharArray());
                int i;
                string[] friends = null;
                string newgroupfriend = "";
                string group = "";
                for (i = 0; i < groups.Length; i++)
                {
                    group = groups[i];
                    delimit = "[] ";

                    friends = group.Split(delimit.ToCharArray());
                    //    newlabel.Content = friends[0];
                    MessageBox.Show(friends[0]);
                    if (SelectGroupComboBox.Text.CompareTo(friends[0]) == 0)
                        break;
                }
                newgroupfriend = friends[0] + "[" + AddContacttextBox.Text;

                for (int k = 1; k < friends.Length - 1; k++)
                {
                    if (friends[k].CompareTo(" ") != 0 && friends[k].CompareTo("") != 0)
                    {


                        newgroupfriend += " " + friends[k];
                    }
                }
                if (friends[friends.Length - 1].CompareTo(" ") != 0 && friends[friends.Length - 1].CompareTo("") != 0)
                {
                    newgroupfriend += friends[friends.Length];

                }


                newgroupfriend += "]";
                ConnSQL connSQL = new ConnSQL();
                this.currentUser.GroupsFriends = this.currentUser.GroupsFriends.Replace(group, newgroupfriend);
                MessageBox.Show(newgroupfriend);
                connSQL.updateGF(this.currentUser.Username, this.currentUser.GroupsFriends);
                parrentCW.user = currentUser;
                parrentCW.updateContactListBox();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(RemoveContacttextBox.Text);
            ConnSQL connSQL = new ConnSQL();

            this.currentUser.GroupsFriends = this.currentUser.GroupsFriends.Replace(RemoveContacttextBox.Text, "");
            MessageBox.Show(this.currentUser.GroupsFriends);
            connSQL.updateGF(currentUser.Username, currentUser.GroupsFriends);
            parrentCW.updateContactListBox();

        }
    }
}
