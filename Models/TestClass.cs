using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    public class TestClass
    {
        public delegate void TakeMeasure(Measure measure); 

        public TestClass(TakeMeasure MeasurementStrategy)
        {
            
            for (int i = 1; i<10;i++)
            {
                Measure measure = new Measure();
                measure.Signal = i * i;
                measure.TimeStamp = DateTime.Now.AddMinutes(i);
                MeasurementStrategy(measure);
            }
            
        }
    }
}
