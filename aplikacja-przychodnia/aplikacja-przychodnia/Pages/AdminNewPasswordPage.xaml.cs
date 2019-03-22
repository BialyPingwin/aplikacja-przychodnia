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
    /// Logika interakcji dla klasy AdminNewPasswordPage.xaml
    /// </summary>
    public partial class AdminNewPasswordPage : Page
    {
        public LocalDataBase localDataBase;

        public AdminNewPasswordPage()
        {
            localDataBase = new LocalDataBase();
            InitializeComponent();
        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (Input_Password1.Password != null && Input_Password1.Password == Input_Password2.Password)
            {
                DoctorClass admin = new DoctorClass("admin", "admin", "admin", Input_Password1.Password);
                localDataBase.Add(admin);
                localDataBase.Save();
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                Output_Error.Text = "Podane hasła nie zgadzają się";
            }
        }
    }
}
