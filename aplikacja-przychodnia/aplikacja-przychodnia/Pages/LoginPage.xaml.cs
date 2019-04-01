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
using aplikacja_przychodnia.Pages;

namespace aplikacja_przychodnia
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        // lokalna baza danych lekarzy, zawiera imie, nazwisko, id, Login, hasło
        public LocalDataBase localDataBase;
        private bool firstStart = false;
        //Strona do logowania
        public LoginPage()
        {

            localDataBase = LocalDataBase.Initialize();
            InitializeComponent();
            if (localDataBase == null)
            {
                Output_Error.Text = "Pierwsze uruchomienie";
                firstStart = true;
            }
            
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            User user = null;
            if (!firstStart)
            {
                 user = localDataBase.login(login_input.Text, password_input.Password);
            }
            
            if (firstStart && login_input.Text == "admin" && password_input.Password == "admin")
            {
                NavigationService.Navigate(new NewPasswordPage());
            }
            else if (login_input.Text == "admin" && (user != null))
            {
                NavigationService.Navigate(new AdminPage());
            }
            else if ((user != null) && login_input.Text != "admin")
            {
                
                MainWindow.LogAsUser(user);
                NavigationService.Navigate(new DoctorMenu());
            }
            else
            {
                Output_Error.Text = "Błędny Login lub hasło";
            }
        }
        // kiedy textbox pusty ustawia wartosc domyslna
        private void RestoreValue(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (sender as TextBox);
                if (tb.Text == "")
                {
                    tb.Text = "Login";
                }
            }
            if (sender is PasswordBox)
            {
                PasswordBox tb = (sender as PasswordBox);
                if (tb.Password == "")
                {
                    tb.Password = "Hasło";
                }
            }
        }
        //zaznacza tekst kiedy textbox klikniety
        private void SelectAddress(object sender, RoutedEventArgs e)
        {

            if (sender is TextBox)
            {
                TextBox tb = (sender as TextBox);
                if (tb.Text == "Login")
                {
                    tb.Clear();
                }
                tb.SelectAll();
            }

            if(sender is PasswordBox) 
            {
                PasswordBox tb = (sender as PasswordBox);
                if (tb != null)
                {
                    tb.Clear();
                }
            }
        }
        //sprawia że SelectAddress nie dziala zawsze
        private void SelectivelyIgnoreMouseButton(object sender,
            MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }

    }
}
