using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace MyFlatWPF.Model.AccountModel
{
    public class UserWithRolesModel
    {
        public IdentityUser User { get; set; }

        public List<string> Roles { get; set; }

        //[Display(Name = "Role")]
        public string Role { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        public string Add { get; set; }

        public string Delete { get; set; }
    }
}
