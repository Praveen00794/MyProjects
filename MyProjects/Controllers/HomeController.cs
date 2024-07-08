using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myprojects;
using Myprojects.DTO;
namespace MyProjects.Controllers
{
    public class HomeController : Controller
    {
        DAL.MyprojectsDAL _objMasterDatas = new DAL.MyprojectsDAL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginInfo objuserlogchk)
        {
            try
            {
                DataTable DtLoginchks = _objMasterDatas.SMSLogin(objuserlogchk);
                if (DtLoginchks.Rows.Count > 0)
                {
                    Session["UserName"] = DtLoginchks.Rows[0]["Username"].ToString().Trim();
                    Session["Email"] = DtLoginchks.Rows[0]["Email"].ToString();
                    if (Convert.ToInt32(DtLoginchks.Rows[0]["RoleID"]) == 1)
                    {
                        Session["RoleID"] = "Admin";
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        // Handle other roles if needed
                        Session["RoleID"] = "Customer"; // Example for a general user role
                        return RedirectToAction("Index", "Customer"); // Redirect to home or any other action
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Please Check User Name and Password";
                    return View();
                }
            }
            catch (Exception err)
            {
                ViewBag.ErrorMsg = "Please Check User Name and Password";
                return View();
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
