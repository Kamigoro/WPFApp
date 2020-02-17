using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models.Tools
{
    public static class HardDriveTools
    {
        public static string GetFirstDiskSerialNumber()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            List<HardDrive> hdCollection = new List<HardDrive>();
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive
                hdCollection.Add(hd);
            }
            
            //De temps en temps on a des espaces vides, faut les supprimer
            string serialNumber = hdCollection.ElementAt<HardDrive>(0).SerialNo.Replace(" ", string.Empty);
            return serialNumber;
        }

        public static string GetHashOfFirstDiskSerialNumber()
        {
            return GetFirstDiskSerialNumber().GetHashCode().ToString();
        }

        public static bool IsEqualToHashOfDisk(string license)
        {
            return license.Equals(GetHashOfFirstDiskSerialNumber());
        }

    }
}
