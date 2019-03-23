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

namespace aplikacja_przychodnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public LocalDataBase localDataBase;
        public NewUserWindow()
        {
            InitializeComponent();
            localDataBase = LocalDataBase.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Input_Name.Text != null && Input_Surname.Text != null && Input_Login.Text != null && localDataBase.IsLoginFree(Input_Login.Text))
            {
                
                UserClass user = new UserClass(Input_Name.Text, Input_Surname.Text, Input_Login.Text, "hasło");
                localDataBase.Add(user);
                localDataBase.Save();
                foreach(Window window in Application.Current.Windows)
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
            else if (!localDataBase.IsLoginFree(Input_Login.Text))
            {
                Output_Error.Text = "Login zajęty";
            }
            else
            {
                Output_Error.Text = "Błąd wprowadzania danych";
            }
        }
    }
}
