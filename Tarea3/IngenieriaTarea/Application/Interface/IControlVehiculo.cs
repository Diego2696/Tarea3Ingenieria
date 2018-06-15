using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlVehiculo
    {
        Response<List<tb_vehiculo>> lfGet();
        Response<List<tb_vehiculo>> lfGet(int id);
        Response<bool> lfInsert(tb_vehiculo vehiculo);
        Response<bool> lfUpdate(tb_vehiculo vehiculo);
        Response<bool> lfDelete(int id);
    }
}
