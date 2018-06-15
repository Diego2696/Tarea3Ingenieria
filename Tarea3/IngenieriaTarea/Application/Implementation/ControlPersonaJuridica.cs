using Application.Interface;
using Domain;
using Domain.Entities;
using Domain.UTL;
using Infraestructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class ControlPersonaJuridica : IControlPersonaJuridica
    {
        #region
        private readonly IRepositoryPersonaJuridica DomainPersonaJuridica;
        #endregion

        public ControlPersonaJuridica()
        {
            DomainPersonaJuridica = new RepositoryPersonaJuridica();
        }

        public Response<List<tb_persona_juridica>> lfGet()
        {
            Response<List<tb_persona_juridica>> response = new Response<List<tb_persona_juridica>>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.GetPersonaJuridica();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona_juridica> lfGet(int idTemp)
        {
            Response<tb_persona_juridica> response = new Response<tb_persona_juridica>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.GetPersonaJuridicaById(new tb_persona_juridica { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona_juridica> lfInsert(tb_persona_juridica personaJuridica)
        {
            Response<tb_persona_juridica> response = new Response<tb_persona_juridica>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.AddPersonaJuridica(personaJuridica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona_juridica> lfUpdate(tb_persona_juridica personaJuridica)
        {
            Response<tb_persona_juridica> response = new Response<tb_persona_juridica>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.UpdatePersonaJuridica(personaJuridica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.ReturnValue = DomainPersonaJuridica.DeletePersonaJuridica(new tb_persona_juridica { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }
    }
}
