using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class RepositoryPersonaJuridica : IRepositoryPersonaJuridica
    {
        #region
        private readonly db_b51795_b51330Entities SS_Context;
        #endregion

        public RepositoryPersonaJuridica()
        {
            SS_Context = new db_b51795_b51330Entities();
        }

        public tb_persona_juridica AddPersonaJuridica(tb_persona_juridica personaJuridica)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_persona_juridica.Add(personaJuridica);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return personaJuridica;
        }

        public bool DeletePersonaJuridica(tb_persona_juridica personaJuridica)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_persona_juridica.Attach(personaJuridica);
                SS_Context.tb_persona_juridica.Remove(personaJuridica);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return true;

        }

        public List<tb_persona_juridica> GetPersonaJuridica()
        {
            List<tb_persona_juridica> personaJuridicaList = new List<tb_persona_juridica>();
            try
            {
                personaJuridicaList = (from list in SS_Context.tb_persona_juridica select list).ToList<tb_persona_juridica>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return personaJuridicaList;
        }

        public tb_persona_juridica GetPersonaJuridicaById(tb_persona_juridica personaJuridica)
        {
            tb_persona_juridica tempPersonaJuridica = new tb_persona_juridica();
            try
            {
                tempPersonaJuridica = (from personaJuridicaList in SS_Context.tb_persona_juridica where personaJuridicaList.id == personaJuridica.id select personaJuridicaList).Single<tb_persona_juridica>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return tempPersonaJuridica;
        }

        public tb_persona_juridica UpdatePersonaJuridica(tb_persona_juridica personaJuridica)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tb_persona_juridica.Find(personaJuridica.id);
                SS_Context.Entry(entity).CurrentValues.SetValues(personaJuridica);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return personaJuridica;
        }
    }
}
