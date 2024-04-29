using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
    public class EmailModel
    {
        public EmailModel()
        {
            this.destinatario = new List<MailAddress>();
        }
        public String mensagem { get; set; }
        public String titulo { get; set; }
        public List<MailAddress> destinatario { get; set; }
    }
}
