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
        Response<List<tb_persona>> lfGet(int id);
        Response<bool> lfInsert(tb_persona persona);
        Response<bool> lfUpdate(tb_persona persona);
        Response<bool> lfDelete(int id);
    }
}
