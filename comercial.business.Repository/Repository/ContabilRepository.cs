using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace comercial.business.Repository.Repository
{
    public class ContabilRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private ContabilSql _SQL = new ContabilSql();

        #region "SELECT"
        public List<Contabil> BuscarContabeisUsuario(long idUsuario)
        {
            try
            {
                List<Contabil> contabils = new List<Contabil>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                DataSet ds = generic.Select(_SQL.BuscarContabeisUsuario(), _ListParameter);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Contabil contabil = new Contabil();
                    contabil.Id = Int64.Parse(dr["ID"].ToString());
                    contabil.descricao = dr["DESCRICAO"].ToString();
                    contabil.transporte = Decimal.Parse(dr["PER_TRANSPORTE"].ToString());
                    contabil.garantiaExtra = Decimal.Parse(dr["PER_GARANTIA_EXTRA"].ToString());
                    contabil.icms = Decimal.Parse(dr["PER_ICMS"].ToString());
                    contabil.pis = Decimal.Parse(dr["PER_PIS"].ToString());
                    contabil.cofins = Decimal.Parse(dr["PER_CONFINS"].ToString());
                    contabil.ipi = Decimal.Parse(dr["PER_IPI"].ToString());
                    contabil.iss = Decimal.Parse(dr["PER_ISS"].ToString());
                    contabil.margem = Decimal.Parse(dr["PER_MARGEM"].ToString());
                    contabils.Add(contabil);
                }
                return contabils;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Contabil BuscarContabeisUsuarioPorId(long idUsuario, long idContabil)
        {
            try
            {
                Contabil contabil = new Contabil();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTABIL", Type = "INT", Value = idContabil.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarContabeisUsuarioPorId(), _ListParameter);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    contabil.Id = Int64.Parse(dr["ID"].ToString());
                    contabil.descricao = dr["DESCRICAO"].ToString();
                    contabil.transporte = Decimal.Parse(dr["PER_TRANSPORTE"].ToString());
                    contabil.garantiaExtra = Decimal.Parse(dr["PER_GARANTIA_EXTRA"].ToString());
                    contabil.icms = Decimal.Parse(dr["PER_ICMS"].ToString());
                    contabil.pis = Decimal.Parse(dr["PER_PIS"].ToString());
                    contabil.cofins = Decimal.Parse(dr["PER_CONFINS"].ToString());
                    contabil.ipi = Decimal.Parse(dr["PER_IPI"].ToString());
                    contabil.iss = Decimal.Parse(dr["PER_ISS"].ToString());
                    contabil.margem = Decimal.Parse(dr["PER_MARGEM"].ToString());
                }
                return contabil;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "INSERT"
        public Boolean InserirContabil(Contabil contabil)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = contabil.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DESCRICAO", Type = "String", Value = contabil.descricao.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_TRANSPORTE", Type = "DECIMAL", Value = contabil.transporte.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_GARANTIA_EXTRA", Type = "DECIMAL", Value = contabil.garantiaExtra.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_ICMS", Type = "DECIMAL", Value = contabil.icms.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_PIS", Type = "DECIMAL", Value = contabil.pis.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_CONFINS", Type = "DECIMAL", Value = contabil.cofins.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_IPI", Type = "DECIMAL", Value = contabil.ipi.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_ISS", Type = "DECIMAL", Value = contabil.iss.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_MARGEM", Type = "DECIMAL", Value = contabil.margem.ToString() });

                generic.ExecuteNonQuery(_SQL.InserirContabil(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "UPDATE"
        public Boolean AtualizarContabel(Contabil contabil)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DESCRICAO", Type = "String", Value = contabil.descricao.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_TRANSPORTE", Type = "DECIMAL", Value = contabil.transporte.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_GARANTIA_EXTRA", Type = "DECIMAL", Value = contabil.garantiaExtra.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_ICMS", Type = "DECIMAL", Value = contabil.icms.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_PIS", Type = "DECIMAL", Value = contabil.pis.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_CONFINS", Type = "DECIMAL", Value = contabil.cofins.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_IPI", Type = "DECIMAL", Value = contabil.ipi.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_ISS", Type = "DECIMAL", Value = contabil.iss.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "PER_MARGEM", Type = "DECIMAL", Value = contabil.margem.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = contabil.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTABIL", Type = "INT", Value = contabil.Id.ToString() });

                 generic.ExecuteNonQuery(_SQL.AtualizarContabel(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeleteContabel(long idUsuario, long idContabil)
        {
            try
            {
                _ListParameter.Clear();
               _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTABIL", Type = "INT", Value = idContabil.ToString() });

                generic.ExecuteNonQuery(_SQL.DeleteContabel(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
