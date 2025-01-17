
namespace MyFlatWPF.Model
{
    public class ContactModel : BaseModel
    {
        //[Required(ErrorMessage = "Fill in the field \"Address\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Phone\"")]
        //[Phone]
        //[MinLength(11, ErrorMessage = "Length of at least 11 characters.")]
        //[Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Email\"")]
        //[EmailAddress(ErrorMessage = "View field \"name@example.com\"")]
        //[Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
    }
}
