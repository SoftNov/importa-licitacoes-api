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
    public class ContabilService
    {
        private static ContabilRepository contabilRepository = new ContabilRepository();


        public ResponseModel<List<Contabil>> BuscarContabeisUsuario(long idUsuario)
        {
            ResponseModel<List<Contabil>> result = new ResponseModel<List<Contabil>>();
            try
            {
                result.data = contabilRepository.BuscarContabeisUsuario(idUsuario);
                result.message.Add("Sucesso ao buscar parametros contabeis!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar parametros contabeis.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Contabil> BuscarContabeisUsuarioPorId(long idUsuario, long idContabil)
        {
            ResponseModel<Contabil> result = new ResponseModel<Contabil>();
            try
            {
                result.data = contabilRepository.BuscarContabeisUsuarioPorId(idUsuario, idContabil);
                result.message.Add("Sucesso ao buscar parametros contabeis por ID!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar parametros contabeis por ID.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> InserirContabil(Contabil contabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = contabilRepository.InserirContabil(contabil);
                result.message.Add("Sucesso ao inserir contabil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inserir contabil.");
                result.message.Add(error);
            }
            return result;
        }
        public ResponseModel<Boolean> AtualizarContabel(Contabil contabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = contabilRepository.AtualizarContabel(contabil);
                result.message.Add("Sucesso ao realizar update contabil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar update contabil.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> DeleteContabel(long idUsuario, long idContabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = contabilRepository.DeleteContabel(idUsuario, idContabil);
                result.message.Add("Sucesso ao deletar contabil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar contabil.");
                result.message.Add(error);
            }
            return result;
        }


    }
}
