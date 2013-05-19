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
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel;

namespace Talk2Me_admin
{
    /// <summary>
    /// Interaction logic for TechnicalSupport.xaml
    /// </summary>
    public partial class TechnicalSupport : Window
    {
        Label selectedlabel;
        List<string> user_list;
        public TechnicalSupport()
        {
            InitializeComponent();

          //  dataGrid1.ItemsSource = new ObservableCollection<Object[]>();
           // dataGrid1.ItemsSource.
           
           
            user_list = new List<string>();
            ConnSQL connSQL = new ConnSQL();

            string users = connSQL.getUsers();
            listBox1.Items.Clear();
            string[] str = null;// user.GroupsFriends;
            string delimit = "|";
            Label newlabel;
            str = users.Split(delimit.ToCharArray());
            for (int i = 0; i < str.Length; i++)
            {

                newlabel = new Label();
                newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                newlabel.FontSize = 14;
                newlabel.Content = str[i];
                newlabel.ContextMenu = new ContextMenu();
                MenuItem mi = new MenuItem();
                mi.Header = "Remove user";
                mi.Click += new RoutedEventHandler(MiRemoveUser_Click);
                newlabel.ContextMenu.Items.Add(mi);
                newlabel.Height = 40;
                newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                newlabel.Width = 234;
                newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);   
                listBox1.Items.Add(newlabel);
                user_list.Add(str[i]);

            }

        }
        public void updateContactListBox()
        {
            listBox1.Items.Clear();
        
            
            Label newlabel;
           
            for (int i = 0; i < user_list.Count; i++)
            {

                newlabel = new Label();
                newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                newlabel.FontSize = 14;
                newlabel.Content = user_list[i];
                newlabel.ContextMenu = new ContextMenu();
                MenuItem mi = new MenuItem();
                mi.Header = "Remove user";
                mi.Click += new RoutedEventHandler(MiRemoveUser_Click);
                newlabel.ContextMenu.Items.Add(mi);
                newlabel.Height = 40;
                newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                newlabel.Width = 234;
                newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);
                listBox1.Items.Add(newlabel);
            }
            
        }
       
        void newlabel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.selectedlabel = (Label)sender;

            //MessageBox.Show(this.selectedlabel.Content.ToString());
        }

        void MiRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            
            ConnSQL connSQL = new ConnSQL();


            connSQL.deleteUser(this.selectedlabel.Content.ToString());
            user_list.Remove(this.selectedlabel.Content.ToString());
            updateContactListBox();

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (textBox1.Text != "")
            {

                listBox1.Items.Clear();


                Label newlabel;

                for (int i = 0; i < user_list.Count; i++)
                {
                    if(user_list[i].Contains(textBox1.Text))
                    {
                    newlabel = new Label();
                    newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                    newlabel.FontSize = 14;
                    newlabel.Content = user_list[i];
                    newlabel.ContextMenu = new ContextMenu();
                    MenuItem mi = new MenuItem();
                    mi.Header = "Remove user";
                    mi.Click += new RoutedEventHandler(MiRemoveUser_Click);
                    newlabel.ContextMenu.Items.Add(mi);
                    newlabel.Height = 40;
                    newlabel.HorizontalAlignment = HorizontalAlignment.Center;
                    newlabel.Width = 234;
                    newlabel.MouseEnter += new MouseEventHandler(newlabel_MouseEnter);
                    listBox1.Items.Add(newlabel);
                   
                    }
                }
            }
             
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            try 
        {
 using (StreamReader sr = new StreamReader("default.txt"))
            {
                String line;
 
 while ((line = sr.ReadLine()) != null) 

                {
                    string delimit= ":";
                    string [] str= line.Split(delimit.ToCharArray());
      dataGrid1.Items.Add(new MyLogs { Date = str[0], Log = str[1] });

                }
            }
        }
 catch (Exception exc) 
        {
            MessageBox.Show(exc.ToString());

        }
    }
        
}

    
    public class MyLogs
    {
        public string Date { set; get; }
        public string Log { set; get; }
    }
}
