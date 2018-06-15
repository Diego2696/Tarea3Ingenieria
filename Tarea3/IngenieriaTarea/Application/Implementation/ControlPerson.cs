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
    public class ControlPerson : IControlPerson
    {
        #region
        private readonly IRepositoryPerson DomainUser;
        #endregion

        public ControlPerson()
        {
            DomainUser = new RepositoryPerson();
        }

        public Response<List<tb_persona>> lfGet()
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            try
            {
                response.ReturnValue = DomainUser.GetPerson();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona> lfGet(int idTemp)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            try
            {
                response.ReturnValue = DomainUser.GetPersonById(new tb_persona { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona> lfInsert(tb_persona user)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            try
            {
                response.ReturnValue = DomainUser.AddPerson(user);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona> lfUpdate(tb_persona user)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            try
            {
                response.ReturnValue = DomainUser.UpdatePerson(user);
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
                response.ReturnValue = DomainUser.DeletePerson(new tb_persona { id = idTemp });
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
