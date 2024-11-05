using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Model
{
    public class ServiceModel : BaseModel
    {
        //[Required(ErrorMessage = "Fill in the field \"Service Name\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Service Description\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Service Description")]
        public string ServiceDescription { get; set; }
    }
}
