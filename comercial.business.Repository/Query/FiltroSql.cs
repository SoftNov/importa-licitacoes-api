using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
   public class FiltroSql
    {
        #region "SELECT"
        public String BuscarEstados()
        {
            String Sql = @"SELECT ID, UF FROM TBL_ESTADO";
            return Sql;
        }

        public String BuscarModalidades()
        {
            String Sql = @" SELECT ID_MODALIDADE, NOME FROM TBL_MODALIDADE ";
            return Sql;
        }

        public String BuscarMunicipios()
        {
            String Sql = @"SELECT ID, ID_MONICIPIO, ID_ESTADO, NOME FROM TBL_MUNICIPIO WHERE ID_ESTADO IN(:ID_ESTADO)  ORDER BY NOME ASC;";
            return Sql;
        }
        #endregion
    }
}
