using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Domain.UTL;
using Domain.Entities;
using Infraestructure.IoC;
using Application.Implementation;
using System;

namespace IngenieriaTarea.Controllers
{
    [RoutePrefix("api/informacionBasica")]
    public class InformacionBasicaController : ApiController
    {
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeleteInformacionBasica(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlInfoBasica = FactoryIoC.Container.Resolver<ControlInformacionBasica>();

            return Json(controlInfoBasica.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult InsertInformacionBasica([FromBody]tb_informacion_basica infoBasica)
        {
            Response<Boolean> response = new Response<bool>();

            var controlInfoBasica = FactoryIoC.Container.Resolver<ControlInformacionBasica>();
            return Json(controlInfoBasica.lfInsert(infoBasica), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult UpdateInformacionBasica([FromBody]tb_informacion_basica infoBasica)
        {
            Response<Boolean> response = new Response<bool>();

            var controlInfoBasica = FactoryIoC.Container.Resolver<ControlInformacionBasica>();
            return Json(controlInfoBasica.lfUpdate(infoBasica), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_informacion_basica>>))]
        public IHttpActionResult GetInformacionBasica()
        {
            Response<List<tb_informacion_basica>> response = new Response<List<tb_informacion_basica>>();

            var controlInfoBasica = FactoryIoC.Container.Resolver<ControlInformacionBasica>();

            return Json(controlInfoBasica.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_informacion_basica>>))]
        public IHttpActionResult GetInformacionBasica(int id)
        {
            Response<List<tb_informacion_basica>> response = new Response<List<tb_informacion_basica>>();

            var controlInfoBasica = FactoryIoC.Container.Resolver<ControlInformacionBasica>();

            return Json(controlInfoBasica.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

    }
}