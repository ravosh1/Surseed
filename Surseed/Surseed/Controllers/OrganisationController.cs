using Surseed.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surseed.Controllers
{
    public class OrganisationController : Controller
    {

        Datalayer dl = new Datalayer();
        // GET: Organisation

        void fill_OrganizationUserTypeList()
        {
            List<SelectListItem> OrgUsrTypeList = new List<SelectListItem>();
            DataSet ds = dl.Inline_Process("Select * from [USR].[U14_OrganizationUserType]");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                SelectListItem item = new SelectListItem();
                item.Text = ds.Tables[0].Rows[i]["OrganizationUserType"].ToString();
                item.Value = ds.Tables[0].Rows[i]["OrganizationUserTypeId"].ToString();
                OrgUsrTypeList.Add(item);
            }
            ViewBag.OrgUsrTypeList = OrgUsrTypeList;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {

            return View();
        }


        public ActionResult SignUp()
        {
            fill_OrganizationUserTypeList();
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(OrganisitaionModel.Resistraion model)
        {
          int i= dl.usp_setOrganization(model);
            if(i>0)
            {
                TempData["msg"] = "You Have Sucessefully Registered Please Proceed with Log in.....";
            }
            else
            {
                TempData["SignUpERROR"] = "Oops!! Something went wrong....";
                return View();
            }
            return RedirectToAction("SignIn", "Organisation");
        }

        public ActionResult Forgotpassword()
        {
            return View();
        }


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Collection()
        {
            return View();
        }


        public ActionResult  AccountStatus()
        {
            return View();
        }

        public ActionResult Deposits()
        {
            return View();
        }

        public ActionResult Reimbursements()
        {
            return View();
        }


        public ActionResult Donors()
        {
            return View();
        }


        public ActionResult MessageBoard()
        {
            return View();
        }


        public ActionResult Reports()
        {
            return View();
        }
    }
}