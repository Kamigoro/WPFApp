using DatabaseTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Tools
{
    public static class HardDriveTools
    {
        public static string GetFirstDiskSerialNumber()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            List<HardDriveModel> hdCollection = new List<HardDriveModel>();
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDriveModel hd = new HardDriveModel();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();
                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive
                hdCollection.Add(hd);
            }
            
            //De temps en temps on a des espaces vides, faut les supprimer
            string serialNumber = hdCollection.ElementAt<HardDriveModel>(0).SerialNo.Replace(" ", string.Empty);
            return serialNumber;
        }
    }
}
