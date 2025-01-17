
namespace MyFlatWPF.Model
{
    public class LoginModel : BaseModel
    {
        //[Required(ErrorMessage = "Fill field \"Email\"")]
        //[EmailAddress(ErrorMessage = "Email field format name@site.com")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Fill field \"Password\"")]
        //[MinLength(6, ErrorMessage = "At least 6 characters.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }

        //[Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
