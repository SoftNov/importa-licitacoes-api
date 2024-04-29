using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
    public class FiltroLicitacao
    {
        public List<String> listDesProduto { get; set; }
        public List<int> listEstado { get; set; }
        public List<int> listMunicipio { get; set; }
        public List<int> listModalidade { get; set; }

        public DateTime DatFim { get; set; }
        //public DateTime DatInicio { get; set; }

    }
}
