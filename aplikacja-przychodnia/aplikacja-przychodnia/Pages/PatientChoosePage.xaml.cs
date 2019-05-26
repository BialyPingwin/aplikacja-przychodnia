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

namespace aplikacja_przychodnia.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy PatientChoosePage.xaml
    /// </summary>
    public partial class PatientChoosePage : Page
    {
        FirmLocalDataBase FirmLocalDataBase;
        List<Patient> patients = new List<Patient>();
        Patient currnetlySelectedPatient;
        string nip;

        public PatientChoosePage()
        {
            InitializeComponent();
            FirmLocalDataBase = FirmLocalDataBase.Initialize();
        }

        private void Button_PatientSearch_Click(object sender, RoutedEventArgs e)
        {
            
            if (Input_PESELBox.Text.Length == 11)
            {
                patients = new List<Patient>();
                nip = Input_NIPBox.Text;
                string connectionString = FirmLocalDataBase.FindFirmConnectionByNIP(Input_NIPBox.Text);
                if (connectionString != null)
                {
                    Patient patientToAdd = SQLServerClient.GetPatient(Convert.ToInt64(Input_PESELBox.Text), connectionString);
                    if (patientToAdd != null)
                    {
                        patients.Add(patientToAdd);
                        Patients_Data.ItemsSource = patients;
                    }
                }
                else
                {
                    ///błąd źle wpisanego peselu
                }
            }
        }

        private void Button_Continue_Click(object sender, RoutedEventArgs e)
        {
            if (currnetlySelectedPatient != null)
            {
                currnetlySelectedPatient._NIP = Convert.ToInt64(nip);
                NavigationService.Navigate(new SickLeaveSchemePage(currnetlySelectedPatient));
            }
            else
            {
                Button_Continue.IsEnabled = false;
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DoctorMenu());
        }

        private void Patients_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currnetlySelectedPatient = Patients_Data.SelectedItem as Patient;
            if (currnetlySelectedPatient != null)
            {
                Button_Continue.IsEnabled = true;
            }
            else
            {
                Button_Continue.IsEnabled = false;
            }
        }
    }
}
