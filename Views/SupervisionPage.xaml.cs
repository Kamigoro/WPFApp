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

        public ChartValues<Measure> MeasurementsPoints { get; set; }
        public ChartValues<Measure> MaxCapacityPoints { get; set; }


        CancellationTokenSource TokenSource;
        CancellationToken CancellationToken;

        public SupervisionPage()
        {
            InitializeComponent();

            TokenSource = new CancellationTokenSource();
            CancellationToken = TokenSource.Token;


            var chartConfig = Mappers.Xy<Measure>().X(measure => (double)measure.TimeStamp.Ticks / TimeSpan.FromHours(1).Ticks).Y(measure => measure.Signal);

            MeasurementsPoints = new ChartValues<Measure>();
            MaxCapacityPoints = new ChartValues<Measure>();

            ListOfChartSeries = new SeriesCollection(chartConfig)
            {
                new LineSeries
                {
                    Title = "Capacity Measured",
                    Values = MeasurementsPoints
                }, 
                new LineSeries
                {
                    Title = "Max Capacity",
                    Values = MaxCapacityPoints
                }
            };

            Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");

            RunningTask();

            DataContext = this;
            
        }

        private void RunningTask()
        {
            Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    try
                    {
                        if (CancellationToken.IsCancellationRequested)
                        {
                            CancellationToken.ThrowIfCancellationRequested();
                        }
                        Random random = new Random();
                        double signal = random.NextDouble() * (150 - 0) + 150;

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ListOfChartSeries[0].Values.Add(new Measure { Signal = signal, TimeStamp = DateTime.Now.AddMinutes(i) });
                            ListOfChartSeries[1].Values.Add(new Measure { Signal = 500, TimeStamp = DateTime.Now.AddMinutes(i) });
                        });

                        i++;
                        Thread.Sleep(1000);
                    }
                    catch (OperationCanceledException)
                    {
                        TokenSource.Dispose();
                    }
                    
                }
            },CancellationToken);
        }

        private void BTNStartSupervision_Click(object sender, RoutedEventArgs e)
        {
            RunningTask();
        }

        private void BTNStopSupervision_Click(object sender, RoutedEventArgs e)
        {
            TokenSource.Cancel();
        }
    }
}
