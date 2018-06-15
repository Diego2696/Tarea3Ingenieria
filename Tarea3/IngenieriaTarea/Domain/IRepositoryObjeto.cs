using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryObjeto
    {
        List<tb_objeto> GetObjeto();
        tb_objeto GetObjetoById(tb_objeto objeto);
        tb_objeto AddObjeto(tb_objeto objeto);
        tb_objeto UpdateObjeto(tb_objeto objeto);
        Boolean DeleteObjeto(tb_objeto objeto);
    }
}
