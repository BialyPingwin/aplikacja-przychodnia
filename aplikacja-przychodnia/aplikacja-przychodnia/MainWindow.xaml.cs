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

namespace aplikacja_przychodnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        User currentUser = null;

        public MainWindow()
        {    
            InitializeComponent();
            Main.Content = new LoginPage();
            this.Closed += CloseApp;
        }            

        static public void Logout()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

            mainWindow.currentUser = null;
            mainWindow.Main.Content = new LoginPage();
        }
        
        private void CloseApp(Object Sender, EventArgs E)
        {
            
            Application.Current.Shutdown();
            this.Close();
        }

        public static void LogAsUser(User user)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.currentUser = user;
        }

        public static User ReturnCurrentUser()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            return mainWindow.currentUser;
        }

    }
}
