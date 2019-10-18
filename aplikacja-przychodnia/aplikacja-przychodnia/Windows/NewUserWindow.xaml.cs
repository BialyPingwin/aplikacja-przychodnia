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
using System.Windows.Shapes;
using aplikacja_przychodnia.Pages;
using aplikacja_przychodnia.Classes;

namespace aplikacja_przychodnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        /// <summary>
        /// Lokalna baza danych użytkowników.
        /// </summary>
        public UserLocalDataBase UserLocalDataBase;
        
        /// <summary>
        /// Kontruktor okna dodawania nowego użytkownika.
        /// </summary>
        public NewUserWindow()
        {
            InitializeComponent();
            UserLocalDataBase = UserLocalDataBase.Initialize();
            KeyDown += TextUpdate;
            KeyUp += TextUpdate;

        }
        private void TextUpdate(object sender, RoutedEventArgs e)
        {

            if (Input_Name.Text == "")
            {
                return;
            }

            char login1 = Input_Name.Text.ToLower()[0];
            string login2 = Input_Surname.Text.ToLower();
            int login3 = 2;

            if (UserLocalDataBase.IsLoginFree(login1 + login2))
            {
                Input_Login.Text = login1 + login2;
                return;
            }
            while (!UserLocalDataBase.IsLoginFree(login1+login2+login3))
            {
                login3++;
            }
            Input_Login.Text = login1 + login2 + login3;
        }

        /// <summary>
        /// Metoda sprawdzająca poprawność wpisanych danych, oraz czy wprowadzony login jest unikatowy.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegClass.CheckFirstName(Input_Name.Text) && RegClass.CheckLastName(Input_Surname.Text))
            {
                if (!UserLocalDataBase.IsLoginFree(Input_Login.Text))
                {
                    Output_Error.Text = "Login zajęty";
                    return;
                }
                if (Input_Name.Text != "" && Input_Surname.Text != "" && Input_Login.Text != "" && UserLocalDataBase.IsLoginFree(Input_Login.Text))
                {

                    User user = new User(Input_Name.Text, Input_Surname.Text, Input_Login.Text, "hasło");
                    UserLocalDataBase.Add(user);
                    UserLocalDataBase.ResetUserPassword(user.login);
                    UserLocalDataBase.Save();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            if ((window as MainWindow).Main.Content is AdminPage)
                            {
                                ((window as MainWindow).Main.Content as AdminPage).RefreshUsersView();
                            }
                        }
                    }

                    this.Close();

                }
                else
                {
                    Output_Error.Text = "Błąd wprowadzania danych";
                }
            }
            else
            {
                MessageBox.Show("Podano złe imię lub nazwisko");
            }
        }
    }
}
