using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
   public class ParametroSql
    {
        #region "SELECT"
        public String BuscarParametroAll()
        {
            String Sql = @"SELECT CD_ID, DES_VALUE, DES_IDENTIFICADOR, DES_DESCRICAO, DT_CADASTRO FROM TBL_PARAMETRO";
            return Sql;
        }


        public String BuscarParametro()
        {
            String Sql = @"SELECT CD_ID, DES_VALUE, DES_IDENTIFICADOR, DES_DESCRICAO, DT_CADASTRO FROM TBL_PARAMETRO WHERE CD_ID = @CD_ID
                                                                            OR DES_IDENTIFICADOR = @DES_IDENTIFICADOR";
            return Sql;
        }

        #endregion

        #region "INSERT"
        public String CriarParametro()
        {
            String Sql = @" INSERT INTO TBL_PARAMETRO (DES_VALUE, DES_IDENTIFICADOR, DES_DESCRICAO, DT_CADASTRO)
                                         VALUES(@DES_VALUE, @DES_IDENTIFICADOR, @DES_DESCRICAO, NOW());
                             SELECT CD_ID FROM TBL_PARAMETRO WHERE DES_IDENTIFICADOR = @DES_IDENTIFICADOR";
            return Sql;
        }
        #endregion


        #region"UPDATE"
        public String AtualizarParametro()
        {
            String Sql = @"UPDATE TBL_PARAMETRO 
                            SET DES_VALUE = @DES_VALUE, 
                                 DES_IDENTIFICADOR = @DES_IDENTIFICADOR,
                                 DES_DESCRICAO = @DES_DESCRICAO
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }
        #endregion

        #region "DELETE"
        public String DeletarParametro()
        {
            String Sql = @" DELETE FROM TBL_PARAMETRO WHERE CD_ID = @CD_ID";
            return Sql;
        }
        #endregion
    }
}
