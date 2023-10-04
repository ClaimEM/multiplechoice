using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiple_choice.Models
{

    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Feedback_Id { get; set; }

        public int? Survey_Id { get; set; }

        public int? Question_Id { get; set; }

        public int? Option_Id { get; set; }


    }

}