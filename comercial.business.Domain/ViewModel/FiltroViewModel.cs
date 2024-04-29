using comercial.business.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.ViewModel
{
   public class FiltroViewModel
    {
        public FiltroViewModel()
        {
            this.estados = new List<Estado>();
            this.modalidades = new List<Modalidade>();
        }
        public List<Estado> estados { get; set; }
        public List<Modalidade> modalidades { get; set; }
    }
}
