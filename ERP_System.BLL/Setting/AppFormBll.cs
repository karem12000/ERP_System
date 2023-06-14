
using ERP_System.BLL;
using ERP_System.Common.General;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP_System.BLL
{
    public class AppFormBll
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContext;
        private readonly PageBll _pageBll;



        public AppFormBll( IHttpContextAccessor httpContext, PageBll pageBll)
        {
          
            _httpContext = httpContext;
            _pageBll = pageBll;


        }
        public CurrentFormDTO GetCurrentForm()
        {
            CurrentFormDTO currentFormDTO = new CurrentFormDTO();
            string ControllerName = _httpContext.HttpContext.Request.Path.Value.Split('/')[2];

            currentFormDTO.Title = _pageBll.GetPageName(ControllerName);
            var PagePermissions = _pageBll.GetPagePermission(ControllerName);
            currentFormDTO.CurrentFormPermissionActions = new CurrentFormPermissionAction()
            {
                AddHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Add).FirstOrDefault() != null ? true : false,
                DeleteHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Delete).FirstOrDefault() != null ? true : false,
                EditHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Edit).FirstOrDefault() != null ? true : false,
                ShowHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Show).FirstOrDefault() != null ? true : false,
               //PurchaseThrowbackHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.PurchaseThrowback).FirstOrDefault() != null ? true : false,
               //SaleThrowbackHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.SaleThrowback).FirstOrDefault() != null ? true : false,
            };
            return currentFormDTO;
        }

        public CurrentFormDTO GetCurrentForm(string ControllerName)
        {
            CurrentFormDTO currentFormDTO = new CurrentFormDTO();
            currentFormDTO.Title = _pageBll.GetPageName(ControllerName);
            var PagePermissions = _pageBll.GetPagePermission(ControllerName);
            currentFormDTO.CurrentFormPermissionActions = new CurrentFormPermissionAction()
            {
                AddHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Add).FirstOrDefault() != null ? true : false,
                DeleteHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Delete).FirstOrDefault() != null ? true : false,
                EditHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Edit).FirstOrDefault() != null ? true : false,

                ShowHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.Show).FirstOrDefault() != null ? true : false,
                //PurchaseThrowbackHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.PurchaseThrowback).FirstOrDefault() != null ? true : false,
                //SaleThrowbackHasPermission = PagePermissions.Where(p => p.ActionsPage.ActionName == ActionEnum.SaleThrowback).FirstOrDefault() != null ? true : false,
            };

           
            return currentFormDTO;
        }


        #endregion


    }
}
