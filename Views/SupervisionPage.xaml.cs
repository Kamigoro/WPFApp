using DatabaseTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using System.Windows.Threading;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace DatabaseTestWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour SupervisionPage.xaml
    /// </summary>
    public partial class SupervisionPage : Page
    {
        public SeriesCollection ListOfChartSeries { get; set; }
        public Func<double, string> Formatter { get; set; }

        /// <summary>
        /// Séries que l'on va ajouter au graphique
        /// MeasurementsPoints sont les points réellement mesurés
        /// MaxCapacityPoints sont les points qui vont juste délimiter la capa max
        /// </summary>
        public ChartValues<Measure> MeasurementsPoints { get; set; }
        public ChartValues<Measure> MaxCapacityPoints { get; set; }


        public SupervisionPage()
        {
            InitializeComponent();
            MeasurementsPoints = new ChartValues<Measure>();
            MaxCapacityPoints = new ChartValues<Measure>();

            //Configuration du graph pour accepter des objets de type Measure
            var chartConfig = Mappers.Xy<Measure>()
                .X(measure => (double)measure.TimeStamp.Ticks / TimeSpan.FromHours(1).Ticks)
                .Y(measure => measure.Signal);
            ListOfChartSeries = new SeriesCollection(chartConfig)
            {
                new LineSeries //Déclaration de la série qui va acceuillir les points de mesure
                {
                    Title = "Capacity Measured",
                    Values = MeasurementsPoints
                }, 
                new LineSeries //Déclaration de la série qui va délimiter la capacité max
                {
                    Title = "Max Capacity",
                    Values = MaxCapacityPoints
                }
            };

            //Permet de formater les dates correctement dans le graphique
            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");

            DataContext = this;
        }

        /// <summary>
        /// Ajoute la mesure passée en paramètre au graphique
        /// et retire le premier point du graph si on a dépassé un certains nombres de points dans le graph
        /// </summary>
        /// <param name="measure"></param>
        private void AddMeasureToChart(Measure measure)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ListOfChartSeries[0].Values.Add(measure);
                ListOfChartSeries[1].Values.Add(new Measure { Signal = 500, TimeStamp = measure.TimeStamp });
                if ((ListOfChartSeries[0].Values.Count > 10) && (ListOfChartSeries[1].Values.Count > 10))
                {
                    RemoveFirstMeasureOfChart();
                }
            });
        }

        /// <summary>
        /// Retire le premier point du graphe
        /// </summary>
        private void RemoveFirstMeasureOfChart()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ListOfChartSeries[0].Values.RemoveAt(0);
                ListOfChartSeries[1].Values.RemoveAt(0);
            });
        }

        /// <summary>
        /// Fonction permettant de nettoyer le graph quand on relance un test
        /// </summary>
        private void ClearChart()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ListOfChartSeries[0].Values.Clear();
                ListOfChartSeries[1].Values.Clear();
            });
        }
        

    }
}
