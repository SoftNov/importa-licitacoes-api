using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
    public class Negocio
    {
        public long id { get; set; }
        public long idContrato { get; set; }
        public List<long> listItens { get; set; }
    }


}
