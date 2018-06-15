using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlColor
    {
        Response<List<tb_color>> lfGet();
        Response<List<tb_color>> lfGet(int id);
        Response<bool> lfInsert(tb_color color);
        Response<bool> lfUpdate(tb_color color);
        Response<bool> lfDelete(int id);
    }
}
