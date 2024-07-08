using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProjects.DAL;
using Myprojects.DTO;
namespace MyProjects.Controllers
{
    [sessionExpire]
    public class CustomerController : Controller
    {
        // GET: Customer
        MyprojectsDAL objconcustomer = new MyprojectsDAL();
        public ActionResult Index()
        {

            List<Products> prts = objconcustomer.Getproductslst();
            return View(prts);
        }
    }
}