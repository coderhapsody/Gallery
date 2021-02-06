﻿using System.Web.Mvc;

namespace Gallery.Web.Areas.External
{
    public class ExternalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "External";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "External_default",
                "External/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}