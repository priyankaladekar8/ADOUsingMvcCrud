﻿using ADOCRUDMVCBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOCRUDMVCBook.Controllers
{
    public class BookController : Controller
    {
        BookDAL bookdal;
        private readonly IConfiguration configuration;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            bookdal = new BookDAL(this.configuration);
        }

        // GET: BookController
        public ActionResult Index()
        {
            var model = bookdal.GetBooks();
            return View(model);


        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {

            var model = bookdal.GetBookById(id);
            return View(model);
            
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bk)
        {
            try
            {
                int result = bookdal.AddBook(bk);
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


        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var bk = bookdal.GetBookById(id);
            return View(bk);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bk)
        {

            try
            {
                int result = bookdal.EditBook(bk);
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



        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var bk = bookdal.GetBookById(id);

            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = bookdal.DeleteBook(id);
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

