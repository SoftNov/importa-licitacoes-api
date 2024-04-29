using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class Contrato
    {
        public int idContrato{ get; set; }
        public String titulo { get; set; }
        public String descicao { get; set; }
        public String codigo { get; set; }
        public String nome { get; set; }
        public DateTime dtFimVigencia { get; set; }
        public DateTime dtInicioVigencia { get; set; }
        public String modalidade { get; set; }
        public String url { get; set; }
        public int status { get; set; }
    }
}
