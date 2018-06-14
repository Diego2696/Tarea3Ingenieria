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
        List<tbPerson> GetPerson();
        tbPerson GetPersonById(tbPerson person);
        tbPerson AddPerson(tbPerson person);
        tbPerson UpdatePerson(tbPerson person);
        Boolean DeletePerson(tbPerson person);
    }
}
