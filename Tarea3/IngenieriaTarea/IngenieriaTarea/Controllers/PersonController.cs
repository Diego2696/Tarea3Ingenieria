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
    [RoutePrefix("api/persona")]
    public class PersonController : ApiController
    {
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeletePersona(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersona = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(controlPersona.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult InsertPersona([FromBody]tb_persona persona)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersona = FactoryIoC.Container.Resolver<ControlPerson>();
            return Json(controlPersona.lfInsert(persona), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult UpdatePersona([FromBody]tb_persona persona)
        {
            Response<Boolean> response = new Response<bool>();

            var controlPersona = FactoryIoC.Container.Resolver<ControlPerson>();
            return Json(controlPersona.lfUpdate(persona), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_persona>>))]
        public IHttpActionResult GetPersona()
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            var controlPersona = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(controlPersona.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_persona>>))]
        public IHttpActionResult GetPersona(int id)
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            var controlPersona = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(controlPersona.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }
    }
}