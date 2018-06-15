using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlObjeto
    {
        Response<List<tb_objeto>> lfGet();
        Response<List<tb_objeto>> lfGet(int id);
        Response<bool> lfInsert(tb_objeto objeto);
        Response<bool> lfUpdate(tb_objeto objeto);
        Response<bool> lfDelete(int id);
    }
}
