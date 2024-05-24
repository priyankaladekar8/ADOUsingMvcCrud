using ADOCrudMVCProduct.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOUsingMvcCrud.Controllers
{
    public class ProductController : Controller
    {

        ProductDAL productdal;
        private readonly IConfiguration configuration;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            productdal = new ProductDAL(this.configuration);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = productdal.GetProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {


            var model = productdal.GetProductById(id);
            return View(model);
            
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            try
            {
                int result = productdal.AddProduct(pro);
                if (result >= 1)

                {
                    return RedirectToAction(nameof(Index));
                }
                else {
                       ViewBag.ErrorMsg = "Something went wrong";
                        return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var pro = productdal.GetProductById(id);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product pro)
        {
            try
            {
                int result = productdal.EditProduct(pro);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();

                }
            }
            catch (Exception ex)

            {
                ViewBag.ErrorMsg = ex.Message;

                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = productdal.GetProductById(id);
            return View(pro);

        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = productdal.DeleteProduct(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
