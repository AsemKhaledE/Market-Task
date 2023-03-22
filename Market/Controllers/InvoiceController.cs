using Market.Models;
using Market.Models.Repositories;
using Market.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoceRepository)
        {
            _invoiceRepository = invoceRepository;
        }
        public IActionResult Index()
        {
            var products = _invoiceRepository.List();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create(int invoiceId)
        {
            var model = new ProductViewModel();
            model.InvoiceId = invoiceId;
            if (invoiceId > 0)
            {
                model.ProductList = _invoiceRepository.GetProductListByInvoiceId(invoiceId);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            var invoiceId = _invoiceRepository.Add(product);
            return RedirectToAction(nameof(Create), new { InvoiceId = invoiceId });
        }
    }
}
