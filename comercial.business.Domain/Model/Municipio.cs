using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class Municipio : EntityBase
    {
        public String Nome { get; set; }
        public String idEstado { get; set; }
    }
}
