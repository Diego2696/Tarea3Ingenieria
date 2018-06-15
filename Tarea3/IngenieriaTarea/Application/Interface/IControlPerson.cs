using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlPerson
    {
        Response<List<tb_persona>> lfGet();
        Response<tb_persona> lfGet(int id);
        Response<tb_persona> lfInsert(tb_persona person);
        Response<tb_persona> lfUpdate(tb_persona person);
        Response<bool> lfDelete(int id);
    }
}
