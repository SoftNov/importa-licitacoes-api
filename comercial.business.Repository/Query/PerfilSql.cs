using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class PerfilSql
    {
        #region "SELECT"
        public String BuscarListaPerfis()
        {
            String Sql = @"SELECT CD_ID, DES_PERFIL, DES_DESCRICAO, DT_CADASTRO FROM TBL_PERFIL";
            return Sql;
        }
        #endregion

        #region "INSERT"
        public String CriarPerfil()
        {
            String Sql = @" INSERT INTO TBL_PERFIL (DES_DESCRICAO, DES_PERFIL, DT_CADASTRO)
                                              VALUES(@DES_DESCRICAO, @DES_PERFIL, NOW())";
            return Sql;
        }
        #endregion

        #region"UPDATE"
        public String AtualizarPerfil()
        {
            String Sql = @"UPDATE TBL_PERFIL 
                            SET DES_PERFIL = @DES_PERFIL, 
                                DES_DESCRICAO = @DES_DESCRICAO
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }
        #endregion


        #region "DELETE"
        public String DeletarPerfil()
        {
            String Sql = @" DELETE FROM TBL_PERFIL WHERE CD_ID = @CD_ID";
            return Sql;
        }
        #endregion
    }
}
