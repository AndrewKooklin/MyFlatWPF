using System;

namespace MyFlatWPF.Model
{
    public class PostModel : BaseModel
    {
        //[Required(ErrorMessage = "Select a picture")]
        //[Display(Name = "Post Image")]
        public byte[] PostImage { get; set; }

        //[Display(Name = "Posting Date")]
        public DateTime PostingDate { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Post Header\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Post Header")]
        public string PostHeader { get; set; }

        //[Required(ErrorMessage = "Fill in the field \"Post Description\"")]
        //[MinLength(3, ErrorMessage = "Length of at least 3 characters.")]
        //[Display(Name = "Post Description")]
        public string PostDescription { get; set; }
    }
}
