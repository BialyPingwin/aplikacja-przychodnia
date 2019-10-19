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
    /// Logika interakcji dla klasy DoctorMenu.xaml
    /// </summary>
    public partial class DoctorMenu : Page
    {
        User user = null;

        /// <summary>
        /// Konstruktor strony lekarza.
        /// </summary>
        public DoctorMenu()
        {
            
            user = MainWindow.ReturnCurrentUser();

            
            InitializeComponent();
            Output_UserInfo.Text = user.ReturnName();
            this.Loaded += isPasswordChangePending;
        }

        private void isPasswordChangePending(Object Sender, EventArgs E)
        {
            if (user.IsPendingPasswordChange())
            {
                NavigationService.Navigate(new NewPasswordPage(user, false));
            }
        }

        private void Button_SickLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientChoosePage());
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Logout();
        }
    }
}
