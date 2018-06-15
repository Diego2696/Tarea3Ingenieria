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
    [RoutePrefix("api/color")]
    public class ColorController : ApiController
    {
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeleteColor(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlColor = FactoryIoC.Container.Resolver<ControlColor>();

            return Json(controlColor.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult InsertColor([FromBody]tb_color color)
        {
            Response<Boolean> response = new Response<bool>();

            var controlColor = FactoryIoC.Container.Resolver<ControlColor>();
            return Json(controlColor.lfInsert(color), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult UpdateColor([FromBody]tb_color color)
        {
            Response<Boolean> response = new Response<bool>();

            var controlColor = FactoryIoC.Container.Resolver<ControlColor>();
            return Json(controlColor.lfUpdate(color), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_color>>))]
        public IHttpActionResult GetColor()
        {
            Response<List<tb_color>> response = new Response<List<tb_color>>();

            var controlColor = FactoryIoC.Container.Resolver<ControlColor>();

            return Json(controlColor.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_color>>))]
        public IHttpActionResult GetColor(int id)
        {
            Response<List<tb_color>> response = new Response<List<tb_color>>();

            var controlColor = FactoryIoC.Container.Resolver<ControlColor>();

            return Json(controlColor.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }
    }
}