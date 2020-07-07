using System;
using System.ComponentModel.DataAnnotations;
namespace IvySurvey.Models
{
    public class SurveyMaster
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string SurveyName { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

         [Required]
         public DateTime ToDate { get; set; }
    }
}