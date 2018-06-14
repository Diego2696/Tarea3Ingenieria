using Domain;
using Domain.Entities;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class RepositoryPerson : IRepositoryPerson
    {
        #region
        private readonly db_tarea3_pruebaEntities SS_Context;
        #endregion

        public RepositoryPerson(db_tarea3_pruebaEntities context)
        {
            SS_Context = context;
        }

        public tbPerson AddPerson(tbPerson person)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tbPerson.Add(person);
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

        public bool DeletePerson(tbPerson person)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tbPerson.Attach(person);
                SS_Context.tbPerson.Remove(person);
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

        public List<tbPerson> GetPerson()
        {
            List<tbPerson> userList = new List<tbPerson>();
            try
            {
                userList = (from list in SS_Context.tbPerson select list).ToList<tbPerson>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return userList;
        }

        public tbPerson GetPersonById(tbPerson tperson)
        {
            tbPerson person = new tbPerson();
            try
            {
                person = (from userList in SS_Context.tbPerson where userList.id == tperson.id select userList).Single<tbPerson>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return person;
        }

        public tbPerson UpdatePerson(tbPerson person)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tbPerson.Find(person.id);
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
