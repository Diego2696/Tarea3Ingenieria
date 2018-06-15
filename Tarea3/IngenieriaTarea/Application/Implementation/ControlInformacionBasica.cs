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
    public class ControlInformacionBasica : IControlInformacionBasica
    {
        #region
        private readonly IRepositoryInformacionBasica DomainInfoBasica;
        #endregion

        public ControlInformacionBasica()
        {
            DomainInfoBasica = new RepositoryInformacionBasica();
        }

        public Response<List<tb_informacion_basica>> lfGet()
        {
            Response<List<tb_informacion_basica>> response = new Response<List<tb_informacion_basica>>();

            try
            {
                response.ReturnValue = DomainInfoBasica.GetInfoBasica();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_informacion_basica> lfGet(int idTemp)
        {
            Response<tb_informacion_basica> response = new Response<tb_informacion_basica>();

            try
            {
                response.ReturnValue = DomainInfoBasica.GetInfoBasicaById(new tb_informacion_basica { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_informacion_basica> lfInsert(tb_informacion_basica infoBasica)
        {
            Response<tb_informacion_basica> response = new Response<tb_informacion_basica>();

            try
            {
                response.ReturnValue = DomainInfoBasica.AddInfoBasica(infoBasica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_informacion_basica> lfUpdate(tb_informacion_basica infoBasica)
        {
            Response<tb_informacion_basica> response = new Response<tb_informacion_basica>();

            try
            {
                response.ReturnValue = DomainInfoBasica.UpdateInfoBasica(infoBasica);
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
                response.ReturnValue = DomainInfoBasica.DeleteInfoBasica(new tb_informacion_basica { id = idTemp });
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
