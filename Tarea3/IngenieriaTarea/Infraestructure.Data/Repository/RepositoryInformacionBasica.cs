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
    public class RepositoryInformacionBasica : IRepositoryInformacionBasica
    {
        #region
        private readonly db_b51795_b51330Entities SS_Context;
        #endregion

        public RepositoryInformacionBasica()
        {
            SS_Context = new db_b51795_b51330Entities();
        }

        public tb_informacion_basica AddInfoBasica(tb_informacion_basica infoBasica)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_informacion_basica.Add(infoBasica);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return infoBasica;
        }

        public bool DeleteInfoBasica(tb_informacion_basica infoBasica)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_informacion_basica.Attach(infoBasica);
                SS_Context.tb_informacion_basica.Remove(infoBasica);
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

        public List<tb_informacion_basica> GetInfoBasica()
        {
            List<tb_informacion_basica> infoBasicaList = new List<tb_informacion_basica>();
            try
            {
                infoBasicaList = (from list in SS_Context.tb_informacion_basica select list).ToList<tb_informacion_basica>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return infoBasicaList;
        }

        public tb_informacion_basica GetInfoBasicaById(tb_informacion_basica infoBasica)
        {
            tb_informacion_basica tempInfoBasica = new tb_informacion_basica();
            try
            {
                tempInfoBasica = (from infoBasicaList in SS_Context.tb_informacion_basica where infoBasicaList.id == infoBasica.id select infoBasicaList).Single<tb_informacion_basica>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return tempInfoBasica;
        }

        public tb_informacion_basica UpdateInfoBasica(tb_informacion_basica infoBasica)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tb_informacion_basica.Find(infoBasica.id);
                SS_Context.Entry(entity).CurrentValues.SetValues(infoBasica);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return infoBasica;
        }
    }
}
