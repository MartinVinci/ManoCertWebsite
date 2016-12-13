using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManoCertWebSite
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertWebhook();
        }
        private static int RandomNumber(int maxNumber)
        {
            Random rand = new Random();

            return rand.Next(0, maxNumber);
        }
        private static void AlertWebhook()
        {
            var browser = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            var localAddr = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];

            string sURL;
            sURL = @"https://allstarfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=jUVJFswk2tnt9gDvKmTvKmuJmP8sXlF4yrmLNJxTwSxa1wwJ6pukkA==&name=";

            sURL += RandomNumber(999);
            sURL += localAddr;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();



        }
    }
}