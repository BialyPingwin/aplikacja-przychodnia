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
using System.Windows.Shapes;
using aplikacja_przychodnia.Classes;
using aplikacja_przychodnia.Pages;

namespace aplikacja_przychodnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy NewFirmWindow.xaml
    /// </summary>
    public partial class NewFirmWindow : Window
    {
        /// <summary>
        /// Lokalna baza danych firm.
        /// </summary>
        FirmLocalDataBase FirmLocalDataBase;

        /// <summary>
        /// Konstruktor okna dodawania nowej firmy.
        /// </summary>
        public NewFirmWindow()
        {
            FirmLocalDataBase = FirmLocalDataBase.Initialize();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegClass.CheckNIP(Input_NIP.Text))
            {
                if (/*Input_FirmName.Text == "" ||*/
                    Input_NIP.Text == "" ||
                    Input_IP.Text == "" ||
                    Input_Port.Text == "" ||
                    Input_UserInfo.Text == "" ||
                    Input_PasswordInfo.Password == "" ||
                    Input_InitialCatalog.Text == "")
                {
                    Output_Error.Text = "Wypełnij wszystkie pola!";
                }
                else if (!FirmLocalDataBase.IsNipAvailable(Input_NIP.Text))
                {
                    Output_Error.Text = "Firma o tym numerze NIP jest już zapisana w bazie!";
                }
                else if (!FirmLocalDataBase.IsNameAvailable(Input_FirmName.Text))
                {
                    Output_Error.Text = "Firma o tej nazwie jest już zapisana w bazie!";
                }
                else
                {
                    Firm firm = new Firm();
                    firm.NIP = Input_NIP.Text;
                    firm.FirmName = Input_FirmName.Text;
                    firm.IP = Input_IP.Text;
                    firm.Port = Input_Port.Text;
                    firm.InitialCatalog = Input_InitialCatalog.Text;
                    firm.UserInfo = Input_UserInfo.Text;
                    firm.SetFirmPassword(Input_PasswordInfo.Password);

                    FirmLocalDataBase.Add(firm);
                    FirmLocalDataBase.Save();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            if ((window as MainWindow).Main.Content is AdminPage)
                            {
                                ((window as MainWindow).Main.Content as AdminPage).RefreshFirmsView();
                            }
                        }
                    }

                    this.Close();

                }
            }
            else
            {
                Output_Error.Text = "Błędnie wpisany numer NIP!";
            }
        }
    }
}
