using DatabaseTestWPF.Models;
using DatabaseTestWPF.ViewModels;
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
        private PeopleViewModel viewModel;

        public PeopleListingPage()
        {
            InitializeComponent();
            viewModel = new PeopleViewModel();
            ListViewOfPeople.ItemsSource = viewModel.GetAllPeopleInDB();
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TBXPersonToAddFirstName.Text;
            string lastName = TBXPersonToAddLastName.Text;
            int age = Int32.Parse(TBXPersonToAddAge.Text);
            string email = TBXPersonToAddEmail.Text;
            viewModel.AddPersonInDB(firstName, lastName, age, email);
            EmptyFormFields();
            ReloadPeopleList();
        }

        private void BTNDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender;
            int id = Int32.Parse((string)deleteButton.Tag);
            PersonModel personToDelete = viewModel.GetAllPeopleInDB().Where(person => person.Id == id).First();
            viewModel.DeletePersonInDB(personToDelete);
            ReloadPeopleList();
        }

        private void ReloadPeopleList()
        {
            ListViewOfPeople.ItemsSource = viewModel.GetAllPeopleInDB();
            ListViewOfPeople.Items.Refresh();
        }

        private void EmptyFormFields()
        {
            TBXPersonToAddFirstName.Text = "";
            TBXPersonToAddLastName.Text = "";
            TBXPersonToAddAge.Text = "";
            TBXPersonToAddEmail.Text = "";
        }

        //Permet de bloquer l'entrée de caractère non numérique dans une textbox
        private void NumericalTextBoxHandler(object sender, TextCompositionEventArgs e)
        {
            //Si l'input ne correspond pas à l'expression régulière, nous n'acceptons pas
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
    }
}
