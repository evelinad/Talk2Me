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
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    /// 
    public partial class ChatWindow : Window
    {


        public Users conversationPartnerUser;
        public Users currentUser { get; set; }
        private Dictionary<string, string> _mappings = new Dictionary<string, string>();
        
        public ChatWindow()
        {
            InitializeComponent();
            _mappings.Add(@":(", "/sad.gif");
            _mappings.Add(@":)", "/smile.gif");
            _mappings.Add(@":D", "/grin.gif");
            _mappings.Add(@":P", "/toungue.gif");
            _mappings.Add(@";)", "/wink.gif");
            _mappings.Add(@":|", "/straight.gif");
    
        }
        public void setConversationPartnerUser(Users user)
        {
            this.conversationPartnerUser = user;
            if (this.conversationPartnerUser.Status.CompareTo("Available") == 0) ellipse1.Fill = new SolidColorBrush(Colors.Green);
            else ellipse1.Fill = new SolidColorBrush(Colors.LightSlateGray);
        }

        private string GetEmoticonText(string text)
        {
            string match = string.Empty;
            int lowestPosition = text.Length;

            foreach (KeyValuePair<string, string> pair in _mappings)
            {
                if (text.Contains(pair.Key))
                {
                    int newPosition = text.IndexOf(pair.Key);
                    if (newPosition < lowestPosition)
                    {
                        match = pair.Key;
                        lowestPosition = newPosition;
                    }
                }
            }

            return match;

        }
        private void Emoticons(string msg, Paragraph para)
        {
            //try
            //{


            // Paragraph para = new Paragraph { LineHeight = 1 };

            Run r = new Run(msg);

            para.Inlines.Add(r);

            string emoticonText = GetEmoticonText(r.Text);

            //if paragraph does not contains smile only add plain text to richtextbox rtb2
            if (string.IsNullOrEmpty(emoticonText))
            {
                richTextBox1.Document.Blocks.Add(para);
            }
            else
            {
                while (!string.IsNullOrEmpty(emoticonText))
                {

                    TextPointer tp = r.ContentStart;

                    // keep moving the cursor until we find the emoticon text
                    while (!tp.GetTextInRun(LogicalDirection.Forward).StartsWith(emoticonText))

                        tp = tp.GetNextInsertionPosition(LogicalDirection.Forward);

                    // select all of the emoticon text
                    var tr = new TextRange(tp, tp.GetPositionAtOffset(emoticonText.Length)) { Text = string.Empty };

                    //relative path to image smile file
                    string path = _mappings[emoticonText];

                    //System. 
                    try
                    {
                        System.Windows.Controls.Image image = new System.Windows.Controls.Image
                        {
                            Source =
                                new BitmapImage(new System.Uri(Environment.CurrentDirectory + path,
                                                        UriKind.RelativeOrAbsolute)),
                            Width = Height = 20,
                        };

                        //insert smile
                        new InlineUIContainer(image, tp);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                    if (para != null)
                    {
                        var endRun = para.Inlines.LastInline as Run;

                        if (endRun == null)
                        {
                            break;
                        }
                        else
                        {
                            emoticonText = GetEmoticonText(endRun.Text);
                        }

                    }

                }
                richTextBox1.Document.Blocks.Add(para);

            }
        }

        private void SendMessage()
        {


            Paragraph paragraph = new Paragraph();
            paragraph.LineHeight = 1;

            Run name = new Run();
            name.Text = currentUser.FirstName+ " "+ currentUser.LastName  + " : ";
            
            name.Foreground = new SolidColorBrush(Colors.Red);
            paragraph.Inlines.Add(new Bold(name));
            
       //    paragraph.Inlines.Add(new Run(name.text));
           richTextBox1.Document.Blocks.Add(paragraph);
           name = new Run();
           name.Text =  ChattextBox.Text + "";
           paragraph = new Paragraph();
           paragraph.LineHeight = 1;

            Emoticons(name.Text, paragraph);
            richTextBox1.ScrollToEnd();
            this.Focus();

            Message mess = new Message();
            mess.SourceName = currentUser.Username;
            mess.DestinationName = conversationPartnerUser.Username;
            mess.Data = "Sunt prea frumos!";
            byte[] buff = mess.Serialize();
            ClientServerCommunicator.SendData(ClientServerCommunicator.server_socket, buff, 4);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
     //      MessageBox.Show(conversationPartnerUser.FirstName);
            //richTextBox1.AppendText(textBox1.Text + "\r\n");
            
            SendMessage();
            ChattextBox.Clear();
         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SendEmailWindow sem = new SendEmailWindow();
            sem.currenUser = this.currentUser;
            sem.chatPartnerUser = this.conversationPartnerUser;
            sem.Show();
        }
      
    }
}
