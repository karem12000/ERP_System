using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class UnitController : Controller
    {
        private readonly UnitBll _UnitBll;
        public UnitController(UnitBll UnitBll)
        {
            _UnitBll = UnitBll;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Save(UnitDTO mdl) => Ok(_UnitBll.Save(mdl));
        public IActionResult GetAll() => Ok(_UnitBll.GetAll());
        public IActionResult GetById(Guid id) => Ok(_UnitBll.GetById(id));
        public IActionResult GetByUnitName(string text) => Ok(_UnitBll.GetByUnitName(text));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_UnitBll.Delete(id));

        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_UnitBll.LoadData(mdl));

        #endregion

    }
}
