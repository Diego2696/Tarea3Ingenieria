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
    public class PersonaJuridicaController : ComunController
    {
        public async Task<ActionResult> Index()
        {
            List<tb_persona_juridica> listaPersonas = new List<tb_persona_juridica>();
            Response<List<tb_persona_juridica>> respuesta = new Response<List<tb_persona_juridica>>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync("api/personaJuridica");
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<List<tb_persona_juridica>>>(consulta.Content.ReadAsStringAsync().Result);
                    listaPersonas = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(listaPersonas);
        }


        public async Task<ActionResult> buscarPersonaJuridica(int id)
        {
            tb_persona_juridica persona = new tb_persona_juridica();
            Response<tb_persona_juridica> respuesta = new Response<tb_persona_juridica>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync(String.Concat("api/personaJuridica/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona_juridica>>(consulta.Content.ReadAsStringAsync().Result);
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



        public async Task<ActionResult> CreatePersonJuridica(FormCollection datos)
        {

            Response<tb_persona_juridica> respuesta = new Response<tb_persona_juridica>();
            tb_persona_juridica persona = new tb_persona_juridica();
            try
            {
                persona.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                persona.cedula_juridica = datos.GetValue("cedula_juridica").AttemptedValue.ToString();
                persona.razon_social = datos.GetValue("razon_social").AttemptedValue.ToString();
                persona.id_nombre_fantasia = Int32.Parse(datos.GetValue("id_nombre_fantasia").AttemptedValue.ToString());
                persona.filial = datos.GetValue("filial").AttemptedValue.ToString();
                persona.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                persona.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                persona.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                persona.allanada = Int32.Parse(datos.GetValue("allanada").AttemptedValue.ToString());
                persona.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                persona.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());


                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PostAsync("api/personaJuridica/", byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona_juridica>>(consulta.Content.ReadAsStringAsync().Result);
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
        public async Task<ActionResult> actualizarPersonaJuridica(int id, FormCollection datos)
        {
            Response<tb_persona_juridica> respuesta = new Response<tb_persona_juridica>();
            tb_persona_juridica persona = new tb_persona_juridica();
            try
            {
                persona.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                persona.cedula_juridica = datos.GetValue("cedula_juridica").AttemptedValue.ToString();
                persona.razon_social = datos.GetValue("razon_social").AttemptedValue.ToString();
                persona.id_nombre_fantasia = Int32.Parse(datos.GetValue("id_nombre_fantasia").AttemptedValue.ToString());
                persona.filial = datos.GetValue("filial").AttemptedValue.ToString();
                persona.nombre_entidad = datos.GetValue("nombre_entidad").AttemptedValue.ToString();
                persona.id_intensidad = Int32.Parse(datos.GetValue("id_intensidad").AttemptedValue.ToString());
                persona.atributo = datos.GetValue("atributo").AttemptedValue.ToString();
                persona.allanada = Int32.Parse(datos.GetValue("allanada").AttemptedValue.ToString());
                persona.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                persona.id_rol = Int32.Parse(datos.GetValue("id_rol").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PutAsync(String.Concat("api/personaJuridica/", id), byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona_juridica>>(consulta.Content.ReadAsStringAsync().Result);
                    persona = respuesta.ReturnValue;
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> eliminarPersonaJuridica(int id)
        {

            tb_persona_juridica persona = new tb_persona_juridica();
            Response<tb_persona_juridica> respuesta = new Response<tb_persona_juridica>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.DeleteAsync(String.Concat("api/personaJuridica/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_persona_juridica>>(consulta.Content.ReadAsStringAsync().Result);
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