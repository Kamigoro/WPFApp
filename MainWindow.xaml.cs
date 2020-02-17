﻿using DatabaseTestWPF.DataAccess;
using DatabaseTestWPF.Models;
using DatabaseTestWPF.ViewModels;
using DatabaseTestWPF.Views;
using Microsoft.EntityFrameworkCore;
using Spire.Email;
using Spire.Email.IMap;
using Spire.Email.Smtp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
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

namespace DatabaseTestWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeopleListingPage peopleListingPage;
        private SupervisionPage supervisionPage;
        private ConfigurationPage configurationPage;

        public MainWindow()
        {
            //Si la DB n'existe pas ou n'est pas à jour on la crée/update
            using (var db = new DataAccessor())
            {
                db.Database.Migrate();
            }

            //Initialisation des composants et pages
            InitializeComponent();
            peopleListingPage = new PeopleListingPage();
            supervisionPage = new SupervisionPage();
            configurationPage = new ConfigurationPage();


            //Arriver sur la page de listing quand on lance l'application
            FRMContent.Navigate(peopleListingPage);

        }

        
        private void BTNNavigateToListing_Click(object sender, RoutedEventArgs e)
        {
            FRMContent.Navigate(peopleListingPage);
        }

        private void BTNNavigateToSupervision_Click(object sender, RoutedEventArgs e)
        {
            FRMContent.Navigate(supervisionPage);
        }

        private void BTNNavigateToConfiguration_Click(object sender, RoutedEventArgs e)
        {
            FRMContent.Navigate(configurationPage);
        }


    }
}
