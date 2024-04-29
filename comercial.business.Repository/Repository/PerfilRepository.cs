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
    public class PerfilRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private PerfilSql _SQL = new PerfilSql();

        #region "SELECT"

        public List<Perfil> ListarPerfis()
        {
            try
            {
                List<Perfil> perfils = new List<Perfil>();
                DataSet ds = generic.Select(_SQL.BuscarListaPerfis(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    perfils.Add(new Perfil()
                    {
                        Id = Int64.Parse(dr["CD_ID"].ToString()),
                        Descricao = dr["DES_DESCRICAO"].ToString(),
                        DsPerfil = dr["DES_PERFIL"].ToString(),
                        DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString())
                    });
                }

                return perfils;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "INSERT"
        public Boolean CriarPerfil(Perfil perfil)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_DESCRICAO", Type = "String", Value = perfil.Descricao });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_PERFIL", Type = "String", Value = perfil.DsPerfil });


                return generic.ExecuteNonQuery(_SQL.CriarPerfil(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "UPDATE"
        public Boolean AtualizarPerfil(Perfil perfil)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_PERFIL", Type = "String", Value = perfil.DsPerfil });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_DESCRICAO", Type = "String", Value = perfil.Descricao });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = perfil.Id.ToString() });

                return generic.ExecuteNonQuery(_SQL.AtualizarPerfil(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeletarPerfil(long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.DeletarPerfil(), _ListParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
