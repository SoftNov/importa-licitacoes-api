using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
    public class Parametro : EntityBase
    {
        public String  DesValue { get; set; }
        public String identificador { get; set; }
        public String Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
