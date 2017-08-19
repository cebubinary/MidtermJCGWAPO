using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index(string search = "", string id = "")
        {

            if (search != "")
            {
                return View(Information.Context.Accounts.Where(a => a.Name == search));
            }
            
            return View(Information.Context.Accounts);
        }

        public ActionResult Add(Account acc)
        {
            Save(acc);
            if (acc.Name != null)
            {
                return RedirectToAction("Index");
                
            }
            return View();
        }
        public ActionResult Save(Account acc)
        {
            var selected = Information.Context.Accounts.FirstOrDefault(x => x.Id == acc.Id);
            if (selected != null)
            {
                selected.Name = acc.Name;
                selected.Age = acc.Age;
                selected.Username = acc.Username;
                selected.Password = acc.Password;
                selected.Address = acc.Address;
              
            }
            else
            {
                
                acc.Id = Information.Context.NextId();
                Information.Context.Accounts.Add(acc);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Account acc)
        {
            
         

            return View(Information.Context.Accounts.FirstOrDefault(x => x.Id == acc.Id));
        }
        public ActionResult Delete(int id)
        {
            var selected = Information.Context.Accounts.FirstOrDefault(x => x.Id == id);
            if (selected != null)
            {
                
                Information.Context.Accounts.Remove(selected);

            }
            return RedirectToAction("Index");
        }
        public ActionResult Search(string search)
        {
            return RedirectToAction("Index", "Home", new { search, id = search });
        }

        public ActionResult Login(string username, string password)
        {
            
          var selectedUser = Information.Context.Accounts.FirstOrDefault(x => x.Username == username && x.Password==password);
          
         
          if (selectedUser!=null)
          {
              return RedirectToAction("Index");
          }
          if (password != null && username != null)
          {
              ViewBag.Error = "Error message";
          }

          return View();
        }
        public ActionResult Logout()
        {
            return View("Login");
        }
        
    }
}
