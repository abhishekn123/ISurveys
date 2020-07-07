using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvySurvey.Models
{
    public class ResponseMaster
    {
        [ForeignKey("Id")]
        public QuestionMaster QuestionMastersurvey { get; set; }

        [Key]
        [Required]
        [Display(Name="SurveyId")]
        public int Id { get; set; }
   
        [ForeignKey("QuestionId ")]
        public QuestionMaster QuestionMaster { get; set; }

        [Required]
        public int QuestionId { get; set; }
      
        [ForeignKey("OptionId")]
        public OptionMaster optionMaster { get; set; }

        [Required]
        [Display(Name="optionId")]
        public int OptionId { get; set; }

        [Required]
        public string optionText { get; set; }
    }
}