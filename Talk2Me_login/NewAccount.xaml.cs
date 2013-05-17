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
    /// Interaction logic for NewAccount.xaml
    /// </summary>
    public partial class NewAccount : Window
    {
        ConnSQL connSQL;
        public NewAccount()
        {
            InitializeComponent();
            connSQL = new ConnSQL();
            MandatoryLabel.Visibility = MandatoryLabel2.Visibility = MandatoryLabel3.Visibility = MandatoryLabel4.Visibility = Visibility.Hidden;
            
        }

        private void textBox12_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void scrollViewer1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (UsernametextBox.Text == "" || PasswordTextBox.Text == "" || ConfirmPasswordTextBox.Text == "" || EmailTextBox.Text == "")
            {
                MandatoryLabel.Visibility = MandatoryLabel2.Visibility = MandatoryLabel3.Visibility = MandatoryLabel4.Visibility = Visibility.Visible;
                MessageBox.Show("Please complete all mandatory fields.", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
                if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Password and confirm password box must be the same.", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                else
                {
                    Users user = new Users();
                    
                    user.Address = AddressTextBox.Text;
                    user.Birthdate = (BirtdateDatePicker.SelectedDate.HasValue) ? BirtdateDatePicker.SelectedDate.Value.ToShortDateString() : "";
                    user.Birtplace = BirthplaceTextBox.Text;
                    user.Country = CountryTextBox.Text;
                    user.CurrentCity = CurrentCityTextBox.Text;
                    user.Education = EducationTextBox.Text;
                    user.Email = EmailTextBox.Text;
                    user.FirstName = FNamTextBox.Text;
                    user.Gender = (comboBox1.SelectedItem as ComboBoxItem).Content.ToString();
                    user.LastName = LNameTextBox.Text;
                    user.Nationality = NationalityTextBox1.Text;
                    user.Password = PasswordTextBox.Text;
                    user.PersonalInterest = PersonalInteresetTextBox.Text;
                    user.SecretAnswer = SecretAnswertextBox.Text;
                    user.SecretQuestion = SecretQuestionTextBox.Text;
                    user.Status = "Available";
                    user.Telephone = TelephoneTextBox.Text;
                    user.Username = UsernametextBox.Text;
                    user.Workplace = WorkplaceTextBox.Text;
                    user.GroupsFriends = "buddies["+user.Username+"]";
                    connSQL.insert(user);
                    GmailSender.SendMail("dumitrescu.evelina@gmail.com", "Andreia_90", user.Email, "Talk2Me instant messenger", "Hello "+ user.LastName+",\n"+"\tWelcome to Talk2Me !");

                }
        }
    }
}
