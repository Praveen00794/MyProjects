using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Myprojects;
using Myprojects.DTO;
namespace MyProjects.Controllers
{
    [sessionExpire]
    public class AdminController : Controller
    {
        // GET: Admin
        DAL.MyprojectsDAL objadminCon = new DAL.MyprojectsDAL();
        public ActionResult Index()
        {
            Admindashboard objpreloadData = objadminCon.Getadmindata();

            return View(objpreloadData);
        }
    }
}