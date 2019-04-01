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
using aplikacja_przychodnia.Windows;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public LocalDataBase localDataBase;

        public AdminPage()
        {
            localDataBase = LocalDataBase.Initialize();
            InitializeComponent();
            UsersView.AutoGenerateColumns = false;
            UsersView.ItemsSource = localDataBase.ReturnList();
        }

        private void ButtonGrid_PasswordReset_Click(object sender, RoutedEventArgs e)
        {
            User user = UsersView.SelectedItem as User;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś pewien, że chcesz zresetować hasło użytkownika?", "Potwierdzenie resetu hasła użytkownika", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (user.login != "admin")
                {
                    localDataBase.ResetUserPassword(user.login);
                    localDataBase.Save();
                }
                else
                {
                    NavigationService.Navigate(new NewPasswordPage(user, true));
                }
            }
            else
            {
                Output_Error.Text = "Anulowano operację";
            }


        }
        private void ButtonGrid_Delete_Click(object sender, RoutedEventArgs e)
        {
            User user = UsersView.SelectedItem as User;

            if (user.login != "admin")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś pewien, że chcesz usunąc użytkownika?", "Potwierdzenie usunięcia użytkownika", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    localDataBase.Remove(user);
                    localDataBase.Save();
                    RefreshUsersView();
                }
                else
                {
                    Output_Error.Text = "Anulowano operację";
                }
            }
            else
            {
                Output_Error.Text = "Nie można usunąć administratora";
            }
        }

        private void Button_AddUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow addUserWindow = new NewUserWindow();
            addUserWindow.Show();
        }

       

        public void RefreshUsersView()
        {
            localDataBase = LocalDataBase.Initialize();
            UsersView.ItemsSource = localDataBase.ReturnList();
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Logout();
        }
    }
}
