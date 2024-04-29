using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class VinculoFornecedor
    {
        public long idFornecedor { get; set; }
        public long idUsuario{ get; set; }
        public long idContrato { get; set; }
        public long idItem { get; set; }
    }
}
