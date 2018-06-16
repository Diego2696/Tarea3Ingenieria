using Domain.Entities;
using Domain.UTL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IngenieriaTareaUI.Controllers
{
    public class VehiculoController : ComunController
    {
        public async Task<ActionResult> Index()
        {
            List<tb_vehiculo> listaVehiculos = new List<tb_vehiculo>();
            Response<List<tb_vehiculo>> respuesta = new Response<List<tb_vehiculo>>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync("api/vehiculo");
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<List<tb_vehiculo>>>(consulta.Content.ReadAsStringAsync().Result);
                    listaVehiculos = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(listaVehiculos);
        }


        public async Task<ActionResult> buscarVehiculo(int id)
        {
            tb_vehiculo vehiculo = new tb_vehiculo();
            Response<tb_vehiculo> respuesta = new Response<tb_vehiculo>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync(String.Concat("api/vehiculo/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_vehiculo>>(consulta.Content.ReadAsStringAsync().Result);
                    vehiculo = respuesta.ReturnValue;
                    return View(vehiculo);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }

        public async Task<ActionResult> crearVehiculo(FormCollection datos)
        {

            Response<tb_vehiculo> respuesta = new Response<tb_vehiculo>();
            tb_vehiculo vehiculo = new tb_vehiculo();
            try
            {
                vehiculo.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                vehiculo.id_tipo_identificacion = Int32.Parse(datos.GetValue("id_tipo_identificacion").AttemptedValue.ToString());
                vehiculo.numero_identificacion = datos.GetValue("numero_identificacion").AttemptedValue.ToString();
                vehiculo.id_clase = Int32.Parse(datos.GetValue("id_clase").AttemptedValue.ToString());
                vehiculo.numero_bien = datos.GetValue("numero_bien").AttemptedValue.ToString();
                vehiculo.anno = datos.GetValue("anno").AttemptedValue.ToString();
                vehiculo.poliza = Int32.Parse(datos.GetValue("poliza").AttemptedValue.ToString());
                vehiculo.decomisado = Int32.Parse(datos.GetValue("decomisado").AttemptedValue.ToString());
                vehiculo.id_marca = Int32.Parse(datos.GetValue("id_marca").AttemptedValue.ToString());
                vehiculo.id_color = Int32.Parse(datos.GetValue("id_color").AttemptedValue.ToString());
                vehiculo.estilo = datos.GetValue("estilo").AttemptedValue.ToString();
                vehiculo.id_aseguradora = Int32.Parse(datos.GetValue("id_aseguradora").AttemptedValue.ToString());
                vehiculo.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                vehiculo.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                vehiculo.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                vehiculo.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                vehiculo.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(vehiculo);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PostAsync("api/vehiculo/", byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_vehiculo>>(consulta.Content.ReadAsStringAsync().Result);
                    vehiculo = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> actualizarVehiculo(int id, FormCollection datos)
        {
            Response<tb_vehiculo> respuesta = new Response<tb_vehiculo>();
            tb_vehiculo vehiculo = new tb_vehiculo();
            try
            {
                vehiculo.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                vehiculo.id_tipo_identificacion = Int32.Parse(datos.GetValue("id_tipo_identificacion").AttemptedValue.ToString());
                vehiculo.numero_identificacion = datos.GetValue("numero_identificacion").AttemptedValue.ToString();
                vehiculo.id_clase = Int32.Parse(datos.GetValue("id_clase").AttemptedValue.ToString());
                vehiculo.numero_bien = datos.GetValue("numero_bien").AttemptedValue.ToString();
                vehiculo.anno = datos.GetValue("anno").AttemptedValue.ToString();
                vehiculo.poliza = Int32.Parse(datos.GetValue("poliza").AttemptedValue.ToString());
                vehiculo.decomisado = Int32.Parse(datos.GetValue("decomisado").AttemptedValue.ToString());
                vehiculo.id_marca = Int32.Parse(datos.GetValue("id_marca").AttemptedValue.ToString());
                vehiculo.id_color = Int32.Parse(datos.GetValue("id_color").AttemptedValue.ToString());
                vehiculo.estilo = datos.GetValue("estilo").AttemptedValue.ToString();
                vehiculo.id_aseguradora = Int32.Parse(datos.GetValue("id_aseguradora").AttemptedValue.ToString());
                vehiculo.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                vehiculo.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                vehiculo.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                vehiculo.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                vehiculo.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(vehiculo);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PutAsync(String.Concat("api/vehiculo/", id), byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_vehiculo>>(consulta.Content.ReadAsStringAsync().Result);
                    vehiculo = respuesta.ReturnValue;
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> eliminarVehiculo(int id)
        {

            tb_vehiculo vehiculo = new tb_vehiculo();
            Response<tb_vehiculo> respuesta = new Response<tb_vehiculo>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.DeleteAsync(String.Concat("api/vehiculo/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_vehiculo>>(consulta.Content.ReadAsStringAsync().Result);
                    vehiculo = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }
    }
}