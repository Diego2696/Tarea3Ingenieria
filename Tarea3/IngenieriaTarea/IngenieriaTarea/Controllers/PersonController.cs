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
    [RoutePrefix("api/person")]
    public class PersonController : ApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_persona>>))]
        public IHttpActionResult GetPerson()
        {
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();

            var userLN = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(userLN.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<tb_persona>))]
        public IHttpActionResult GetPerson(int id)
        {
            Response<tb_persona> response = new Response<tb_persona>();

            var userLN = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(userLN.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeletePerson(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var userLN = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(userLN.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<tb_persona>))]
        public IHttpActionResult InsertPerson([FromBody]tb_persona user)
        {

            ControlPerson userLN = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(userLN.lfInsert(user), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<tb_persona>))]
        public IHttpActionResult UpdatePerson([FromBody]tb_persona user)
        {
            ControlPerson userLN = FactoryIoC.Container.Resolver<ControlPerson>();

            return Json(userLN.lfUpdate(user), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

    }
}