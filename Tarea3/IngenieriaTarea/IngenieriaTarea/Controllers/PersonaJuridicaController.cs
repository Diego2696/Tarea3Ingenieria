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
    [RoutePrefix("api/personaJuridica")]
    public class PersonaJuridicaController : ApiController
    {
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeletePersonaJuridica(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersonaJuridica = FactoryIoC.Container.Resolver<ControlPersonaJuridica>();

            return Json(controlPersonaJuridica.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult InsertPersonaJuridica([FromBody]tb_persona_juridica personaJuridica)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersonaJuridica = FactoryIoC.Container.Resolver<ControlPersonaJuridica>();
            return Json(controlPersonaJuridica.lfInsert(personaJuridica), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult UpdatePersonaJuridica([FromBody]tb_persona_juridica personaJuridica)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersonaJuridica = FactoryIoC.Container.Resolver<ControlPersonaJuridica>();
            return Json(controlPersonaJuridica.lfUpdate(personaJuridica), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_persona_juridica>>))]
        public IHttpActionResult GetPersonaJuridica()
        {
            Response<List<tb_persona_juridica>> response = new Response<List<tb_persona_juridica>>();

            var controlPersonaJuridica = FactoryIoC.Container.Resolver<ControlPersonaJuridica>();

            return Json(controlPersonaJuridica.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_persona_juridica>>))]
        public IHttpActionResult GetPersonaJuridica(int id)
        {
            Response<List<tb_persona_juridica>> response = new Response<List<tb_persona_juridica>>();

            var controlPersonaJuridica = FactoryIoC.Container.Resolver<ControlPersonaJuridica>();

            return Json(controlPersonaJuridica.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }
    }
}