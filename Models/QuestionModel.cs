using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiple_choice.Models
{
    public partial class Question
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Question_Id { get; set; }

        [StringLength(255)]
        public string? Question_Type { get; set; }

        [StringLength(255)]
        public string? Question_Text { get; set; }

        public virtual ICollection<Option>? Options { get; set; }
        public ICollection<Feedback>? Feedback { get; internal set; }
    }
}
