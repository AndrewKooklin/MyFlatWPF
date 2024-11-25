using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Model.ManagementModel
{
    public class ServiceOrdersCountModel : BaseModel
    {
        public string ServiceName { get; set; }

        public int OrdersByServiceCount { get; set; }
    }
}
