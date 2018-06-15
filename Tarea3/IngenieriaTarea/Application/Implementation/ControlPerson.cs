﻿using Application.Interface;
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
        private readonly IRepositoryPerson DomainPersona;
        #endregion

        public ControlPerson()
        {
            DomainPersona = new RepositoryPerson();
        }

        public Response<List<tb_persona>> lfGet()
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            try
            {
                response.ReturnValue = DomainPersona.GetPerson();
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
                response.ReturnValue = DomainPersona.GetPersonById(new tb_persona { id = idTemp });
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona> lfInsert(tb_persona persona)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            try
            {
                response.ReturnValue = DomainPersona.AddPerson(persona);
            }
            catch (Exception ex)
            {
                response.blnTransactionIndicator = false;
                response.ReturnValue = null;
                response.strOrigin = ex.ToString();
            }
            return response;
        }

        public Response<tb_persona> lfUpdate(tb_persona persona)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            try
            {
                response.ReturnValue = DomainPersona.UpdatePerson(persona);
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
                response.ReturnValue = DomainPersona.DeletePerson(new tb_persona { id = idTemp });
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
