using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class PerfilService
    {
        private PerfilRepository perfilRepository = new PerfilRepository();
        #region "SELECT"
        public ResponseModel<List<Perfil>> ListarPerfis()
        {
            ResponseModel<List<Perfil>> result = new ResponseModel<List<Perfil>>();
            try
            {
                result.data = perfilRepository.ListarPerfis();
                result.message.Add("Sucesso ao buscar lista de perfis cadastrados!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por perfis cadastrados.");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "INSERT"
        public ResponseModel<Boolean> CriarPerfil(Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = perfilRepository.CriarPerfil(perfil);
                result.message.Add("Sucesso ao criar novo perfil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inserir novo perfil!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion
        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarPerfil(Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = perfilRepository.AtualizarPerfil(perfil);
                result.message.Add("Sucesso ao atualizar novo perfil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar novo perfil!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeletarPerfil(Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = perfilRepository.DeletarPerfil((long)perfil.Id);
                result.message.Add("Sucesso ao deletar perfil!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar perfil!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

    }
}
