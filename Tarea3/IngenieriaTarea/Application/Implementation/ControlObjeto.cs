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
    public class ControlObjeto : IControlObjeto
    {
        #region
        private readonly IRepositoryObjeto DomainObjeto;
        #endregion

        public ControlObjeto()
        {
            DomainObjeto = new RepositoryObjeto();
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_objeto objeto = new tb_objeto();
                objeto.id = idTemp;
                response.ReturnValue = DomainObjeto.Delete(objeto);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_objeto>> lfGet()
        {
            Response<List<tb_objeto>> response = new Response<List<tb_objeto>>();

            try
            {
                response.ReturnValue = DomainObjeto.GetAll().ToList<tb_objeto>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_objeto>> lfGet(int id)
        {
            Response<List<tb_objeto>> response = new Response<List<tb_objeto>>();

            try
            {
                Expression<Func<tb_objeto, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainObjeto.FindBy(comparation).ToList<tb_objeto>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_objeto objeto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainObjeto.Add(objeto);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_objeto objeto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainObjeto.Update(objeto);
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
