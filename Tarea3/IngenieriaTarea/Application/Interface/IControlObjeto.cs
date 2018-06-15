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
        Response<tb_objeto> lfGet(int id);
        Response<tb_objeto> lfInsert(tb_objeto objeto);
        Response<tb_objeto> lfUpdate(tb_objeto objeto);
        Response<bool> lfDelete(int id);
    }
}
