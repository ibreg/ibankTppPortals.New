using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ibankTppPortals.New
{
    public class IndexController : ApiController
    {
        static string indexContent = null;
        static object contentLock = new object();
        static string getIndexContent()
        {
            if (indexContent == null)
            {
                lock (contentLock)
                {
                    if (indexContent == null)
                    {
                        using (FileStream fs = new FileStream(HttpRuntime.AppDomainAppPath + "dist/index.html", FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                indexContent = sr.ReadToEnd();
                            }
                        }

                        indexContent = ReplaceFromAppSettings(indexContent, "[basehRef]", "basehRef");
                        indexContent = ReplaceFromAppSettings(indexContent, "[contextPath]", "contextPath");
                    }
                }
            }

            return indexContent;
        }

        private static string ReplaceFromAppSettings(string content, string token, string appSettingsKey)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[appSettingsKey] != null)
            {
                return content.Replace(token, System.Configuration.ConfigurationManager.AppSettings[appSettingsKey]);
            }
            return content;
        }
        HttpResponseMessage getResponse(string content)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(content)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        [HttpGet, HttpPost]
        public HttpResponseMessage Get()
        {
            if (Request.Method == HttpMethod.Post)
            {
                return RedirectPost();
            }

            var index = getIndexContent();
            return getResponse(index);
        }

        HttpResponseMessage RedirectPost()
        {
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri(Request.RequestUri.AbsoluteUri);
            return response;
        }
    }
}