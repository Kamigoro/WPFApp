using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    /// <summary>
    /// Classe qui va servir à stocker la configuration de l'application
    /// </summary>
    public class AppConfigurationModel
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string DefaultComPort { get; set; }
        public int DefaultStationId { get; set; }
    }
}
