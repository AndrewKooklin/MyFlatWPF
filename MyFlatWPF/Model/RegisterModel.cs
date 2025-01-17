using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace MyFlatWPF.Model
{
    public class RegisterModel : BaseModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}
