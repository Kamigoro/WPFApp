using DatabaseTestWPF.DataAccess;
using DatabaseTestWPF.Models;
using DatabaseTestWPF.ViewModels;
using DatabaseTestWPF.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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

namespace DatabaseTestWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeopleListingPage PeopleListingPage;

        public MainWindow()
        {
            //Si la DB n'existe pas ou n'est pas à jour on la crée/update
            using (var db = new DataAccessor())
            {
                db.Database.Migrate();
            }

            InitializeComponent();
            PeopleListingPage = new PeopleListingPage();
            FRMContent.Navigate(PeopleListingPage);


            
            Debug.WriteLine($"Numéro de série du disque {HardDriveTools.GetFirstDiskSerialNumber()} Bien joué mon ami");

        }

    }
}
