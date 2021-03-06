﻿using Spire.Email;
using Spire.Email.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTestWPF.Models.Tools;

namespace DatabaseTestWPF.Models.Mailer
{
    public class LicenseMailer : IMailer
    {
        public MailAddress AddressFrom { get; set; }
        public MailAddress AddressTo { get; set; } = new MailAddress("info@sensy.com");
        public SmtpClient SmtpClient { get; set; } = new SmtpClient() { Host = "relay-b03.edpnet.be", Port = 587 };
        public string LicenseSeed { get; set; }

        public string htmlString;
        public MailMessage message;
        
        public void SendMail()
        {
            message = new MailMessage(AddressFrom, AddressTo);

            message.Date = DateTime.Now;
            message.Subject = "Asking for a license";
            htmlString = $@"<html>
                      <body>
                      <p>Hello, I'm asking for a license for the software with this seed : {HardDriveTools.GetFirstDiskSerialNumber()}</p>
                      </body>
                      </html>
                     ";
            message.BodyHtml = htmlString;

            SmtpClient.SendOne(message);
        }
    }
}
