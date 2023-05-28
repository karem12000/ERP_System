using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductBll _ProductBll;
        public ProductController(ProductBll ProductBll)
        {
            _ProductBll = ProductBll;
        }
        public IActionResult Index()
        {
            ViewData["Products"] = _ProductBll.GetSelect();
            return View();
        }

        public IActionResult Save(ProductDTO mdl) => Ok(_ProductBll.Save(mdl));
        public IActionResult GetProductsByGroupId(Guid id) => Ok(_ProductBll.GetAllByGroupId(id));
        public IActionResult GetProductById(Guid id) => Ok(_ProductBll.GetById(id));
        public IActionResult GetByProductBarCode(string text) => Ok(_ProductBll.GetByProductBarCode(text));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_ProductBll.Delete(id));

    }
}
