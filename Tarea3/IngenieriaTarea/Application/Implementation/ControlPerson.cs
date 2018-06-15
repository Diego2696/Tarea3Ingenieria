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
    public class ControlPerson : IControlPerson
    {
        #region
        private readonly IRepositoryPerson DomainPersona;
        #endregion

        public ControlPerson()
        {
            DomainPersona = new RepositoryPerson();
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_persona persona = new tb_persona();
                persona.id = idTemp;
                response.ReturnValue = DomainPersona.Delete(persona);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_persona>> lfGet()
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            try
            {
                response.ReturnValue = DomainPersona.GetAll().ToList<tb_persona>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_persona>> lfGet(int id)
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            try
            {
                Expression<Func<tb_persona, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainPersona.FindBy(comparation).ToList<tb_persona>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_persona persona)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainPersona.Add(persona);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_persona persona)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainPersona.Update(persona);
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
