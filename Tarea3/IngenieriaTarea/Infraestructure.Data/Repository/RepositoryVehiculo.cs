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
    public class RepositoryVehiculo : IRepositoryVehiculo
    {
        #region
        private readonly db_b51795_b51330Entities SS_Context;
        #endregion

        public RepositoryVehiculo()
        {
            SS_Context = new db_b51795_b51330Entities();
        }

        public tb_vehiculo AddVehiculo(tb_vehiculo vehiculo)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_vehiculo.Add(vehiculo);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return vehiculo;
        }

        public bool DeleteVehiculo(tb_vehiculo vehiculo)
        {

            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                SS_Context.tb_vehiculo.Attach(vehiculo);
                SS_Context.tb_vehiculo.Remove(vehiculo);
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

        public List<tb_vehiculo> GetVehiculo()
        {
            List<tb_vehiculo> vehiculoList = new List<tb_vehiculo>();
            try
            {
                vehiculoList = (from list in SS_Context.tb_vehiculo select list).ToList<tb_vehiculo>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return vehiculoList;
        }

        public tb_vehiculo GetVehiculoById(tb_vehiculo vehiculo)
        {
            tb_vehiculo tempVehiculo = new tb_vehiculo();
            try
            {
                tempVehiculo = (from objetoList in SS_Context.tb_vehiculo where objetoList.id == vehiculo.id select objetoList).Single<tb_vehiculo>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return tempVehiculo;
        }

        public tb_vehiculo UpdateVehiculo(tb_vehiculo vehiculo)
        {
            DbContextTransaction dbTransaction = SS_Context.Database.BeginTransaction();

            try
            {
                var entity = SS_Context.tb_vehiculo.Find(vehiculo.id);
                SS_Context.Entry(entity).CurrentValues.SetValues(vehiculo);
                SS_Context.SaveChanges();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw new Exception(ex.ToString());
            }
            return vehiculo;
        }
    }
}
