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
using aplikacja_przychodnia.Classes;

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private UserLocalDataBase UserLocalDataBase;
        private FirmLocalDataBase FirmLocalDataBase;

        public AdminPage()
        {
            UserLocalDataBase = UserLocalDataBase.Initialize();
            FirmLocalDataBase = FirmLocalDataBase.Initialize();
            InitializeComponent();
            UsersView.AutoGenerateColumns = false;
            UsersView.ItemsSource = UserLocalDataBase.ReturnList();
            FirmView.ItemsSource = FirmLocalDataBase.ReturnList();
        }

        private void ButtonGrid_PasswordReset_Click(object sender, RoutedEventArgs e)
        {
            User user = UsersView.SelectedItem as User;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś pewien, że chcesz zresetować hasło użytkownika?", "Potwierdzenie resetu hasła użytkownika", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (user.login != "admin")
                {
                    UserLocalDataBase.ResetUserPassword(user.login);
                    UserLocalDataBase.Save();
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
                    UserLocalDataBase.Remove(user);
                    UserLocalDataBase.Save();
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
            UserLocalDataBase = UserLocalDataBase.Initialize();
            UsersView.ItemsSource = UserLocalDataBase.ReturnList();
        }
        public void RefreshFirmsView()
        {
            FirmLocalDataBase = FirmLocalDataBase.Initialize();
            FirmView.ItemsSource = FirmLocalDataBase.ReturnList();
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Logout();
        }

        private void Button_AddFirm_Click(object sender, RoutedEventArgs e)
        {
            NewFirmWindow addUserWindow = new NewFirmWindow();
            addUserWindow.Show();
        }

        private void ButtonFirm_Delete_Click(object sender, RoutedEventArgs e)
        {
            Firm firm = FirmView.SelectedItem as Firm;
            FirmLocalDataBase.Remove(firm);
            FirmLocalDataBase.Save();
            RefreshFirmsView();
        }
    }
}
