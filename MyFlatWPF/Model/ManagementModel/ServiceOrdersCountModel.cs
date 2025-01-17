
namespace MyFlatWPF.Model.ManagementModel
{
    public class ServiceOrdersCountModel : BaseModel
    {
        public string ServiceName { get; set; }

        public int OrdersByServiceCount { get; set; }
    }
}
