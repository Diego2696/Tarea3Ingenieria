using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryPersonaJuridica
    {
        List<tb_persona_juridica> GetPersonaJuridica();
        tb_persona_juridica GetPersonaJuridicaById(tb_persona_juridica personaJuridica);
        tb_persona_juridica AddPersonaJuridica(tb_persona_juridica personaJuridica);
        tb_persona_juridica UpdatePersonaJuridica(tb_persona_juridica personaJuridica);
        Boolean DeletePersonaJuridica(tb_persona_juridica personaJuridica);
    }
}
