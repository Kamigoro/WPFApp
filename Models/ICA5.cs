using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    public class ICA5
    {
        [DllImport("MantraASCII2Drv.dll")]
        public static extern float VERSION();
        [DllImport("MantraASCII2Drv.dll")]
        public static extern int OPENPORT(int comPort, long bauderate);
        [DllImport("MantraASCII2Drv.dll")]
        public static extern int CLOSEPORT();
        [DllImport("MantraASCII2Drv.dll")]
        public unsafe static extern int READCOMMAND(int stationId, String command, float* result);
        [DllImport("MantraASCII2Drv.dll")]
        public unsafe static extern int WRITECOMMAND(int stationId, String command, float* result);
        [DllImport("MantraASCII2Drv.dll")]
        public static extern int EXECUTECOMMAND(int stationId, String commande);
        [DllImport("MantraASCII2Drv.dll")]
        public static extern int SETTIMEOUT(int timeoutInMS);
        [DllImport("MantraASCII2Drv.dll")]
        public static extern int GETTIMEOUT();
    }
}
