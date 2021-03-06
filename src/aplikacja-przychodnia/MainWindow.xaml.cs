﻿using System;
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
using System.Threading;

namespace aplikacja_przychodnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        User currentUser = null;
        SickLeaveResender sickLeaveResender;

        /// <summary>
        /// Konstruktor strony głównej aplikacji.
        /// </summary>
        public MainWindow()
        {    
            InitializeComponent();
            Main.Content = new LoginPage();

            Reporter.RaportAppStart();
           
            var timer = new System.Threading.Timer((e) => StartResnding(), null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            this.Closed += CloseApp;
        }            

        private void StartResnding()
        {
            new Thread(new ThreadStart(tryResend)).Start();
        }

        private void tryResend()
        {           
            sickLeaveResender = SickLeaveResender.Load();
            sickLeaveResender.TrySending();
        }

        static public void Logout()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Reporter.RaportLogout(mainWindow.currentUser);
            mainWindow.currentUser = null;
            mainWindow.Main.Content = new LoginPage();
        }
        
        private void CloseApp(Object Sender, EventArgs E)
        {
            Reporter.RaportLogout(currentUser);
            Reporter.RaportAppClose();
            Application.Current.Shutdown();
            this.Close();
        }

        public static void LogAsUser(User user)
        {

            Reporter.RaportLogin(user);
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
