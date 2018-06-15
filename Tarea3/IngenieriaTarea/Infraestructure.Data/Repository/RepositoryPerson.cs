using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infraestructure.Data.Repository
{
    public class RepositoryPerson :
    GenericRepository<db_b51795_b51330Entities, tb_persona>, IRepositoryPerson
    {
    }
}
