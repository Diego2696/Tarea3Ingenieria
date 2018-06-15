using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlInformacionBasica
    {
        Response<List<tb_informacion_basica>> lfGet();
        Response<List<tb_informacion_basica>> lfGet(int id);
        Response<bool> lfInsert(tb_informacion_basica infoBasica);
        Response<bool> lfUpdate(tb_informacion_basica infoBasica);
        Response<bool> lfDelete(int id);
    }
}
