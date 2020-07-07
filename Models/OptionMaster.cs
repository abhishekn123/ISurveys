using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace IvySurvey.Models
{
    public class OptionMaster
    {
        [Key]
        public int OptionId { get; set; }

        [ForeignKey("QuestionId")]  
        public QuestionMaster QuestionMaster { get; set; }

        [Required]
        [Display(Name = "QuestionId")]  
        public int QuestionId {get;set;}
    }
}