using DatabaseTestWPF.DataAccess;
using DatabaseTestWPF.Models;
using DatabaseTestWPF.Models.Tools;
using DatabaseTestWPF.ViewModels;
using DatabaseTestWPF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        private PeopleListingPage peopleListingPage = new PeopleListingPage();
        private SupervisionPage supervisionPage = new SupervisionPage();
        private ConfigurationPage configurationPage = new ConfigurationPage();

        public MainWindow()
        {
            InitializeComponent();
            

            //Si la DB n'existe pas ou n'est pas à jour on la crée/update
            using (var db = new DataAccessor())
            {
                db.Database.Migrate(); 
            }

            Debug.WriteLine(HardDriveTools.GetHashOfFirstDiskSerialNumber());
            FRMContent.Navigate(peopleListingPage);

        }

       
        private bool IsConfigurationExistingInDB()
        {
            using (var db = new DataAccessor())
            {
                if (db.Configurations.ToList().Any())
                {
                    //Une config existe en DB
                    return true;
                }
                else
                {
                    //Pas de config en DB
                    return false;
                }
            }
        }

        private void IsLicenseInDBValid()
        {
            using (var db = new DataAccessor())
            {
                AppConfigurationModel config = db.Configurations.ToList().First();
                string serialNumberInDb = config.SerialNumber;
            }
        }

        //Partie concernant la navigation entre pages
        
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
