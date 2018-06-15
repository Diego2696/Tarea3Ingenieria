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
    public class ControlVehiculo : IControlVehiculo
    {
        #region
        private readonly IRepositoryVehiculo DomainVehiculo;
        #endregion

        public ControlVehiculo()
        {
            DomainVehiculo = new RepositoryVehiculo();
        }

        public Response<List<tb_vehiculo>> lfGet()
        {
            Response<List<tb_vehiculo>> response = new Response<List<tb_vehiculo>>();

            try
            {
                response.ReturnValue = DomainVehiculo.GetVehiculo();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_vehiculo> lfGet(int idTemp)
        {
            Response<tb_vehiculo> response = new Response<tb_vehiculo>();

            try
            {
                response.ReturnValue = DomainVehiculo.GetVehiculoById(new tb_vehiculo { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_vehiculo> lfInsert(tb_vehiculo vehiculo)
        {
            Response<tb_vehiculo> response = new Response<tb_vehiculo>();

            try
            {
                response.ReturnValue = DomainVehiculo.AddVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_vehiculo> lfUpdate(tb_vehiculo vehiculo)
        {
            Response<tb_vehiculo> response = new Response<tb_vehiculo>();

            try
            {
                response.ReturnValue = DomainVehiculo.UpdateVehiculo(vehiculo);
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
                response.ReturnValue = DomainVehiculo.DeleteVehiculo(new tb_vehiculo { id = idTemp });
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

