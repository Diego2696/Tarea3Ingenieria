using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JSONAtributo : Attribute
{
}

public class JSONAsociacionParametro : HttpParameterBinding
{
    private JsonSerializerSettings JsonSetting = new JsonSerializerSettings();
    private JsonSerializer _serializador = new JsonSerializer();
    public JSONAsociacionParametro(HttpParameterDescriptor descriptor) : base(descriptor)
    {
        JsonSetting.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        _serializador = JsonSerializer.Create(JsonSetting);
    }

    public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
    {
        JObject jobj = ObtenerJSONParametros(actionContext.Request);
        object value = null;
        JToken jTokenVal = null;
        if (!(jobj.TryGetValue(Descriptor.ParameterName, out jTokenVal)))
        {
            if ((Descriptor.IsOptional))
            {
                value = Descriptor.DefaultValue;
            }
            else
            {
                throw new MissingFieldException("Parámetro No Encontrado : " + Descriptor.ParameterName);
            }
        }
        else
        {
            try
            {
                value = jTokenVal.ToObject(Descriptor.ParameterType, _serializador);
            }
            catch (Exception ex)
            {
                throw new HttpParseException(string.Join("", "No se pudo procesar el parámetro: ", Descriptor.ParameterName, ". Type: ", Descriptor.ParameterType.ToString()));
            }
        }

        SetValue(actionContext, value);
        TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
        //tcs.SetResult();
        return tcs.Task;
    }

    public static HttpParameterBinding HookupAsociacionParametros(HttpParameterDescriptor descriptor)
    {
        if ((descriptor.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<JSONAtributo>().Count == 0 & descriptor.ActionDescriptor.GetCustomAttributes<JSONAtributo>().Count == 0))
        {
            return null;
        }

        var supportedMethods = descriptor.ActionDescriptor.SupportedHttpMethods;
        if ((supportedMethods.Contains(HttpMethod.Post) | supportedMethods.Contains(HttpMethod.Get)))
        {
            return new JSONAsociacionParametro(descriptor);
        }

        return null;
    }

    private JObject ObtenerJSONParametros(HttpRequestMessage request)
    {
        JObject jobj = null;
        object result = null;
        if (!(request.Properties.TryGetValue("ParamsJSObject", out result)))
        {
            if ((request.Method == HttpMethod.Post))
            {
                jobj = JObject.Parse(request.Content.ReadAsStringAsync().Result);
            }
            else
            {
                if ((request.RequestUri.Query.StartsWith("?%7B")))
                {
                    jobj = JObject.Parse(HttpUtility.UrlDecode(request.RequestUri.Query).TrimStart('?'));
                }
                else
                {
                    jobj = new JObject();
                    foreach (var kvp in request.GetQueryNameValuePairs())
                    {
                        jobj.Add(kvp.Key, JToken.Parse(kvp.Value));
                    }
                }

                request.Properties.Add("ParamsJSObject", jobj);
            }
        }
        else
        {
            jobj = (JObject)result;
        }

        return jobj;
    }

    private struct AsyncVoid
    {
    }
}