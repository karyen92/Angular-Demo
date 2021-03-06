﻿using System.Web.Mvc;

namespace AugularJsFrameworkDemo.Areas.Form
{
    public class FormAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Form";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Form_default",
                "Form/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}