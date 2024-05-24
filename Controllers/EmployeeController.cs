using ADOUsingMvcCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsingCrudAdo.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeedal;
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeedal = new EmployeeDAL(this.configuration);
        }
        // GET: EmployeeController
        public ActionResult Index()  //emplyee list
        {
            var model = employeedal.GetEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id) //single emp
        {
            var model = employeedal.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = employeedal.AddEmployee(emp);
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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id) //edit page
        {
            var emp = employeedal.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeedal.EditEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.ErrorMsg = "Something went Wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorBag = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = employeedal.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")] //if httpget method and httppost method has diff action name
        //to identify method for post req we will apply[ActionName]
        public ActionResult DeleteConfirm(int id) //post confirmation to del emp
        {
            try
            {

                int result = employeedal.DeleteEmployee(id);
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
                ViewBag.ErrorBag = ex.Message;
                return View();
            }
        }
    }
}