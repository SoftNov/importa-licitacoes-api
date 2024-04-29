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
   public class FiltroRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private FiltroSql _SQL = new FiltroSql();



        #region "SELECT"

        public List<Estado> BuscarEstados()
        {
            try
            {
                List<Estado> estados = new List<Estado>();
                _ListParameter.Clear();
                
                DataSet ds = generic.Select(_SQL.BuscarEstados(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Estado estado = new Estado
                    {
                        Id = Int64.Parse(dr["ID"].ToString()),
                        Uf = dr["UF"].ToString()
                    };

                    estados.Add(estado);
                }
                  

                return estados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Modalidade> BuscarModalidades()
        {
            try
            {
                List<Modalidade> modalidades = new List<Modalidade>();
                _ListParameter.Clear();

                DataSet ds = generic.Select(_SQL.BuscarModalidades(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Modalidade estado = new Modalidade
                    {
                        idModalidade = int.Parse(dr["ID_MODALIDADE"].ToString()),
                        Nome = dr["NOME"].ToString()
                    };

                    modalidades.Add(estado);
                }


                return modalidades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Municipio> BuscarMunicipios(List<long> listIdEstado)
        {
            try
            {
                List<Municipio> municipios = new List<Municipio>();
                _ListParameter.Clear();
                
                DataSet ds = generic.Select(_SQL.BuscarMunicipios().Replace(":ID_ESTADO", String.Join(", ", listIdEstado)), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Municipio estado = new Municipio
                    {
                        Id = Int64.Parse(dr["ID"].ToString()),
                        idEstado = dr["ID_ESTADO"].ToString(),
                        Nome = dr["NOME"].ToString(),
                    };

                    municipios.Add(estado);
                }


                return municipios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
