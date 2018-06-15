using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestructure.Data.Repository
{
    public class RepositoryPerson : IRepositoryPerson
    {
        #region
        private readonly db_b51795_b51330Entities SS_Context;
        #endregion

        public RepositoryPerson()
        {
            SS_Context = new db_b51795_b51330Entities();
        }

        public tb_persona AddPerson(tb_persona person)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_persona.Add(person);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return person;
        }

        public bool DeletePerson(tb_persona person)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_persona.Attach(person);
                SS_Context.tb_persona.Remove(person);
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

        public List<tb_persona> GetPerson()
        {
            List<tb_persona> userList = new List<tb_persona>();
            try
            {
                userList = (from list in SS_Context.tb_persona select list).ToList<tb_persona>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return userList;
        }

        public tb_persona GetPersonById(tb_persona tperson)
        {
            tb_persona person = new tb_persona();
            try
            {
                person = (from userList in SS_Context.tb_persona where userList.id == tperson.id select userList).Single<tb_persona>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return person;
        }

        public tb_persona UpdatePerson(tb_persona person)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tb_persona.Find(person.id);
                SS_Context.Entry(entity).CurrentValues.SetValues(person);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return person;
        }
    }
}
