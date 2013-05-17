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
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : Window
    {
        
        public Users currentUser { get; set; }
        public UpdateAccount()
        {
            InitializeComponent();
      

        }
        public void initializeFields()
        {
            
            this.UsernametextBox.Text = currentUser.Username;
            this.EmailTextBox.Text = currentUser.Email;
            this.PasswordTextBox.Text = currentUser.Password;
            this.ConfirmPasswordTextBox.Text = currentUser.Password;
            this.FNamTextBox.Text = currentUser.FirstName;
            this.LNameTextBox.Text = currentUser.LastName;
            this.EmailTextBox.Text = currentUser.Email;
            this.BirthplaceTextBox.Text = currentUser.Birtplace;
            this.comboBox1.Text = currentUser.Gender;
            this.NationalityTextBox1.Text = currentUser.Nationality;
            this.CountryTextBox.Text = currentUser.Country;
            this.CurrentCityTextBox.Text = currentUser.CurrentCity;
            this.AddressTextBox.Text = currentUser.Address;
            this.TelephoneTextBox.Text = currentUser.Telephone;
            this.SecretAnswertextBox.Text = currentUser.SecretAnswer;
            this.SecretQuestionTextBox.Text = currentUser.SecretQuestion;
            this.AddressTextBox.Text = currentUser.Address;
            this.PersonalInteresetTextBox.Text = currentUser.PersonalInterest;
            this.EducationTextBox.Text = currentUser.Education;
            this.WorkplaceTextBox.Text = currentUser.Workplace;
            this.LanguagsTextBox.Text = currentUser.Languages;


        }
        void updateUser()
        {
            //this.UsernametextBox.Text = currentUser.Username;
            currentUser.Email=this.EmailTextBox.Text  ;
            currentUser.Password=this.PasswordTextBox.Text ;
            currentUser.Password=this.ConfirmPasswordTextBox.Text  ;
            currentUser.FirstName=this.FNamTextBox.Text ;
             currentUser.LastName=this.LNameTextBox.Text ;
             currentUser.Email=this.EmailTextBox.Text ;
            currentUser.Birtplace=this.BirthplaceTextBox.Text  ;
            currentUser.Gender=this.comboBox1.Text ;
            currentUser.Nationality=this.NationalityTextBox1.Text ;
            currentUser.Country=this.CountryTextBox.Text  ;
            currentUser.CurrentCity=this.CurrentCityTextBox.Text  ;
            currentUser.Address=this.AddressTextBox.Text  ;
            currentUser.Telephone=this.TelephoneTextBox.Text  ;
            currentUser.SecretAnswer=this.SecretAnswertextBox.Text  ;
            currentUser.SecretQuestion=this.SecretQuestionTextBox.Text  ;
            currentUser.Address=this.AddressTextBox.Text ;
            currentUser.PersonalInterest=this.PersonalInteresetTextBox.Text ;
            currentUser.Education=this.EducationTextBox.Text  ;
            currentUser.Workplace=this.EducationTextBox.Text  ;
            currentUser.Languages=this.LanguagsTextBox.Text  ;
            currentUser.Birthdate = (BirtdateDatePicker.SelectedDate.HasValue) ? BirtdateDatePicker.SelectedDate.Value.ToShortDateString() : "";

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
                MessageBox.Show("Password and confirm password textbox must be the same", "Talk2Me", MessageBoxButton.OK, MessageBoxImage.Stop);
            else
            {
                ConnSQL connSQl = new ConnSQL();
                connSQl.deleteUser(currentUser.Username);
                updateUser();
                connSQl.insert(currentUser);
                
            }
        }
    }
}
