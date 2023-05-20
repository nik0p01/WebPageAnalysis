using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPageAnalysis.DAL.Entities
{
    public class WordCount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(60)]
        [Required]
        public string Word { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
