using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Utils;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index(string search = "", string id = "")
        {

            if (search != "")
            {
                return View(AccountsUtils.GetAccounts().Where(a => a.Name == search));
            }
            
            return View(AccountsUtils.GetAccounts());
        }

        public ActionResult Add(Account acc)
        {

            if (acc.Name != null)
            {
                AccountsUtils.Save(acc);
                return RedirectToAction("Index");                
            }
            return View();
        }
       
        public ActionResult Edit(Account acc)
        {
            return View(AccountsUtils.GetAccounts(acc.Id).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            AccountsUtils.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Search(string search)
        {
            return RedirectToAction("Index", "Home", new { search, id = search });
        }

        public ActionResult Login(string username, string password)
        {


          if (AccountsUtils.ValidUserNamePassword(username,password))
          {
              return RedirectToAction("Index", "Home");
          }
          if (password != null && username != null)
          {
              ViewBag.Error = "Error message";
              return RedirectToAction("Logout");

          }

           return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            return View("Login");
        }
        
    }
}
