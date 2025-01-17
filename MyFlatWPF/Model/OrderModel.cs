using System;

namespace MyFlatWPF.Model
{
    public class OrderModel : BaseModel
    {
        //[Required]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; } = DateTime.Now;

        //[Required(ErrorMessage = "Fill in the field \"Name\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Your Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Email\"")]
        //[EmailAddress(ErrorMessage = "Email Format Field name@site.com")]
        //[Display(Name = "Your Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Mobile\"")]
        //[Phone]
        //[MinLength(11, ErrorMessage = "Length of at least 11 characters.")]
        //[Display(Name = "Your Mobile")]
        public string Mobile { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Message\"")]
        //[MinLength(5, ErrorMessage = "Length of at least 5 characters.")]
        //[Display(Name = "Message")]
        public string Message { get; set; }

        //[Required(ErrorMessage = "Choose A Service")]
        //[Display(Name = "Choose A Service")]
        public string ServiceName { get; set; }

        //[Required]
        //[Display(Name = "StatusName")]
        public string StatusName { get; set; }
    }
}
