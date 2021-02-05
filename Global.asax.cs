using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace ibankTppPortals.New
{
    public class Global : HttpApplication
    {


        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Configure();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            if (string.Compare(Request.Path, Request.ApplicationPath, StringComparison.InvariantCultureIgnoreCase) ==
                0 &&
                !(Request.Path.EndsWith("/")))
            {
                Response.Redirect(Request.Path + "/", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Application_EndRequest()
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HandleAplicationError();
        }

        private void HandleAplicationError()
        {
            // Log the exception.
            Exception exception = Server.GetLastError();
            Response.Clear();
            // Clear the error on server.
            // Avoid IIS7 getting in the middle
            Server.ClearError();
            LogLastException(exception);
            SetResponse(exception);
        }
        private void LogLastException(Exception exception)
        {
            //handle error logic
        }

        private void SetResponse(Exception exception)
        {
            //response logic
        }
    }
}