using DatabaseTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseTestWPF.ViewModels
{
    public class SupervisionViewModel
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public EventHandler<Measure> SalutEvent;

        public unsafe async void LaunchSupervision()
        {
            Task.Run(() => 
            {
                double i = 0;
                while (true)
                {
                    //float result = 0;
                    //ICA5.READCOMMAND(1, "mvv", &result);
                    try
                    {
                        cts.Token.ThrowIfCancellationRequested();
                        Measure measure = new Measure { Signal = i };
                        SalutEvent?.Invoke(this, measure);
                        i = i + 20; 
                        Thread.Sleep(1000);
                    }
                    catch (OperationCanceledException)
                    {
                        cts = new CancellationTokenSource();
                        break;
                    }
                    
                }
            }, cts.Token);
        }


        public void StopSupervision()
        {
            cts.Cancel();
        }

    }
}
