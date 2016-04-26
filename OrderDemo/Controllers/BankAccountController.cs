using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderDemo.Controllers
{
    public class BankAccountController : Controller
    {
        // GET: BankAccount
        public ActionResult Index()
        {
            return View();
        }
    }
}