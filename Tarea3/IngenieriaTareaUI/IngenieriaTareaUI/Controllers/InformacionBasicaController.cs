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
    public class InformacionBasicaController : ComunController
    {
        public async Task<ActionResult> Index()
        {
            List<tb_informacion_basica> listaInformacion = new List<tb_informacion_basica>();
            Response<List<tb_informacion_basica>> respuesta = new Response<List<tb_informacion_basica>>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync("api/InformacionBasica");
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<List<tb_informacion_basica>>>(consulta.Content.ReadAsStringAsync().Result);
                    listaInformacion = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(listaInformacion);
        }


        public async Task<ActionResult> buscarInformacionBasica(int id)
        {
            tb_informacion_basica infoBasica = new tb_informacion_basica();
            Response<tb_informacion_basica> respuesta = new Response<tb_informacion_basica>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.GetAsync(String.Concat("api/informacionBasica/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_informacion_basica>>(consulta.Content.ReadAsStringAsync().Result);
                    infoBasica = respuesta.ReturnValue;
                    return View(infoBasica);
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }



        public async Task<ActionResult> CrearInformacionBasica(FormCollection datos)
        {

            Response<tb_informacion_basica> respuesta = new Response<tb_informacion_basica>();
            tb_informacion_basica infoBasica = new tb_informacion_basica();
            try
            {
                infoBasica.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                infoBasica.id_origen = Int32.Parse(datos.GetValue("id_origen").AttemptedValue.ToString());
                infoBasica.id_subcategoria_delito = Int32.Parse(datos.GetValue("id_subcategoria_delito").AttemptedValue.ToString());
                infoBasica.id_modalidad = Int32.Parse(datos.GetValue("id_modalidad").AttemptedValue.ToString());
                infoBasica.id_subvictima = Int32.Parse(datos.GetValue("id_subvictima").AttemptedValue.ToString());
                infoBasica.id_oficina_encargado = Int32.Parse(datos.GetValue("id_oficina_encargado").AttemptedValue.ToString());
                infoBasica.id_delegacion = Int32.Parse(datos.GetValue("id_delegacion").AttemptedValue.ToString());
                infoBasica.tentativo = Int32.Parse(datos.GetValue("tentativo").AttemptedValue.ToString());
                infoBasica.id_hecho = Int32.Parse(datos.GetValue("id_hecho").AttemptedValue.ToString());
                infoBasica.numero_unico = datos.GetValue("numero_unico").AttemptedValue.ToString();
                infoBasica.fecha_ingreso = DateTime.Parse(datos.GetValue("fecha_ingreso").AttemptedValue.ToString());
                infoBasica.perjuicio = datos.GetValue("perjuicio").AttemptedValue.ToString();
                infoBasica.moneda = datos.GetValue("moneda").AttemptedValue.ToString();
                infoBasica.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                infoBasica.narracion = datos.GetValue("narracion").AttemptedValue.ToString();

                String jsonContent = JsonConvert.SerializeObject(infoBasica);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PostAsync("api/informacionBasica/", byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_informacion_basica>>(consulta.Content.ReadAsStringAsync().Result);
                    infoBasica = respuesta.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> actualizarInformacionBasica(int id, FormCollection datos)
        {
            Response<tb_informacion_basica> respuesta = new Response<tb_informacion_basica>();
            tb_informacion_basica infoBasica = new tb_informacion_basica();
            try
            {
                infoBasica.id = Int32.Parse(datos.GetValue("id").AttemptedValue.ToString());
                infoBasica.id_origen = Int32.Parse(datos.GetValue("id_origen").AttemptedValue.ToString());
                infoBasica.id_subcategoria_delito = Int32.Parse(datos.GetValue("id_subcategoria_delito").AttemptedValue.ToString());
                infoBasica.id_modalidad = Int32.Parse(datos.GetValue("id_modalidad").AttemptedValue.ToString());
                infoBasica.id_subvictima = Int32.Parse(datos.GetValue("id_subvictima").AttemptedValue.ToString());
                infoBasica.id_oficina_encargado = Int32.Parse(datos.GetValue("id_oficina_encargado").AttemptedValue.ToString());
                infoBasica.id_delegacion = Int32.Parse(datos.GetValue("id_delegacion").AttemptedValue.ToString());
                infoBasica.tentativo = Int32.Parse(datos.GetValue("tentativo").AttemptedValue.ToString());
                infoBasica.id_hecho = Int32.Parse(datos.GetValue("id_hecho").AttemptedValue.ToString());
                infoBasica.numero_unico = datos.GetValue("numero_unico").AttemptedValue.ToString();
                infoBasica.fecha_ingreso = DateTime.Parse(datos.GetValue("fecha_ingreso").AttemptedValue.ToString());
                infoBasica.perjuicio = datos.GetValue("perjuicio").AttemptedValue.ToString();
                infoBasica.moneda = datos.GetValue("moneda").AttemptedValue.ToString();
                infoBasica.observaciones = datos.GetValue("observaciones").AttemptedValue.ToString();
                infoBasica.narracion = datos.GetValue("narracion").AttemptedValue.ToString();

                String jsonContent = JsonConvert.SerializeObject(infoBasica);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage consulta = await _WsWebAPI.PutAsync(String.Concat("api/informacionBasica/", id), byteArrayContent);

                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_informacion_basica>>(consulta.Content.ReadAsStringAsync().Result);
                    infoBasica = respuesta.ReturnValue;
                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View();
        }


        public async Task<ActionResult> eliminarInformacionBasica(int id)
        {

            tb_informacion_basica infoBasica = new tb_informacion_basica();
            Response<tb_informacion_basica> respuesta = new Response<tb_informacion_basica>();
            try
            {
                HttpResponseMessage consulta = await _WsWebAPI.DeleteAsync(String.Concat("api/informacionBasica/", id));
                if (consulta.IsSuccessStatusCode)
                {
                    respuesta = JsonConvert.DeserializeObject<Response<tb_informacion_basica>>(consulta.Content.ReadAsStringAsync().Result);
                    infoBasica = respuesta.ReturnValue;
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