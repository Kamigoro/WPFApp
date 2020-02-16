using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    public class ConfigurationModel
    {
        public string ComPort { get; set; }
        public int StationID { get; set; }
        public string PathToReportDirectory { get; set; }
    }
}
