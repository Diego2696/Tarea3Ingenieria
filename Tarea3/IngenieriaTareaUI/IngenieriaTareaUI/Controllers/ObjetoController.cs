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
    public class ObjetoController : ComunController
    {
        public async Task<ActionResult> Index()
        {
            List<tb_objeto> listaObjetos = new List<tb_objeto>();
            Response<List<tb_objeto>> respuesta = new Response<List<tb_objeto>>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync("api/objeto");
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<List<tb_objeto>>>(consulta.Content.ReadAsStringAsync().Result);
                    listaObjetos = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(listaObjetos);
        }


        public async Task<ActionResult> buscarObjeto(int id)
        {
            tb_objeto objeto = new tb_objeto();
            Response<tb_objeto> respuesta = new Response<tb_objeto>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync(String.Concat("api/objeto/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_objeto>>(consulta.Content.ReadAsStringAsync().Result);
                    objeto = respuesta.ReturnValue;
                    return View(objeto);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }



        public async Task<ActionResult> crearObjeto(FormCollection datos)
        {

            Response<tb_objeto> respuesta = new Response<tb_objeto>();
            tb_objeto objeto = new tb_objeto();
            try
            {
                objeto.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                objeto.id_subtipo = Int32.Parse(datos.GetValue("id_subtipo").AttemptedValue.ToString());
                objeto.serie = datos.GetValue("serie").AttemptedValue.ToString();
                objeto.marca = datos.GetValue("marca").AttemptedValue.ToString();
                objeto.modelo = datos.GetValue("modelo").AttemptedValue.ToString();
                objeto.id_color = Int32.Parse(datos.GetValue("id_color").AttemptedValue.ToString());
                objeto.descripcion = datos.GetValue("descripcion").AttemptedValue.ToString();
                objeto.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                objeto.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                objeto.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                objeto.decomisado = Int32.Parse(datos.GetValue("decomisado").AttemptedValue.ToString());
                objeto.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                objeto.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(objeto);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PostAsync("api/objeto/", byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_objeto>>(consulta.Content.ReadAsStringAsync().Result);
                    objeto = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> actualizarObjeto(int id, FormCollection datos)
        {
            Response<tb_objeto> respuesta = new Response<tb_objeto>();
            tb_objeto objeto = new tb_objeto();
            try
            {
                objeto.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                objeto.id_subtipo = Int32.Parse(datos.GetValue("id_subtipo").AttemptedValue.ToString());
                objeto.serie = datos.GetValue("serie").AttemptedValue.ToString();
                objeto.marca = datos.GetValue("marca").AttemptedValue.ToString();
                objeto.modelo = datos.GetValue("modelo").AttemptedValue.ToString();
                objeto.id_color = Int32.Parse(datos.GetValue("id_color").AttemptedValue.ToString());
                objeto.descripcion = datos.GetValue("descripcion").AttemptedValue.ToString();
                objeto.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                objeto.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                objeto.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                objeto.decomisado = Int32.Parse(datos.GetValue("decomisado").AttemptedValue.ToString());
                objeto.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                objeto.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(objeto);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PutAsync(String.Concat("api/objeto/", id), byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_objeto>>(consulta.Content.ReadAsStringAsync().Result);
                    objeto = respuesta.ReturnValue;
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> eliminarObjeto(int id)
        {

            tb_objeto objeto = new tb_objeto();
            Response<tb_objeto> respuesta = new Response<tb_objeto>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.DeleteAsync(String.Concat("api/objeto/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_objeto>>(consulta.Content.ReadAsStringAsync().Result);
                    objeto = respuesta.ReturnValue;
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