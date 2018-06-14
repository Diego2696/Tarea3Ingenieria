using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace IngenieriaTareaUI.Controllers
{
    public class ComunController : Controller
    {
        #region
        public HttpClient _WsWebAPI;
        string _UrlWsAPI = System.Configuration.ConfigurationManager.AppSettings["URLWebAPI"].ToString();
        #endregion

        public ComunController()
        {
            _WsWebAPI = new HttpClient();
            _WsWebAPI.BaseAddress = new System.Uri(_UrlWsAPI);
            _WsWebAPI.DefaultRequestHeaders.Accept.Clear();
            _WsWebAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}