using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class ContatoSql
    {
        #region "SELECT"
        public String BuscarContatoId()
        {
            String Sql = @"SELECT CD_ID, DES_EMAIL, DES_NUM_TELEFONE, DT_CADASTRO FROM TBL_CONTATO WHERE CD_ID = @CD_ID";
            return Sql;
        }

        public String BuscarContatos()
        {
            String Sql = @"SELECT CD_ID, DES_EMAIL, DES_NUM_TELEFONE, DT_CADASTRO FROM TBL_CONTATO";
            return Sql;
        }

        public String VerificaCpfCnpjEmail()
        {
            String Sql = @"SELECT * FROM TBL_CONTATO WHERE UPPER(TRIM(DES_EMAIL)) = UPPER(TRIM(@DES_EMAIL)) OR DES_NUM_TELEFONE = @DES_NUM_TELEFONE";
            return Sql;
        }
        #endregion

        #region "INSERT"
        public String CriarContato()
        {
            String Sql = @" INSERT INTO TBL_CONTATO (DES_EMAIL, DES_NUM_TELEFONE, DT_CADASTRO)
                                              VALUES(@DES_EMAIL, @DES_NUM_TELEFONE, NOW()); 
                           SELECT CD_ID FROM TBL_CONTATO WHERE DES_EMAIL = @DES_EMAIL";
            return Sql;
        }
        #endregion

        #region"UPDATE"
        public String AtualizarContato()
        {
            String Sql = @"UPDATE TBL_CONTATO 
                            SET DES_EMAIL = @DES_EMAIL, 
                                DES_NUM_TELEFONE = @DES_NUM_TELEFONE
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }
        #endregion


        #region "DELETE"
        public String DeletarContato()
        {
            String Sql = @" DELETE FROM TBL_CONTATO WHERE CD_ID = @CD_ID";
            return Sql;
        }
        #endregion
    }
}
