using System.Web.Optimization;

namespace AugularJsFrameworkDemo.Areas.Form
{
    public class FormAreaBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string ngAppBasePath = "~/Areas/Form/Scripts/app";
            bundles.Add(new ScriptBundle("~/js/app-forms").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-ui-router.js",

                // ** APP MODULE ** //

                ngAppBasePath + "/app.module.js",

                //// ** COMMON ** //

                ngAppBasePath + "/../common/common.module.js",
                ngAppBasePath + "/../common/util.service.js",

                // ** CORE MODULE ** //

                ngAppBasePath + "/core/core.module.js",
                 ngAppBasePath + "/core/normalFormResource.service.js",

                // ** FORM MODULE ** //

                ngAppBasePath + "/controller/normalForm/normalForm.module.js",
                ngAppBasePath + "/controller/normalForm/normalForm.controller.js"
                ));
        }
    }
}