using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IvySurvey.Models;

namespace IvySurvey.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Departments> Departments { get; set; }

        public DbSet<OptionMaster> optionMasters{get;set;}

        public DbSet<QuestionMaster> QuestionMasters{get;set;}

        public DbSet<SurveyMapping> SurveyMappings{get;set;}

        public DbSet<SurveyMaster> SurveyMasters{get;set;}

        public DbSet<ResponseMaster> ResponseMasters{get;set;}
        
    }
}
