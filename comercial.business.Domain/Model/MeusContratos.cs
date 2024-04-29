using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class MeusContratos
    {
        public MeusContratos()
        {
            this.NovosContratos = new List<Contrato>();
            this.ContratosEmBuscaFornecedor = new List<Contrato>();
            this.ContratosEmPrecificacao = new List<Contrato>();
            this.ContratosEmDisputa = new List<Contrato>();
        }
        public List<Contrato> NovosContratos { get; set; }
        public List<Contrato>  ContratosEmBuscaFornecedor { get; set; }
        public List<Contrato> ContratosEmPrecificacao { get; set; }
        public List<Contrato> ContratosEmDisputa { get; set; }

    }
}
