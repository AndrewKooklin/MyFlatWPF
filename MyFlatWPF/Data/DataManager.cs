using MyFlatWPF.Data.Repositories.API;
using System;
using System.Collections.Generic;

namespace MyFlatWPF.Data
{
    public class DataManager
    {
        public static APIRenderingRepository Rendering { get; set; }

        public DataManager(APIRenderingRepository rendering)
        {
            Rendering = rendering;
        }
    }
}
