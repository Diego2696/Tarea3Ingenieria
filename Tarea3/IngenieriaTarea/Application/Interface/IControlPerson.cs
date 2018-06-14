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
        Response<List<tbPerson>> lfGet();
        Response<tbPerson> lfGet(int id);
        Response<tbPerson> lfInsert(tbPerson person);
        Response<tbPerson> lfUpdate(tbPerson person);
        Response<bool> lfDelete(int id);
    }
}
