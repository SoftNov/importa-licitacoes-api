using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class ParametroService
    {
        private ParametroRepository parametroRepository = new ParametroRepository();
        #region "SELECT"

        public ResponseModel<Parametro> BuscarParametro(Parametro parametro)
        {
            ResponseModel<Parametro> result = new ResponseModel<Parametro>();
            try
            {
                result.data = ObterParametro(parametro);
                result.message.Add("Sucesso ao buscar parametro cadastrado!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisar parametro cadastrado.");
                result.message.Add(error);
            }
            return result;
        }

        public Parametro ObterParametro(Parametro parametro)
        {
           Parametro result = new Parametro();
            try
            {
                result = parametroRepository.BuscarParametro(parametro);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public ResponseModel<List<Parametro>> BuscarParametroAll()
        {
            ResponseModel<List<Parametro>> result = new ResponseModel<List<Parametro>>();
            try
            {
                result.data = parametroRepository.BuscarParametroAll();
                result.message.Add("Sucesso ao buscar lista de parametros cadastrados!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por parametros cadastrados.");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "INSERT"
        public ResponseModel<int> CriarParametro(Parametro parametro)
        {
            ResponseModel<int> result = new ResponseModel<int>();
            try
            {
                result.data = parametroRepository.CriarParametro(parametro);
                result.message.Add("Sucesso ao criar novo parametro!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inserir novo parametro!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarParametro(Parametro parametro)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = parametroRepository.AtualizarParametro(parametro);
                result.message.Add("Sucesso ao atualizar parametro!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar parametro!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeletarParametro(Parametro parametro)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = parametroRepository.DeletarParametro((long)parametro.Id);
                result.message.Add("Sucesso ao deletar parametro!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar parametro!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

    }
}
