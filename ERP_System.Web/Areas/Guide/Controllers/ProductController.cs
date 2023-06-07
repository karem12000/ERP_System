using ERP_System.BLL.Guide;
using ERP_System.DTO.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ERP_System.Web.Areas.Guide.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ProductBll _ProductBll;
        private readonly StockBll _stockBll;
        private readonly UnitBll _unitBll;
        private readonly ItemGrpoupBll _itemGroupBll;
        public ProductController(ProductBll ProductBll, ItemGrpoupBll itemGroupBll, UnitBll unitBll, StockBll stockBll, IHttpContextAccessor httpContextAccessor)
        {
            _ProductBll = ProductBll;
            _itemGroupBll = itemGroupBll;
            _unitBll = unitBll;
            _stockBll = stockBll;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            ViewData["Groups"] = _itemGroupBll.GetSelect();
            ViewData["Units"] = _unitBll.GetSelect();

            return View();
        }
        public IActionResult Edit(Guid id)
        {
            var userId = _httpContextAccessor.UserId();
            ViewData["Stocks"] = _stockBll.GetStocksSelectByUserId(userId);
            ViewData["Groups"] = _itemGroupBll.GetSelect();
            ViewData["Units"] = _unitBll.GetSelect();
            var item = _ProductBll.GetById(id);
            if (item != null)
            {

                return View(item);
            }
            else
                return Redirect("/Guide/Product/Index");
        }
        public IActionResult Save(ProductDTO mdl) => Ok(_ProductBll.Save(mdl));
        public IActionResult GetProductsByGroupId(Guid id) => Ok(_ProductBll.GetAllByGroupId(id));
        public IActionResult GetAllUnits() => Ok(_unitBll.GetSelect());
        public IActionResult GetUserStocks() => Ok(_stockBll.GetStocksSelectByUserId(_httpContextAccessor.UserId()));
        public IActionResult GetItemGroups() => Ok(_itemGroupBll.GetSelect());
        public IActionResult GetProductById(Guid id) => Ok(_ProductBll.GetById(id));
        public IActionResult GetByProductBarCode(string text) => Ok(_ProductBll.GetByProductBarCode(text));

        [HttpPost]
        public IActionResult Delete(Guid id) => Ok(_ProductBll.Delete(id));


        #region LoadData
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_ProductBll.LoadData(mdl));
        #endregion
    }
}
