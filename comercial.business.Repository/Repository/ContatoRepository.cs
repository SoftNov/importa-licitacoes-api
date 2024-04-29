using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Repository
{
    public class ContatoRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private ContatoSql _SQL = new ContatoSql();

        #region "SELECT"

        public Contato BuscarContatoId(int id)
        {
            try
            {
                Contato contato = new Contato();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                DataSet ds = generic.Select(_SQL.BuscarContatoId(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    contato.Id = Int64.Parse(dr["CD_ID"].ToString());
                    contato.Email = dr["DES_EMAIL"].ToString();
                    contato.NumTelefone = dr["DES_NUM_TELEFONE"].ToString();
                    contato.DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString());
                }

                return contato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Contato> BuscarContatos()
        {
            try
            {
                List<Contato> contatos = new List<Contato>();
                DataSet ds = generic.Select(_SQL.BuscarContatos(), _ListParameter);



                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    contatos.Add(new Contato()
                    {
                        Id = Int64.Parse(dr["CD_ID"].ToString()),
                        Email = dr["DES_EMAIL"].ToString(),
                        NumTelefone = dr["DES_NUM_TELEFONE"].ToString(),
                        DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString())
                    });
                }

                return contatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean VerificaNumCelularEmail(String email, String numCelular)
        {
            try
            {
                Boolean result = false;
                List<Contato> contatos = new List<Contato>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_EMAIL", Type = "String", Value = email });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NUM_TELEFONE", Type = "String", Value = numCelular });
                DataSet ds = generic.Select(_SQL.VerificaCpfCnpjEmail(), _ListParameter);


                if (ds.Tables[0].Rows.Count >0)
                {
                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "INSERT"
        public int CriarContato(Contato contato)
        {
            try
            {
                int result = 0;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_EMAIL", Type = "String", Value = contato.Email });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NUM_TELEFONE", Type = "String", Value = contato.NumTelefone });

                DataSet ds = generic.Select(_SQL.CriarContato(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result = int.Parse(dr["CD_ID"].ToString());
                }
          

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "UPDATE"
        public Boolean AtualizarContato(Contato contato)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_EMAIL", Type = "String", Value = contato.Email });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NUM_TELEFONE", Type = "String", Value = contato.NumTelefone });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = contato.Id.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtualizarContato(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeletarContato(long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.DeletarContato(), _ListParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
