using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace IvySurvey.Models
{
    public class SurveyMapping
    {
        [Key]
        public int MappingId { get; set; }
        
        [ForeignKey("Id")] 
        public SurveyMaster SurveyMaster { get; set; }

        [Required]
        [Display(Name="SurveyId")]
        public int Id  { get; set; }

        [ForeignKey("DepartmentId")]  
        public Departments Departments { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}