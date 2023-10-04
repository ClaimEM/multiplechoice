using multiple_choice.viewmodel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiple_choice.Models
{
    public class SurveyModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Survey_Id { get; set; }

        public DateTime DateTimeColumn { get; set; } = DateTime.Now;


    }
}
