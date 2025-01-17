using System;

namespace MyFlatWPF.Model.ManagementModel
{
    public class PeriodModel
    {
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateFrom { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateTo { get; set; }
    }
}
