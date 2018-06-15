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
    [RoutePrefix("api/objeto")]
    public class ObjetoController : ApiController
    {
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_objeto>>))]
        public IHttpActionResult GetObjeto()
        {
            Response<List<tb_objeto>> response = new Response<List<tb_objeto>>();

            var controlObjeto = FactoryIoC.Container.Resolver<ControlObjeto>();

            return Json(controlObjeto.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<tb_objeto>))]
        public IHttpActionResult GetObjeto(int id)
        {
            Response<tb_objeto> response = new Response<tb_objeto>();

            var controlObjeto = FactoryIoC.Container.Resolver<ControlObjeto>();

            return Json(controlObjeto.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeleteObjeto(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlObjeto = FactoryIoC.Container.Resolver<ControlObjeto>();

            return Json(controlObjeto.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<tb_objeto>))]
        public IHttpActionResult InsertObjeto([FromBody]tb_objeto objeto)
        {

            ControlObjeto controlObjeto = FactoryIoC.Container.Resolver<ControlObjeto>();

            return Json(controlObjeto.lfInsert(objeto), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<tb_objeto>))]
        public IHttpActionResult UpdateObjeto([FromBody]tb_objeto objeto)
        {
            ControlObjeto controlObjeto = FactoryIoC.Container.Resolver<ControlObjeto>();

            return Json(controlObjeto.lfUpdate(objeto), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

    }
}