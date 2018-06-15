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
        Response<tb_informacion_basica> lfGet(int id);
        Response<tb_informacion_basica> lfInsert(tb_informacion_basica infoBasica);
        Response<tb_informacion_basica> lfUpdate(tb_informacion_basica infoBasica);
        Response<bool> lfDelete(int id);
    }
}
