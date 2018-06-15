using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryVehiculo
    {
        List<tb_vehiculo> GetVehiculo();
        tb_vehiculo GetVehiculoById(tb_vehiculo vehiculo);
        tb_vehiculo AddVehiculo(tb_vehiculo vehiculo);
        tb_vehiculo UpdateVehiculo(tb_vehiculo vehiculo);
        Boolean DeleteVehiculo(tb_vehiculo vehiculo);
    }
}
