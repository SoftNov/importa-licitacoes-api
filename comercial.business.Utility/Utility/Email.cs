using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.IO;
using comercial.business.Domain.Model;
using comercial.business.Utility.Utility;
using System.Net;

namespace comercial.business.Utility.Email
{
    public class Email
    {
        public Constants constants = new Constants();
    

        public void EnviarEmail(EmailModel emailModel)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587; // Porta para TLS (ou 465 para SSL)
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Credentials = new NetworkCredential(constants.Email, constants.EmailSenha);

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(constants.Email);
                foreach (var destino in emailModel.destinatario)
                {
                    mail.To.Add(destino);
                }

                mail.Subject = emailModel.titulo;
                mail.Body = emailModel.mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
