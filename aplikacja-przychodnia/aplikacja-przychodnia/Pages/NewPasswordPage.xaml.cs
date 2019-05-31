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
using aplikacja_przychodnia.Classes;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy NewPasswordPage.xaml
    /// </summary>
    public partial class NewPasswordPage : Page
    {
        User user = null;

        /// <summary>
        /// Lokalna baza danych lekarzy, zawiera imie, nazwisko, id, login, hasło.
        /// </summary>
        UserLocalDataBase UserLocalDataBase;
        Page nextPage;
        bool isAdmin = false;

        /// <summary>
        /// Konstruktor strony nowego hasła.
        /// </summary>
        public NewPasswordPage()
        {
            UserLocalDataBase = new UserLocalDataBase();
            InitializeComponent();
            
        }

        /// <summary>
        /// Konstruktor strony nowego hasła.
        /// </summary>
        /// <param name="user">Argument określający użytkownika.</param>
        /// <param name="isAdmin">Argument określający czy użytkownik ma uprawnienia administratora.</param>
        public NewPasswordPage(User user, bool isAdmin)
        {
            UserLocalDataBase = UserLocalDataBase.Initialize();
            this.user = user;
            InitializeComponent();
            this.isAdmin = isAdmin;
            

        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (RegClass.CheckPassword(Input_Password1.Password))
            {
                if (Input_Password1.Password != null && Input_Password1.Password == Input_Password2.Password && Input_Password1.Password.Length >= 4)
                {

                    if (user == null)
                    {
                        User admin = new User("admin", "admin", "admin", Input_Password1.Password);
                        UserLocalDataBase.Add(admin);
                        UserLocalDataBase.Save();
                        nextPage = new AdminPage();
                    }
                    else
                    {
                        UserLocalDataBase.ChangePassword(user.login, Input_Password1.Password);
                        UserLocalDataBase.Save();
                        user.pendingPasswordChage = false;
                        if (isAdmin)
                        {
                            nextPage = new AdminPage();
                        }
                        else
                        {
                            nextPage = new DoctorMenu();
                        }
                    }

                    NavigationService.Navigate(nextPage);
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
            else
            {
                MessageBox.Show("Hasło musi zawierać :\nCo najmniej jedną małą literę \nCo najmniej jedną dużą literę \nCo najmniej jedną cyfrę\nDługość od 6 do 20 znaków");
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.Input_Password1.Focus();
        }
    }
}
