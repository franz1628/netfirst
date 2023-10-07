using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace APICmd.Util.Email
{
    public class EmailHelper
    {
        private readonly EmailConfiguration _objEmail;

        public EmailHelper(EmailConfiguration objEmail)
        {
            _objEmail = objEmail;
        }

        public int EnviarMail(string asunto, string cuerpo)
        {
            try
            {
                string ClienteHost = _objEmail.HostBaseEmail;
                string ClientePort = _objEmail.PortBaseEmail;
                string EmailBase = _objEmail.EmailBase;
                string NameEmailBase = _objEmail.NameEmailBase;
                string PassEmailBase = _objEmail.PasswordEmailBase;
                string EmailBaseTo = _objEmail.EmailBaseTo;
                string EmailBaseCC = _objEmail.EmailBaseCC;
                string EmailBaseCCO = _objEmail.EmailBaseCCO;
                bool enableSSL = true;
                var fromAddress = new MailAddress(EmailBase, NameEmailBase);
                string fromPassword = PassEmailBase;
                string subject = asunto;
                string body = cuerpo;

                var smtp = new SmtpClient
                {
                    Host = ClienteHost,
                    Port = Convert.ToInt32(ClientePort),
                    EnableSsl = enableSSL,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                var message = new MailMessage();
                if (!string.IsNullOrEmpty(EmailBaseTo))
                {
                    foreach (var item in EmailBaseTo.Split(';'))
                    {
                        message.To.Add(item);
                    }
                }
                
                if (!string.IsNullOrEmpty(EmailBaseCC))
                {
                    foreach (var item in EmailBaseCC.Split(';'))
                    {
                        message.CC.Add(item);
                    }
                }
                if (!string.IsNullOrEmpty(EmailBaseCCO))
                {
                    foreach (var item in EmailBaseCCO.Split(';'))
                    {
                        message.Bcc.Add(item);
                    }
                }
                message.Subject = asunto;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = cuerpo;

                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true; //Si no queremos que se envíe como HTML
                message.From = new MailAddress(fromAddress.Address, fromAddress.DisplayName);
                smtp.Send(message);
                return 1;
            }

            catch (SmtpException)
            {
                return 0;
                //throw new Exception("Error al enviar el correo.", ex);
            }
        }
    }

    public class EmailConfiguration
    {
        public string HostBaseEmail { get; set; }
        public string PortBaseEmail { get; set; }
        public string EmailBase { get; set; }
        public string NameEmailBase { get; set; }
        public string PasswordEmailBase { get; set; }
        public string EmailBaseTo { get; set; }
        public string EmailBaseCC { get; set; }
        public string EmailBaseCCO { get; set; }
    }
}
