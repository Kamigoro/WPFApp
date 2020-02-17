using Spire.Email;
using Spire.Email.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models.Mailer
{
    interface IMailer
    {
        MailAddress AddressFrom { get; set; }
        MailAddress AddressTo { get; set; }
        SmtpClient SmtpClient { get; set; }

        void SendMail();
    }
}
