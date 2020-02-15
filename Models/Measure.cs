using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public double Signal { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
