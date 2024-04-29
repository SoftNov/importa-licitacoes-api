using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Repository
{
    public class ParametroRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private ParametroSql _SQL = new ParametroSql();

        #region "SELECT"
        public Parametro BuscarParametro(Parametro parametro)
        {
            try
            {
                Parametro result = new Parametro();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = parametro.Id.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_IDENTIFICADOR", Type = "String", Value = parametro.identificador.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarParametro().Replace("{DES_DESCRICAO}", parametro.Descricao), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    result.Id = Int64.Parse(dr["CD_ID"].ToString());
                    result.DesValue = dr["DES_VALUE"].ToString();
                    result.identificador = dr["DES_IDENTIFICADOR"].ToString();
                    result.Descricao = dr["DES_DESCRICAO"].ToString();
                    result.DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<Parametro> BuscarParametroAll()
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                _ListParameter.Clear();

                DataSet ds = generic.Select(_SQL.BuscarParametroAll(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    parametros.Add(new Parametro()
                    {
                        Id = Int64.Parse(dr["CD_ID"].ToString()),
                        DesValue = dr["DES_VALUE"].ToString(),
                        identificador = dr["DES_IDENTIFICADOR"].ToString(),
                        Descricao = dr["DES_DESCRICAO"].ToString(),
                        DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString())
                    });

                }

                return parametros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "INSERT"
        public int CriarParametro(Parametro parametro)
        {
            try
            {
                int result = 0;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_VALUE", Type = "String", Value = parametro.DesValue });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_IDENTIFICADOR", Type = "String", Value = parametro.identificador.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_DESCRICAO", Type = "String", Value = parametro.Descricao });

                DataSet ds = generic.Select(_SQL.CriarParametro(), _ListParameter);

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
        public Boolean AtualizarParametro(Parametro parametro)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_VALUE", Type = "String", Value = parametro.DesValue });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_IDENTIFICADOR", Type = "String", Value = parametro.identificador.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_DESCRICAO", Type = "String", Value = parametro.Descricao });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = parametro.Id.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtualizarParametro(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeletarParametro(long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.DeletarParametro(), _ListParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



    }
}
