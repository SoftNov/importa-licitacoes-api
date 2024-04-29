using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Domain.ViewModel;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Service.Services
{
   public class FiltroService
    {
        private FiltroRepository repository = new FiltroRepository();
        #region "SELECT"

        public ResponseModel<FiltroViewModel> BuscarDadosFiltro()
        {
            ResponseModel<FiltroViewModel> result = new ResponseModel<FiltroViewModel>();
            try
            {
                FiltroViewModel filtroViewModel = new FiltroViewModel();
                filtroViewModel.estados.AddRange(repository.BuscarEstados());
                filtroViewModel.modalidades.AddRange(repository.BuscarModalidades());
                result.data = filtroViewModel;
                
                
                result.message.Add("Sucesso ao buscar dados do filtro!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisar contato cadastrado.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<List<Municipio>> BuscarMunicipios(List<long> estados)
        {
            ResponseModel<List<Municipio>> result = new ResponseModel<List<Municipio>>();
            try
            {
                result.data = repository.BuscarMunicipios(estados);


                result.message.Add("Sucesso ao buscar municipios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por municipios.");
                result.message.Add(error);
            }
            return result;
        }


        #endregion
    }
}
