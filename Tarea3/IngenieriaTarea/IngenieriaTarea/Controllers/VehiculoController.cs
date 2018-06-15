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
    [RoutePrefix("api/vehiculo")]
    public class VehiculoController : ApiController
    {
        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult DeleteVehiculo(int id)
        {
            Response<Boolean> response = new Response<bool>();

            var controlVehiculo = FactoryIoC.Container.Resolver<ControlVehiculo>();

            return Json(controlVehiculo.lfDelete(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult InsertVehiculo([FromBody]tb_vehiculo vehiculo)
        {
            Response<Boolean> response = new Response<bool>();

            var controlVehiculo = FactoryIoC.Container.Resolver<ControlVehiculo>();
            return Json(controlVehiculo.lfInsert(vehiculo), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpPut]
        [ResponseType(typeof(Response<Boolean>))]
        public IHttpActionResult UpdateVehiculo([FromBody]tb_vehiculo vehiculo)
        {
            Response<Boolean> response = new Response<bool>();

            var controlVehiculo = FactoryIoC.Container.Resolver<ControlVehiculo>();
            return Json(controlVehiculo.lfUpdate(vehiculo), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_vehiculo>>))]
        public IHttpActionResult GetVehiculo()
        {
            Response<List<tb_vehiculo>> response = new Response<List<tb_vehiculo>>();

            var controlVehiculo = FactoryIoC.Container.Resolver<ControlVehiculo>();

            return Json(controlVehiculo.lfGet(), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }

        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Response<List<tb_vehiculo>>))]
        public IHttpActionResult GetVehiculo(int id)
        {
            Response<List<tb_vehiculo>> response = new Response<List<tb_vehiculo>>();

            var controlVehiculo = FactoryIoC.Container.Resolver<ControlVehiculo>();

            return Json(controlVehiculo.lfGet(id), new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
        }
    }
}