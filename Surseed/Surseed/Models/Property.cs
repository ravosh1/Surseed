using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Surseed.Models
{
    public class Property
    {
        private string con = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        public string Con
        {
            get
            {
                return con;
            }
        }
       
       

        
        public string donationid { get; set; }
        public string donorid { get; set; }
        public string organisationid { get; set; }
        public string EmailID { get; set; }
        public string UserID { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string ImgURL { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string id { get; set; }
        public string City { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string surseedno { get; set; }
        public string totaldeposit { get; set; }
        public string avgdeposit { get; set; }
        public string noofdeposit { get; set; }
        public string totalreimbursement { get; set; }
        public string UserName { get; set; }
        public string memberno { get; set; }
    }

    public class Adminchangepassword
    {
        [Display(Name = "New Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password length must be greater than 6 Characters!")]
        // [StringLength(50, maximumLength, ErrorMessage = "Password length must be greater than 6 Characters!")]
        //[DataType(DataType.Password)]
        [Required]
        public string newPass { get; set; }



        [Display(Name = "Password")]
        // [Display(Name = "New Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password length must be greater than 6 Characters!")]
        //[DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password length must be greater than 6 Characters!")]
        //[DataType(DataType.Password)]
        [Display(Name = "Confirm New password")]
        //[Compare("newPass", ErrorMessage = "Password do not match! Retype password !")]
        public string Confirm_Password { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

    }



}