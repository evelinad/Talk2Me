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
    /// Interaction logic for ViewAccount.xaml
    /// </summary>
    public partial class ViewAccount : Window
    {
        public Users currentUser { get; set; }
        public ViewAccount()
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
            this.GendertextBox.Text = currentUser.Gender;
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
            this.BirtdatetextBox.Text = currentUser.Birthdate;


        }
    
    }
}
