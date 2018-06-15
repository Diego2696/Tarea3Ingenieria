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
    public class ControlInformacionBasica : IControlInformacionBasica
    {
        #region
        private readonly IRepositoryInformacionBasica DomainInfoBasica;
        #endregion

        public ControlInformacionBasica()
        {
            DomainInfoBasica = new RepositoryInformacionBasica();
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_informacion_basica infoBasica = new tb_informacion_basica();
                infoBasica.id = idTemp;
                response.ReturnValue = DomainInfoBasica.Delete(infoBasica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_informacion_basica>> lfGet()
        {
            Response<List<tb_informacion_basica>> response = new Response<List<tb_informacion_basica>>();

            try
            {
                response.ReturnValue = DomainInfoBasica.GetAll().ToList<tb_informacion_basica>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_informacion_basica>> lfGet(int id)
        {
            Response<List<tb_informacion_basica>> response = new Response<List<tb_informacion_basica>>();

            try
            {
                Expression<Func<tb_informacion_basica, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainInfoBasica.FindBy(comparation).ToList<tb_informacion_basica>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_informacion_basica infoBasica)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainInfoBasica.Add(infoBasica);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_informacion_basica infoBasica)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainInfoBasica.Update(infoBasica);
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
