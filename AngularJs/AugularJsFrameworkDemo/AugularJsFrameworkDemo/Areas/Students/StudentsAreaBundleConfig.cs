using System.Web.Optimization;

namespace AugularJsFrameworkDemo.Areas.Students
{
    public class StudentsAreaBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string ngAppBasePath = "~/Areas/Students/Scripts/app";
            bundles.Add(new ScriptBundle("~/js/app-students").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/alertify/alertify.js",
                "~/Scripts/alertify/alertify.js",
                "~/Scripts/common/common.module.js",
                "~/Scripts/common/growl.service.js",
                "~/Scripts/common/util.service.js",

                // ** APP MODULE ** //

                ngAppBasePath + "/app.module.js",

                // ** COMMON ** //

                //ngAppBasePath + "/../common/common.module.js",
                //ngAppBasePath + "/../common/growl.service.js",

                // ** CORE MODULE ** //

                ngAppBasePath + "/core/core.module.js",
                 ngAppBasePath + "/core/studentResource.service.js",

                // ** STUDENT MODULE ** //

                ngAppBasePath + "/student/student.module.js",
                ngAppBasePath + "/student/student.list.controller.js",
                ngAppBasePath + "/student/student.add.controller.js",
                ngAppBasePath + "/student/student.view.controller.js"
                ));

            bundles.Add(new StyleBundle("~/style/app-students").Include(
                "~/Content/alertify/alertify.bootstrap.css",
                "~/Content/alertify/alertify.core.css",
                "~/Content/alertify/alertify.default.css"
                ));

         
        }
    }
}