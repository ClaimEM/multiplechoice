using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiple_choice.Models
{
    public partial class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OptionId { get; set; }

        [StringLength(255)]
        public string? OptionText { get; set; }

        public int? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question? Question { get; set; }

        public virtual ICollection<Feedback>? Feedback { get; set; }
    }
}
