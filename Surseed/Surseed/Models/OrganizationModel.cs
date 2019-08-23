﻿using System;
using System.Collections.Generic;
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

            public string OrganizationUserId { get; set; }

            public string OrganizationUserTyepId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }


            public string Gender { get; set; }

            public string Age { get; set; }

            public string Phone { get; set; }

            public string EmailId { get; set; }

            public string Password { get; set; }

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