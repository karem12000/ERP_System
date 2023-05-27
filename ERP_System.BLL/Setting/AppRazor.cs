﻿using System;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ERP_System.BLL
{
    /// <summary>
    /// This Is The Base View Of The Entire Application
    /// All Views Inside The Application Inherite From It in its "viewimports.cshtml" file
    /// It Contains The Logged in user and The Application Of Current User
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class AppRazor<TModel> : RazorPage<TModel>
    {

        public AppRazor()
        {
    
        }




        /// <summary>
        /// This Contains Form Name , Help , etc....
        /// </summary>
        public CurrentFormDTO CurrentForm => ViewContext.HttpContext.RequestServices.GetService<AppFormBll>().GetCurrentForm();
        public CurrentFormDTO CurrentFormByControllerName(string ControllerName) => ViewContext.HttpContext.RequestServices.GetService<AppFormBll>().GetCurrentForm(ControllerName);


    }
    public class CurrentFormDTO
    {
        public string Title { get; set; }
        public CurrentFormPermissionAction CurrentFormPermissionActions { get; set; }
    }
    public class CurrentFormPermissionAction
    {
        public bool AddHasPermission { get; set; } = false;
        public bool EditHasPermission { get; set; } = false;

        public bool DeleteHasPermission { get; set; } = false;
        public bool ShowHasPermission { get; set; } = false;
        public bool ChangeStatusHasPermission { get; set; } = false;

    }
}
