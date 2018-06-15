using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryInformacionBasica
    {
        List<tb_informacion_basica> GetInfoBasica();
        tb_informacion_basica GetInfoBasicaById(tb_informacion_basica infoBasica);
        tb_informacion_basica AddInfoBasica(tb_informacion_basica infoBasica);
        tb_informacion_basica UpdateInfoBasica(tb_informacion_basica infoBasica);
        Boolean DeleteInfoBasica(tb_informacion_basica infoBasica);
    }
}
