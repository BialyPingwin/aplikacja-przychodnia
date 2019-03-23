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
            DoctorClass user = UsersView.SelectedItem as DoctorClass;


        }
        private void ButtonGrid_Delete_Click(object sender, RoutedEventArgs e)
        {
            DoctorClass user = UsersView.SelectedItem as DoctorClass;

            if (user.login != "admin")
            {
                localDataBase.Remove(user);
                localDataBase.Save();
                RefreshUsersView();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsersView();
        }

        private void RefreshUsersView()
        {
            localDataBase = LocalDataBase.Initialize();
            UsersView.ItemsSource = localDataBase.ReturnList();
        }
    }
}
