using System.ComponentModel.DataAnnotations;

namespace MyFlatWPF.Model
{
    public class BaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
