using MyFlatWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Data.Repositories.Abstract
{
    public interface IRenderingRepository
    {
        List<TopMenuLinkNameModel> GetTopMenuLinkNames();
    }
}
