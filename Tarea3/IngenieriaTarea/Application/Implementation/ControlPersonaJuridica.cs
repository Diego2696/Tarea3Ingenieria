using Application.Interface;
using Domain;
using Domain.Entities;
using Domain.UTL;
using Infraestructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_persona_juridica personaJuridica = new tb_persona_juridica();
                personaJuridica.id = idTemp;
                response.ReturnValue = DomainPersonaJuridica.Delete(personaJuridica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_persona_juridica>> lfGet()
        {
            Response<List<tb_persona_juridica>> response = new Response<List<tb_persona_juridica>>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.GetAll().ToList<tb_persona_juridica>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_persona_juridica>> lfGet(int id)
        {
            Response<List<tb_persona_juridica>> response = new Response<List<tb_persona_juridica>>();

            try
            {
                Expression<Func<tb_persona_juridica, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainPersonaJuridica.FindBy(comparation).ToList<tb_persona_juridica>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_persona_juridica personaJuridica)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.Add(personaJuridica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_persona_juridica personaJuridica)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainPersonaJuridica.Update(personaJuridica);
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
