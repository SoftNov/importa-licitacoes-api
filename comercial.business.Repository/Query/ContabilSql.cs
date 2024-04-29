using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class ContabilSql
    {
        #region "SELECT"
        public String BuscarContabeisUsuario()
        {
            String Sql = @" SELECT ID, ID_USUARIO, DESCRICAO, PER_TRANSPORTE, PER_GARANTIA_EXTRA, PER_ICMS, PER_PIS, 
                            PER_CONFINS, PER_IPI, PER_ISS, PER_MARGEM, DATA_CADASTRO FROM TBL_PARAMETROS_CONTABEIS AS A
                            INNER JOIN TBL_USUARIO AS B ON A.ID_USUARIO = B.CD_ID
                            WHERE A.ID_USUARIO = @ID_USUARIO ";
            return Sql;
        }

        public String BuscarContabeisUsuarioPorId()
        {
            String Sql = @" SELECT ID, ID_USUARIO, DESCRICAO, PER_TRANSPORTE, PER_GARANTIA_EXTRA, PER_ICMS, PER_PIS, 
                            PER_CONFINS, PER_IPI, PER_ISS, PER_MARGEM, DATA_CADASTRO FROM TBL_PARAMETROS_CONTABEIS AS A
                            INNER JOIN TBL_USUARIO AS B ON A.ID_USUARIO = B.CD_ID
                            WHERE A.ID_USUARIO = @ID_USUARIO AND A.ID = @ID_CONTABIL ";
            return Sql;
        }
        #endregion

        #region "INSERT"
        public String InserirContabil()
        {
            String Sql = @" INSERT INTO TBL_PARAMETROS_CONTABEIS(ID_USUARIO, DESCRICAO, PER_TRANSPORTE, 
                            PER_GARANTIA_EXTRA, PER_ICMS, PER_PIS, 
                            PER_CONFINS, PER_IPI, PER_ISS, PER_MARGEM, DATA_CADASTRO)
                            VALUES(@ID_USUARIO, @DESCRICAO, @PER_TRANSPORTE, 
                            @PER_GARANTIA_EXTRA, @PER_ICMS, @PER_PIS, 
                            @PER_CONFINS, @PER_IPI, @PER_ISS, @PER_MARGEM, NOW()) ";
            return Sql;
        }
        #endregion

        #region "UPDATE"
        public String AtualizarContabel()
        {
            String Sql = @" UPDATE TBL_PARAMETROS_CONTABEIS
                            SET DESCRICAO = @DESCRICAO, PER_TRANSPORTE = @PER_TRANSPORTE,
                            PER_GARANTIA_EXTRA = @PER_GARANTIA_EXTRA, PER_ICMS = @PER_ICMS,
                            PER_PIS = @PER_PIS, PER_CONFINS = @PER_CONFINS, PER_IPI = @PER_IPI,
                            PER_ISS = @PER_ISS, PER_MARGEM = @PER_MARGEM
                            WHERE ID_USUARIO = @ID_USUARIO AND ID = @ID_CONTABIL ";
            return Sql;
        }
        #endregion

        #region "DELETE"
        public String DeleteContabel()
        {
            String Sql = @" DELETE FROM TBL_PARAMETROS_CONTABEIS WHERE ID_USUARIO = @ID_USUARIO AND ID = @ID_CONTABIL";
            return Sql;
        }
        #endregion
    }
}
