using IvySurvey.Models;
using System;
using IvySurvey.DAL;
using IvySurvey.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Data.Common;

namespace IvySurvey.Controllers
{
    public class SurveyController : Controller
    {
        public ApplicationDbContext _context;
         SurveyCreator surveyCreator;
        public SurveyController(ApplicationDbContext context)
        {
            this._context = context;
            this.surveyCreator=new SurveyCreator(context);
        }
        [HttpPost]
        [Authorize(Roles="Admin")]
        public ActionResult CreateSurvey([FromBody] SurveyMaster Master)
        {
            var SurveyId=0;
            try{
                SurveyId=surveyCreator.CreateSurvey(Master);
               if(SurveyId>0)
               {
                   return Ok(SurveyId);
               }
               else{
                   return BadRequest();
               }
            }
            catch(DbException dbe)
            {
               return BadRequest(dbe.Message);
            }
            catch(Exception e)
            {
               return BadRequest(e.Message);
            }
           
        }
    }
}