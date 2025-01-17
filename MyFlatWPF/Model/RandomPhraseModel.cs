using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlatWPF.Model
{
    public class RandomPhraseModel : BaseModel
    {
        public string Phrase { get; set; }

        [NotMapped]
        public string InputChangePhraseError { get; set; }
    }
}
