using Application.Interface;
using Domain;
using Domain.Entities;
using Domain.UTL;
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

        public ControlPerson(IRepositoryPerson repository)
        {
            DomainUser = repository;
        }

        public Response<List<tbPerson>> lfGet()
        {
            Response<List<tbPerson>> response = new Response<List<tbPerson>>();

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

        public Response<tbPerson> lfGet(int idTemp)
        {
            Response<tbPerson> response = new Response<tbPerson>();

            try
            {
                response.ReturnValue = DomainUser.GetPersonById(new tbPerson { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tbPerson> lfInsert(tbPerson user)
        {
            Response<tbPerson> response = new Response<tbPerson>();

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

        public Response<tbPerson> lfUpdate(tbPerson user)
        {
            Response<tbPerson> response = new Response<tbPerson>();

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
                response.ReturnValue = DomainUser.DeletePerson(new tbPerson { id = idTemp });
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
