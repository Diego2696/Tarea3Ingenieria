﻿using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class RepositoryVehiculo :
    GenericRepository<db_b51795_b51330Entities, tb_vehiculo>, IRepositoryVehiculo
    {
    }
}
