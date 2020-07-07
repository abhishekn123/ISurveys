using System.ComponentModel.DataAnnotations;
namespace IvySurvey.Models
{
    public class Departments
    {
        [Key]
        public int DepartMentId { get; set; }
        
        [Required]
        public string DepartmentName {get;set;}
    }
}