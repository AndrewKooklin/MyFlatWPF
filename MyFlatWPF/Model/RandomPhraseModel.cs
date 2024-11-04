using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Model
{
    public class RandomPhraseModel : BaseModel
    {
        public string Phrase { get; set; }

        [NotMapped]
        public string InputChangePhraseError { get; set; }
    }
}
