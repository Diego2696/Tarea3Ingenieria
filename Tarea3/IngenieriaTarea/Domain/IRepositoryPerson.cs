using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryPerson
    {
        List<tb_persona> GetPerson();
        tb_persona GetPersonById(tb_persona person);
        tb_persona AddPerson(tb_persona person);
        tb_persona UpdatePerson(tb_persona person);
        Boolean DeletePerson(tb_persona person);
    }
}
