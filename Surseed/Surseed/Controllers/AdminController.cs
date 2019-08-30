using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Surseed.Models;

namespace Surseed.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Portal/
        Datalayer dl = new Datalayer();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Property p)
        {
            

            DataSet ds = dl.AdmingetLogin(p);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Status"].ToString() == "ACTIVE")
                {
                    HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];
                    loginCookie_SurSeed_Admin = new HttpCookie("loginCookie_SurSeed_Admin");
                   // loginCookie_SurSeed_Admin["Id"] = ds.Tables[0].Rows[0]["Id"].ToString();
                    loginCookie_SurSeed_Admin["userid"] = ds.Tables[0].Rows[0]["userid"].ToString();
                    loginCookie_SurSeed_Admin["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                    //loginCookie_SurSeed_Admin["Username"] = ds.Tables[0].Rows[0]["Username"].ToString();
                    loginCookie_SurSeed_Admin["Email"] = ds.Tables[0].Rows[0]["Emailid"].ToString();

                    loginCookie_SurSeed_Admin.Expires = System.DateTime.Now.AddHours(24);
                    Response.Cookies.Add(loginCookie_SurSeed_Admin);
                    TempData["successs"] = "Welcome To SurSeed Admin Panel!!";
                    return RedirectToAction("Dashboard", "Admin");
                }

            }
            else
            {
                ViewBag.Msg = "Invalid Username or Password";
            }

            return View();
        }

        public ActionResult Dashboard()
        {
            Property model = new Property();
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];
            if (loginCookie_SurSeed_Admin == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                if (loginCookie_SurSeed_Admin != null)
                {
                    model.EmailID = loginCookie_SurSeed_Admin["email"].ToString();
                    model.UserID = loginCookie_SurSeed_Admin["UserId"].ToString();
                    model.UserType = loginCookie_SurSeed_Admin["UserType"].ToString();
                }
                Datalayer dll = new Datalayer();


                //string qry = @"select * from  [dbo].[tbl_login] where [Id]='" + loginCookie_StuTutor_Admin["UserId"].ToString() + @"'";
                DataSet dsfetch = dl.Inline_Process("select * from[dbo].[AdminLogin_tbl] where emailid = '" + loginCookie_SurSeed_Admin["email"].ToString() + "'");
                ViewBag.userdtl = dsfetch;
                TempData["success"] = "Welcome To SurSeed Organization!!";
                // DataSet ds = dl.MyDs_Process("select Page_Content from CMS_tbl where Page_Name='Dashboard Top'");
                // ViewBag.Page_Content = ds.Tables[0].Rows[0][0].ToString();

                //  ds = dl.MyDs_Process("select Page_Content from CMS_tbl where Page_Name='Dashboard Bottom'");
                //  ViewBag.Page_Content1 = ds.Tables[0].Rows[0][0].ToString();


                //ds = dll.MemberDownlineLevelMembersCount("U000000");

                //ViewBag.DownlineMemberCount = ds;


                // ds = dll.FetchMemberJoinCount();
                //ViewBag.SponsorCount = ds;

                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];
            {
                loginCookie_SurSeed_Admin.Expires = System.DateTime.Now.AddHours(-1);
                Response.Cookies.Add(loginCookie_SurSeed_Admin);
            }
            return RedirectToAction("Index", "Admin");
        }





        public ActionResult EditProfile(string id)
        {
            Property model = new Property();
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];
            if (loginCookie_SurSeed_Admin == null)
            {
                return RedirectToAction("Index", "Portal");
            }
            else
            {
                if (loginCookie_SurSeed_Admin != null)
                {
                    model.id = loginCookie_SurSeed_Admin["email"].ToString();
                    model.UserID = loginCookie_SurSeed_Admin["UserId"].ToString();
                    model.UserType = loginCookie_SurSeed_Admin["UserType"].ToString();
                }
                DataSet ds = dl.Inline_Process("select * from dbo.adminlogin_tbl where userId='" + id + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.UserID = ds.Tables[0].Rows[0]["UserId"].ToString();
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                    model.EmailID = ds.Tables[0].Rows[0]["Emailid"].ToString();
                    model.Contact = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    model.ImgURL = ds.Tables[0].Rows[0]["Photo"].ToString();
                    model.FirstName = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    if (model.ImgURL != "")
                    {
                        ViewBag.photo = "~/DataImages/Admin/" + model.ImgURL;
                    }
                    else
                    {
                        ViewBag.photo = "~/Content/AdminTheme/themes/supr/img/-text.png";
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProfile(string id, Property model, HttpPostedFileBase ImageData)
        {
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];
            if (loginCookie_SurSeed_Admin != null)
            {
                // model.id = loginCookie_StuTutor_Admin["Id"].ToString();
                model.UserID = loginCookie_SurSeed_Admin["UserId"].ToString();
                model.UserType = loginCookie_SurSeed_Admin["UserType"].ToString();

                //if (ModelState.IsValid)
                //{
                model.ImgURL = dl.NewSaveSingleImages("~/DataImages/Admin/", ImageData, model.ImgURL);
                int i = dl.AdminEditProfile(model);
                if (i > 0)
                {
                    TempData["success"] = "Admin is successfully Updated!";
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ViewBag.error = "Oops! Something is going wrong.";
                }
                //}
                //else
                //{
                //    ViewBag.error = "Oops! Something is going wrong.";
                //}
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            return EditProfile(id);
        }


        public ActionResult ChangePassword()
        {
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];

            if (loginCookie_SurSeed_Admin == null)
            {

                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(Adminchangepassword model)
        {

            string status = "";
            HttpCookie loginCookie_SurSeed_Admin = Request.Cookies["loginCookie_SurSeed_Admin"];

            if (loginCookie_SurSeed_Admin != null)
            {
                model.userId = loginCookie_SurSeed_Admin["UserId"].ToString();
            }
            try
            {
                if (ModelState.IsValid)
                {

                    if (model.newPass.Length > 6)
                    {
                        DataSet ds = dl.changePassword_Admin(model);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //int i = dl.InlineNonproc("update tbl_login set password='"+model.Confirm_Password+"' where userid='"+model.userId+"'");
                            //ViewBag.message = ds.Tables[0].Rows[0][0].ToString();
                            //ViewBag.message = "Password Changed successfully ";
                            status = ds.Tables[0].Rows[0][1].ToString();
                            if (status == "FAILED")
                            {
                                ViewBag.error = "Incorrect Old Password";
                            }
                            else
                            {
                                ViewBag.success = "Password  successfully changed";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.message = "Password length must be greater than 5 digits";
                    }

                    return View();
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
