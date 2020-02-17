using DatabaseTestWPF.Models;
using DatabaseTestWPF.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DatabaseTestWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour PeopleListingPage.xaml
    /// </summary>
    public partial class PeopleListingPage : Page
    {
        private PeopleViewModel peopleViewModel;

        /// <summary> Constructeur de la page de listing de personne </summary>
        public PeopleListingPage()
        {
            InitializeComponent();
            peopleViewModel = new PeopleViewModel();
            ListViewOfPeople.ItemsSource = peopleViewModel.GetAllPeopleInDB();
            peopleViewModel.AddingPersonEvent += AddingPersonEvenHandler;
        }

        

        /// <summary>
        /// Ajout d'une personne dans la db et rafraichissement de la liste
        /// TODO Vérification des champs avant d'essayer de créer la personne
        /// </summary>
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TBXPersonToAddFirstName.Text;
            string lastName = TBXPersonToAddLastName.Text;
            string email = TBXPersonToAddEmail.Text;
            peopleViewModel.AddPersonInDB(firstName, lastName, email);
            EmptyFormFields();
            ReloadPeopleList();
        }

        /// <summary>
        /// Evènement après que l'on ait essayé d'ajouter une personne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddingPersonEvenHandler(object sender, string e)
        {
            var messageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(2000));
            SNBPerson.MessageQueue = messageQueue;
            SNBPerson.MessageQueue.Enqueue(e);
        }

        /// <summary> 
        /// Suppression d'une personne grâce à son id qui est caché derrière un bouton 
        /// </summary>
        private void BTNDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int personToDeleteId = Int32.Parse(button.Tag.ToString());
            peopleViewModel.DeletePersonInDB(personToDeleteId);
            ReloadPeopleList();
        }

        /// <summary> 
        /// Rafraichir la liste de personne pour correspondre à la DB 
        /// </summary>
        private void ReloadPeopleList()
        {
            ListViewOfPeople.ItemsSource = peopleViewModel.GetAllPeopleInDB();
            ListViewOfPeople.Items.Refresh();
        }

        /// <summary> 
        /// Vider les champs après l'ajout d'une personne 
        /// </summary>
        private void EmptyFormFields()
        {
            TBXPersonToAddFirstName.Text = "";
            TBXPersonToAddLastName.Text = "";
            TBXPersonToAddEmail.Text = "";
        }

        

        
    }
}
