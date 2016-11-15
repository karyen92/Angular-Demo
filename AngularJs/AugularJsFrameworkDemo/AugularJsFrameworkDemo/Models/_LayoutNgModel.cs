using System.Reflection;
using System.Web.Mvc;

namespace AugularJsFrameworkDemo.Models
{
    public class _LayoutNgModel
    {
        public static _LayoutNgModel GetLayoutModel(WebViewPage<dynamic> page)
        {
            return new _LayoutNgModel(page);
        }
        private WebViewPage<dynamic> Page { get; set; }
        private _LayoutNgModel(WebViewPage<dynamic> page)
        {
            Page = page;
        }

        public string NgAppModule
        {
            get { return Page.ViewBag._NgAppModule; }
        }

        public string FooterText
        {
            get { return "&copy; DEMO"; }
        }

        //public string GoogleAnalyticScript
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["view:gatag"];
        //    }
        //}

        //public string RunningVersion
        //{
        //    get
        //    {
        //        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        //    }
        //}
    }
}
