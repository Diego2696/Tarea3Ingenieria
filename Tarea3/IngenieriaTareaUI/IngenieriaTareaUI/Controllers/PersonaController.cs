using Domain.Entities;
using Domain.UTL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace IngenieriaTareaUI.Controllers
{
    public class PersonaController : ComunController
    {
        public async Task<ActionResult> Index()
        {
            List<tb_persona> listaPersonas = new List<tb_persona>();
            Response<List<tb_persona>> respuesta = new Response<List<tb_persona>>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync("api/persona");
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<List<tb_persona>>>(consulta.Content.ReadAsStringAsync().Result);
                    listaPersonas = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(listaPersonas);
        }


        public async Task<ActionResult> buscarPersona(int id)
        {
            tb_persona persona = new tb_persona();
            Response<tb_persona> respuesta = new Response<tb_persona>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync(String.Concat("api/persona/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona>>(consulta.Content.ReadAsStringAsync().Result);
                    persona = respuesta.ReturnValue;
                    return View(persona);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }



        public async Task<ActionResult> CreatePerson(FormCollection datos)
        {

            Response<tb_persona> respuesta = new Response<tb_persona>();
            tb_persona persona = new tb_persona();
            try
            {
                persona.nombre = datos.GetValue("nombre").AttemptedValue.ToString();
                persona.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                persona.id_tipo_identificacion = Int32.Parse(datos.GetValue("id_tipo_identificacion").AttemptedValue.ToString());
                persona.primer_apellido = datos.GetValue("primer_apellido").AttemptedValue.ToString();
                persona.segundo_apellido = datos.GetValue("segundo_apellido").AttemptedValue.ToString();
                persona.id_estado_civil = Int32.Parse(datos.GetValue("id_estado_civil").AttemptedValue.ToString());
                persona.sexo = datos.GetValue("sexo").AttemptedValue.ToString();
                persona.nacionalidad = datos.GetValue("nacionalidad").AttemptedValue.ToString();
                persona.detenido = Int32.Parse(datos.GetValue("detenido").AttemptedValue.ToString());
                persona.desaparecido = Int32.Parse(datos.GetValue("desaparecido").AttemptedValue.ToString());
                persona.revisado_reten = Int32.Parse(datos.GetValue("revisado_reten").AttemptedValue.ToString());
                persona.oficio_profesion = datos.GetValue("oficio_profesion").AttemptedValue.ToString();
                persona.expediente_criminal = datos.GetValue("expedienteCriminal").AttemptedValue.ToString();
                persona.fecha_nacimiento = DateTime.Parse(datos.GetValue("nacionalidad").AttemptedValue.ToString());
                persona.edad = Int32.Parse(datos.GetValue("edad").AttemptedValue.ToString());
                persona.id_subgrupo_victima = Int32.Parse(datos.GetValue("id_subgrupo_victima").AttemptedValue.ToString());
                persona.numero_autopsia = Int32.Parse(datos.GetValue("numero_autopsia").AttemptedValue.ToString());
                persona.id_tipo_muerte = Int32.Parse(datos.GetValue("id_tipo_muerte").AttemptedValue.ToString());
                persona.id_funcion = Int32.Parse(datos.GetValue("id_funcion").AttemptedValue.ToString());
                persona.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                persona.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                persona.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());
                persona.id_oficial_policia = Int32.Parse(datos.GetValue("id_oficial_policia").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PostAsync("api/persona/", byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona>>(consulta.Content.ReadAsStringAsync().Result);
                    persona = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> actualizarPersona(int id, FormCollection datos)
        {
            Response<tb_persona> respuesta = new Response<tb_persona>();
            tb_persona persona = new tb_persona();
            try
            {
                persona.nombre = datos.GetValue("nombre").AttemptedValue.ToString();
                persona.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                persona.id_tipo_identificacion = Int32.Parse(datos.GetValue("id_tipo_identificacion").AttemptedValue.ToString());
                persona.primer_apellido = datos.GetValue("primer_apellido").AttemptedValue.ToString();
                persona.segundo_apellido = datos.GetValue("segundo_apellido").AttemptedValue.ToString();
                persona.id_estado_civil = Int32.Parse(datos.GetValue("id_estado_civil").AttemptedValue.ToString());
                persona.sexo = datos.GetValue("sexo").AttemptedValue.ToString();
                persona.nacionalidad = datos.GetValue("nacionalidad").AttemptedValue.ToString();
                persona.detenido = Int32.Parse(datos.GetValue("detenido").AttemptedValue.ToString());
                persona.desaparecido = Int32.Parse(datos.GetValue("desaparecido").AttemptedValue.ToString());
                persona.revisado_reten = Int32.Parse(datos.GetValue("revisado_reten").AttemptedValue.ToString());
                persona.oficio_profesion = datos.GetValue("oficio_profesion").AttemptedValue.ToString();
                persona.expediente_criminal = datos.GetValue("expedienteCriminal").AttemptedValue.ToString();
                persona.fecha_nacimiento = DateTime.Parse(datos.GetValue("nacionalidad").AttemptedValue.ToString());
                persona.edad = Int32.Parse(datos.GetValue("edad").AttemptedValue.ToString());
                persona.id_subgrupo_victima = Int32.Parse(datos.GetValue("id_subgrupo_victima").AttemptedValue.ToString());
                persona.numero_autopsia = Int32.Parse(datos.GetValue("numero_autopsia").AttemptedValue.ToString());
                persona.id_tipo_muerte = Int32.Parse(datos.GetValue("id_tipo_muerte").AttemptedValue.ToString());
                persona.id_funcion = Int32.Parse(datos.GetValue("id_funcion").AttemptedValue.ToString());
                persona.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                persona.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                persona.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());
                persona.id_oficial_policia = Int32.Parse(datos.GetValue("id_oficial_policia").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PutAsync(String.Concat("api/persona/", id), byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona>>(consulta.Content.ReadAsStringAsync().Result);
                    persona = respuesta.ReturnValue;
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> eliminarPersona(int id)
        {

            tb_persona persona = new tb_persona();
            Response<tb_persona> respuesta = new Response<tb_persona>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.DeleteAsync(String.Concat("api/persona/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona>>(consulta.Content.ReadAsStringAsync().Result);
                    persona = respuesta.ReturnValue;
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