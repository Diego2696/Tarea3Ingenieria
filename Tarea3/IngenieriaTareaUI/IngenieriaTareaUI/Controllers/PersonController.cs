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
            List<tbPerson> userList = new List<tbPerson>();
            Response<List<tbPerson>> response = new Response<List<tbPerson>>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync("api/person");
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<List<tbPerson>>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    userList = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(userList);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            tbPerson user = new tbPerson();
            Response<tbPerson> response = new Response<tbPerson>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/person/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    user = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(user);
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

            Response<tbPerson> response = new Response<tbPerson>();
            tbPerson user = new tbPerson();
            try
            {
                user.nombre = collection.GetValue("nombre").AttemptedValue.ToString();
                user.id = Int32.Parse(collection.GetValue("id").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(user);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage responseWAPI = await _WsWebAPI.PostAsync("api/person/", byteArrayContent);

                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    user = response.ReturnValue;
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
            tbPerson user = new tbPerson();
            Response<tbPerson> response = new Response<tbPerson>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/person/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    user = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditAction(int id, FormCollection collection)
        {
            Response<tbPerson> response = new Response<tbPerson>();
            tbPerson user = new tbPerson();
            try
            {
                user.nombre = collection.GetValue("nombre").AttemptedValue.ToString();
                user.id = Int32.Parse(collection.GetValue("id").AttemptedValue.ToString());

                String jsonContent = JsonConvert.SerializeObject(user);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonContent);
                ByteArrayContent byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                HttpResponseMessage responseWAPI = await _WsWebAPI.PutAsync(String.Concat("api/person/", id), byteArrayContent);

                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    user = response.ReturnValue;
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
            tbPerson user = new tbPerson();
            Response<tbPerson> response = new Response<tbPerson>();
            try
            {
                HttpResponseMessage responseWAPI = await _WsWebAPI.GetAsync(String.Concat("api/person/", id));
                if (responseWAPI.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                    user = response.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
            }
            return View(user);
        }

        // POST: User/Delete/5
        public async Task<ActionResult> DeleteAction(int id)
        {
            try
            {
                tbPerson user = new tbPerson();
                Response<tbPerson> response = new Response<tbPerson>();
                try
                {
                    HttpResponseMessage responseWAPI = await _WsWebAPI.DeleteAsync(String.Concat("api/person/", id));
                    if (responseWAPI.IsSuccessStatusCode)
                    {
                        response = JsonConvert.DeserializeObject<Response<tbPerson>>(responseWAPI.Content.ReadAsStringAsync().Result);
                        user = response.ReturnValue;
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