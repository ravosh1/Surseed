﻿using Surseed.Models;
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
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Logout()
        {
            HttpCookie loginCookie_Surseed_Organization = Request.Cookies["loginCookie_Surseed_Organization"];
            if (loginCookie_Surseed_Organization != null)
            {
                loginCookie_Surseed_Organization.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(loginCookie_Surseed_Organization);
            }
            return RedirectToAction("SignIn", "Organisation");
        }


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

        public ActionResult SignIn()
        {

            return View();
        }


      

        [HttpPost]
        public ActionResult SignIn(OrganizationModel.Login model)
        {
            DataSet ds = new DataSet();
            //DataTable dt = ds.Tables[0];
            ds = dl.usp_UserLogin(model);//Inline_Process("select * from [Registration_Tbl] where Emailid='" + model.EmailId + "' and Password='" + model.Password + "'").Tables[0];
            if (ds.Tables[0].Rows[0]["LoginStatus"].ToString() == "True")
            {
                //if (ds.Tables[1].Rows[0]["EmailId"].ToString() == model.EmailId)
                //{
                HttpCookie loginCookie_Surseed_Organization = Request.Cookies["loginCookie_Surseed_Organization"];
                loginCookie_Surseed_Organization = new HttpCookie("loginCookie_Surseed_USER");
                loginCookie_Surseed_Organization["OrganizationId"] = ds.Tables[1].Rows[0]["Organizationid"].ToString();
                loginCookie_Surseed_Organization["Name"] = ds.Tables[1].Rows[0]["OrganizationName"].ToString();
                // loginCookie_Costoracle_USER["UserType"] = ds.Tables[1].Rows[0]["UserType"].ToString();
                //  loginCookie_Costoracle_USER.Values[];
                loginCookie_Surseed_Organization.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(loginCookie_Surseed_Organization);
                TempData["msg"] = ds.Tables[0].Rows[0]["message"].ToString();
                return Redirect(Url.Action("Home","Organisation"));
            }
            else
            {
                TempData["msg"] = ds.Tables[0].Rows[0]["message"].ToString();
            }
          
            return View();
        }


        public ActionResult SignUp()
        {
            fill_OrganizationUserTypeList();
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(OrganizationModel.Resistraion model)
        {
            if(ModelState.IsValid)
            {
                int i = dl.usp_setOrganization(model);

                if (i > 0)
                {
                    TempData["msg"] = "You have Sucessfuly registered ..Proceed with logIn";
                    return RedirectToAction("SignIn");
                }
                else
                {
                    TempData["SignUpERROR"] = "Oops!! Something Went Wrong.....";
                }
            }
            else
            {
                TempData["SignUpERROR"] = "Failed! Please fill all the required field.";
                fill_OrganizationUserTypeList();
            }
          
            return View();
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