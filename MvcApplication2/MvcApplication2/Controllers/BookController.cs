using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Utils;

namespace MvcApplication2.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index(string search = "")
        {
            if (search != "")
            {
                return View(BooksUtils.GetBooks().Where(x=>x.BookTitle == search || x.Author == search));
            }
            return View(BooksUtils.GetBooks());
        }
        public ActionResult Edit(Book acc)
        {
            return View(BooksUtils.GetBooks(acc.ID).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            BooksUtils.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Add(Book acc)
        {
            if (acc.BookTitle != null)
            {
                BooksUtils.Save(acc);
                return RedirectToAction("Index");
            }           
            return View();
        }
       
    }
}
