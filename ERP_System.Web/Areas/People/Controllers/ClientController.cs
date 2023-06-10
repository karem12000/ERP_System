using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_System.BLL;
using ERP_System.BLL.Guide;
using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_System.Web.Areas.People.Controllers
{
    public class ClientController : Controller
    {
        #region Fields

        private readonly ClientBll _ClientBll;


        public ClientController(ClientBll ClientBll)
        {
            _ClientBll = ClientBll;
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var item = _ClientBll.GetById(id);
            if (item != null)
            {

                return View(item);
            }
            else
                return Redirect("/People/Client/Index");
        }

        public IActionResult Save(ClientDTO mdl)
        {
            return Ok(_ClientBll.Save(mdl));
        }

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_ClientBll.Delete(id));



        #endregion
        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_ClientBll.LoadData(mdl));

        #endregion
    }
}
