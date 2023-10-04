using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiple_choice.Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string? Place { get; set; }

        [Required]
        [StringLength(255)]
        public string? LocationAcc { get; set; }

        [Required]
        [StringLength(255)]
        public string? OfficeImp { get; set; }

        [Required]
        [StringLength(255)]
        public string? TechAssess { get; set; }

        [Required]
        [StringLength(255)]
        public string? InterviewDesc { get; set; }

        public virtual ICollection<Feedback>? Feedback { get; set; }
    }
}
