using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class ResponseLicitacao
    {
        public ResponseLicitacao()
        {
            this.contratos = new List<Contrato>();
            this.modalidades = new List<Modalidade>();
        }
        public List<Contrato> contratos { get; set; }
        public List<Modalidade> modalidades { get; set; }
    }
}
