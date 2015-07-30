using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PollPlus.Helpers;
using PollPlus.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PollPlus.Service
{
    public class EnvioPush
    {
        protected String _application;
        protected String _auth;
        protected String _urlPushWoosh = "https://cp.pushwoosh.com/json/1.3/";

        public EnvioPush()
        { }

        public Boolean EnviarPushNotification(string p_novoPush)
        {
            if (String.IsNullOrEmpty(p_novoPush))
                return false;

            var _jsonPushWoosh = this.MontarJObjectPushWoosh(p_novoPush);
            return this.EnviarPushNotification(_jsonPushWoosh);
        }

        public Boolean EnviarPushNotification(List<string> p_novoPush, string texto)
        {
            if (p_novoPush == null || !p_novoPush.Any())
                return false;

            var envio = false;

            foreach (var item in p_novoPush)
            {
                var _jsonPushWoosh = this.MontarJObjectPushWoosh(item, texto);
                this.EnviarPushNotification(_jsonPushWoosh);
                envio = true;
            }
            return envio;   
        }

        protected Boolean EnviarPushNotification(JObject p_objectPushWoosh)
        {
            var _retornoPostEnvio = this.PWCall("createMessage", p_objectPushWoosh);
            return this.EnvioDaRequisicaoComSucesso(_retornoPostEnvio);
        }

        protected JObject MontarJObjectPushWoosh(string p_novoPush)
        {
            this._application = "DD549-64BF7";
            this._auth = "2DftEBtCFBzbVsDcg6TjPkBnvigctPIbDxFg465BIdzEkMPJ0Vg0danWEYI3YNnk6zJarPPsezIT6ME6X36O";

            return new JObject(
                new JProperty("application", this._application),
                new JProperty("auth", this._auth),
                new JProperty("notifications",
                    new JArray(
                        new JObject(
                            new JProperty("send_date", "now"),
                            new JProperty("content", p_novoPush)
                               ))));
        }

        protected JObject MontarJObjectPushWoosh(string p_novoPush, string texto)
        {
            this._application = "DD549-64BF7";
            this._auth = "2DftEBtCFBzbVsDcg6TjPkBnvigctPIbDxFg465BIdzEkMPJ0Vg0danWEYI3YNnk6zJarPPsezIT6ME6X36O";

            var agg = p_novoPush;

            return new JObject(
                new JProperty("application", this._application),
                new JProperty("auth", this._auth),
                new JProperty("notifications",
                    new JArray(
                        new JObject(
                            new JProperty("send_date", "now"),
                            new JProperty("content", texto),
                            new JProperty("devices", new JArray(agg))
                            ))));
        }

        protected String PWCall(string action, JObject data)
        {
            var url = new Uri("https://cp.pushwoosh.com/json/1.3/" + action);
            var json = new JObject(new JProperty("request", data));

            return DoPostRequest(url, json);
        }

        protected String DoPostRequest(Uri url, JObject data)
        {
            HttpWebResponse httpResponse;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.ContentType = "text/json";
            req.Method = "POST";

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(data.ToString());
            }

            try
            {
                httpResponse = (HttpWebResponse)req.GetResponse();
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Problem with {0}, {1}", url, exc.Message));
            }

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }

        protected Boolean EnvioDaRequisicaoComSucesso(String p_retornoPost)
        {
            return !String.IsNullOrEmpty(p_retornoPost) && p_retornoPost.Contains("200");
        }
    }
}
