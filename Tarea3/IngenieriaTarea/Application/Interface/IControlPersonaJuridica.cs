using Domain.Entities;
using Domain.UTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IControlPersonaJuridica
    {
        Response<List<tb_persona_juridica>> lfGet();
        Response<List<tb_persona_juridica>> lfGet(int id);
        Response<bool> lfInsert(tb_persona_juridica personaJuridica);
        Response<bool> lfUpdate(tb_persona_juridica personaJuridica);
        Response<bool> lfDelete(int id);
    }
}
