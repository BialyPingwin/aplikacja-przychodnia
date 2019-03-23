using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy NewPasswordPage.xaml
    /// </summary>
    public partial class NewPasswordPage : Page
    {
        UserClass user = null;
        public LocalDataBase localDataBase;

        public NewPasswordPage()
        {
            localDataBase = new LocalDataBase();
            InitializeComponent();
        }
        public NewPasswordPage(UserClass user)
        {
            localDataBase = LocalDataBase.Initialize();
            this.user = user;
            InitializeComponent();
        }


        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (Input_Password1.Password != null && Input_Password1.Password == Input_Password2.Password && Input_Password1.Password.Length >= 4)
            {

                if (user == null)
                {
                    UserClass admin = new UserClass("admin", "admin", "admin", Input_Password1.Password);
                    localDataBase.Add(admin);
                    localDataBase.Save();
                }
                else
                {
                    localDataBase.ChangePassword(user.login, Input_Password1.Password);
                    localDataBase.Save();
                }

                NavigationService.Navigate(new AdminPage());
            }
            else if (Input_Password1.Password.Length < 4)
            {
                Output_Error.Text = "Hasło musi mieć minimalną długość 4 znaków";
            }
            else
            {
                Output_Error.Text = "Podane hasła nie zgadzają się";
            }
        }
    }
}
