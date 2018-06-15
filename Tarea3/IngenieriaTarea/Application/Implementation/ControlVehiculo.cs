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
    public class ControlVehiculo : IControlVehiculo
    {
        #region
        private readonly IRepositoryVehiculo DomainVehiculo;
        #endregion

        public ControlVehiculo()
        {
            DomainVehiculo = new RepositoryVehiculo();
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_vehiculo vehiculo = new tb_vehiculo();
                vehiculo.id = idTemp;
                response.ReturnValue = DomainVehiculo.Delete(vehiculo);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_vehiculo>> lfGet()
        {
            Response<List<tb_vehiculo>> response = new Response<List<tb_vehiculo>>();

            try
            {
                response.ReturnValue = DomainVehiculo.GetAll().ToList<tb_vehiculo>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_vehiculo>> lfGet(int id)
        {
            Response<List<tb_vehiculo>> response = new Response<List<tb_vehiculo>>();

            try
            {
                Expression<Func<tb_vehiculo, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainVehiculo.FindBy(comparation).ToList<tb_vehiculo>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_vehiculo vehiculo)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainVehiculo.Add(vehiculo);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_vehiculo vehiculo)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainVehiculo.Update(vehiculo);
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

