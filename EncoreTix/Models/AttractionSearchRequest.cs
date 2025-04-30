using System.ComponentModel.DataAnnotations;

namespace EncoreTix.Models
{
    public class AttractionSearchRequest
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter a Keyword")]
        public string Keyword { get; set; }

        public int Size { get; set; } = 6;
    }
}
