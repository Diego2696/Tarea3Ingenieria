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
    public class RepositoryObjeto : IRepositoryObjeto
    {
        #region
        private readonly db_b51795_b51330Entities SS_Context;
        #endregion

        public RepositoryObjeto()
        {
            SS_Context = new db_b51795_b51330Entities();
        }

        public tb_objeto AddObjeto(tb_objeto objeto)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_objeto.Add(objeto);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return objeto;
        }

        public bool DeleteObjeto(tb_objeto objeto)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_objeto.Attach(objeto);
                SS_Context.tb_objeto.Remove(objeto);
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

        public List<tb_objeto> GetObjeto()
        {
            List<tb_objeto> objetoList = new List<tb_objeto>();
            try
            {
                objetoList = (from list in SS_Context.tb_objeto select list).ToList<tb_objeto>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return objetoList;
        }

        public tb_objeto GetObjetoById(tb_objeto objeto)
        {
            tb_objeto tempObjeto = new tb_objeto();
            try
            {
                tempObjeto = (from objetoList in SS_Context.tb_objeto where objetoList.id == objeto.id select objetoList).Single<tb_objeto>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return tempObjeto;
        }

        public tb_objeto UpdateObjeto(tb_objeto objeto)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tb_objeto.Find(objeto.id);
                SS_Context.Entry(entity).CurrentValues.SetValues(objeto);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return objeto;
        }
    }
}
