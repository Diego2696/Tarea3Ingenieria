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
    public class PersonController : ComunController
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<tb_persona> personaList = new List<tb_persona>();
            Response<List<tb_persona>> response = new Response<List<tb_persona>>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync("api/persona");
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<List<tb_persona>>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    personaList = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(personaList);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            tb_persona persona = new tb_persona();
            Response<tb_persona> response = new Response<tb_persona>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/persona/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    persona = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(persona);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {

            Response<tb_persona> response = new Response<tb_persona>();
            tb_persona persona = new tb_persona();
            try
            {
                persona.nombre = collection.GetValue("nombre").AttemptedValue.ToString();
                persona.id = Int32.Parse(collection.GetValue("id").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage responseWAPI = await _WsWebAPI.PostAsync("api/persona/", byteArrayContent);

                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    persona = response.ReturnValue;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            tb_persona persona = new tb_persona();
            Response<tb_persona> response = new Response<tb_persona>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/persona/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    persona = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(persona);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditAction(int id, FormCollection collection)
        {
            Response<tb_persona> response = new Response<tb_persona>();
            tb_persona persona = new tb_persona();
            try
            {
                persona.nombre = collection.GetValue("nombre").AttemptedValue.ToString();
                persona.id = Int32.Parse(collection.GetValue("id").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(persona);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage responseWAPI = await _WsWebAPI.PutAsync(String.Concat("api/persona/", id), byteArrayContent);

                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    persona = response.ReturnValue;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            tb_persona persona = new tb_persona();
            Response<tb_persona> response = new Response<tb_persona>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/persona/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    persona = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(persona);
        }

        // POST: User/Delete/5
        public async Task<ActionResult> DeleteAction(int id)
        {
            try
            {
                tb_persona persona = new tb_persona();
                Response<tb_persona> response = new Response<tb_persona>();
                try
                {
                    HttpResponseMessage responseWAPI = await _WsWebAPI.DeleteAsync(String.Concat("api/persona/", id));
                    if (responseWAPI.IsSuccessStatusCode)
                    {
                        response = JsonConvert.DeserializeObject<Response<tb_persona>>(responseWAPI.Content.ReadAsStringAsync().Result);
                        persona = response.ReturnValue;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.Write(ex.ToString());
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}