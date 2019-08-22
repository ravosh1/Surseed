using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Surseed.Models
{
    public class OrganizationModel
    {
        public class Resistraion
        {
            public int OrganizationId { get; set; }
            public string OrganizationName { get; set; }
            public string OrgContactNumber { get; set; }
            public string Address { get; set; }

            public string City { get; set; }
            public string State { get; set; }

            public string Zip { get; set; }

            public string EIN { get; set; }

            public string TAXID { get; set; }

            public Boolean OrganizationActive { get; set; }

            public Int64 OrganizationUserId { get; set; }

            public string OrganizationUserTyepId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }


            public string Gender { get; set; }

            public string Age { get; set; }

            public string PhoneNo { get; set; }
            [Required]
            [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessage = "Please enter correct email address")]
            [Display(Name = "Email")]
            public string EmailId { get; set; }
            [Required]
            [Display(Name = "Password")]
            [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Please enter a password minimum 6 characters")]
            public string Password { get; set; }
            [Display(Name = "Confirm Passwrod")]
            [Compare("Password", ErrorMessage = "Password Do not Match")]
            public string ConfPassword { get; set; }
            public Boolean OrganizationUserActive { get; set; }
        }

        public class Login
        {
            public string EmailId { get; set; }
            public string Password { get; set; }
        }
    }
}