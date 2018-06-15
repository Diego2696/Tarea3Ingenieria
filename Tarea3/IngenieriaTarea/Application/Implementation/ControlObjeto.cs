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
    public class ControlObjeto : IControlObjeto
    {
        #region
        private readonly IRepositoryObjeto DomainObjeto;
        #endregion

        public ControlObjeto()
        {
            DomainObjeto = new RepositoryObjeto();
        }

        public Response<List<tb_objeto>> lfGet()
        {
            Response<List<tb_objeto>> response = new Response<List<tb_objeto>>();

            try
            {
                response.ReturnValue = DomainObjeto.GetObjeto();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_objeto> lfGet(int idTemp)
        {
            Response<tb_objeto> response = new Response<tb_objeto>();

            try
            {
                response.ReturnValue = DomainObjeto.GetObjetoById(new tb_objeto { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_objeto> lfInsert(tb_objeto objeto)
        {
            Response<tb_objeto> response = new Response<tb_objeto>();

            try
            {
                response.ReturnValue = DomainObjeto.AddObjeto(objeto);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_objeto> lfUpdate(tb_objeto objeto)
        {
            Response<tb_objeto> response = new Response<tb_objeto>();

            try
            {
                response.ReturnValue = DomainObjeto.UpdateObjeto(objeto);
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
                response.ReturnValue = DomainObjeto.DeleteObjeto(new tb_objeto { id = idTemp });
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
