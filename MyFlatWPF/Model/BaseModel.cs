using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Model
{
    public class BaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
