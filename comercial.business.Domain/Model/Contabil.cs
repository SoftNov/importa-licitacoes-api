using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class Contabil : EntityBase
    {
        public long idUsuario { get; set; }
        public String descricao { get; set; }
        public Decimal transporte { get; set; }
        public Decimal garantiaExtra { get; set; }
        public Decimal icms { get; set; }
        public Decimal pis { get; set; }
        public Decimal cofins { get; set; }
        public Decimal ipi { get; set; }
        public Decimal iss { get; set; }
        public Decimal margem { get; set; }
    }
}
