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
       
       

        public string id { get; set; }
        public string UserID { get; set; }
        public string mailValue { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string CnfPassword { get; set; }
               
        public string Category { get; set; }
        
        public string Status { get; set; }
       
        public string Size { get; set; }

        public string Address { get; set; }
        public string FullName { get; set; }
        public string SiteURL { get; set; }
        public string FbURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        
        public string Price { get; set; }

        public string Description { get; set; }
       
        public string ImgURL { get; set; }
        public string ThumbImgURL { get; set; }

        public string Condition1 { get; set; }
        public string Condition2 { get; set; }
        public string Condition3 { get; set; }
        public string Condition4 { get; set; }
        public string onTable { get; set; }
       
        public string SmallDescription { get; set; }
      
        public string Page { get; set; }
        public string Date { get; set; }
     
        public string onDate { get; set; }

        public string Colour { get; set; }

        public string ProductName { get; set; }

        public string Country { get; set; }

        public string Brand { get; set; }
        public string CID { get; set; }
        public string SID { get; set; }
        public string SubCategory { get; set; }
        public string Others { get; set; }
        public string FrontDisplay { get; set; }
        public string Position { get; set; }

        public string LightType { get; set; }
        public string Range { get; set; }
        public string Power { get; set; }
        public string LightColor { get; set; }
        public string Lumen { get; set; }
        public string Subject { get; set; }


        //////////cart intigration//////////


        public string CartID { get; set; }
        public string ProId { get; set; }
        public string Qty { get; set; }
        public string Amount { get; set; }
        public string TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        //public string EmailID { get; set; }
        public string Postalcode { get; set; }
        public string Contact { get; set; }
        public string Charges { get; set; }
        public string TotDiscount { get; set; }
        public string Company { get; set; }
        public string pid { get; set; }

        public string UserType { get; set; }
        //public string userid { get; set; }
        //public string extraitem { get; set; }
        public string NetAmount { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string S_FirstName { get; set; }
        public string fromdate { get; set; }

        public string todate { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string paypalacct { get; set; }
        public string TypeName { get; set; }
        public string Message { get; set; }
        public string shopname { get; set; }
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