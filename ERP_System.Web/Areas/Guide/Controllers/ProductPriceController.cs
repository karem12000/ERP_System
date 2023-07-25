using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class ProductPriceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProductBll _ProductBll;
        public ProductPriceController(ProductBll ProductBll, IHttpContextAccessor httpContextAccessor)
        {
            _ProductBll = ProductBll;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        
        public IActionResult Save(ProductPriceDTO mdl) => Ok(_ProductBll.SaveProductPrice(mdl));
		public IActionResult GetByProductBarCode(string text) => Ok(_ProductBll.GetProductPriceByBarCode(text));
		public IActionResult GetProductByName(string text) => Ok(_ProductBll.GetProductPriceByProductName(text));


	}
}
