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
    public class ControlColor : IControlColor
    {

        #region
        private readonly IRepositoryColor DomainColor;
        #endregion

        public ControlColor()
        {
            DomainColor = new RepositoryColor();
        }

        public Response<bool> lfDelete(int idTemp)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                tb_color color = new tb_color();
                color.id = idTemp;
                response.ReturnValue = DomainColor.Delete(color);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_color>> lfGet()
        {
            Response<List<tb_color>> response = new Response<List<tb_color>>();

            try
            {
                response.ReturnValue = DomainColor.GetAll().ToList<tb_color>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<List<tb_color>> lfGet(int id)
        {
            Response<List<tb_color>> response = new Response<List<tb_color>>();

            try
            {
                Expression<Func<tb_color, bool>> comparation = c => c.id == id;
                response.ReturnValue = DomainColor.FindBy(comparation).ToList<tb_color>();
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfInsert(tb_color color)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainColor.Add(color);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = false;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<bool> lfUpdate(tb_color color)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response.ReturnValue = DomainColor.Update(color);
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
