using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 
namespace IvySurvey.Models
{
    public class QuestionMaster
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string QuestionName {get;set;}

        [Required]
        public string OptionType { get; set; }

        [ForeignKey("Id")]  
        public SurveyMaster SurveyMaster { get; set; }

        [Required]
        [Display(Name = "SurveyMasterId")]  
        public int Id { get; set; }

    }
}