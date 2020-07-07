using System;
using System.Data.Common;
using IvySurvey.Data;
using IvySurvey.Models;

namespace IvySurvey.DAL
{
    public class SurveyCreator
    {
        public  ApplicationDbContext _context;
       
        public SurveyCreator(ApplicationDbContext context)
        {
           this._context=context;
        }

        public int  CreateSurvey(SurveyMaster Master)
        {
           using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                 _context.SurveyMasters.Add(Master);
                 _context.SaveChanges();
                  SurveyMapping survey= new SurveyMapping()
                  {
                    DepartmentId=1,
                    Id=Master.Id
                  };
                 _context.SurveyMappings.Add(survey);
                  _context.SaveChanges();
                  transaction.Commit();
                    return Master.Id;
                }
                catch (DbException Dbe)
                {
                   transaction.Rollback();
                    return 0;
                }
                catch (Exception e)
                {
                    _context.Database.RollbackTransaction();
                    return 0;
                }
            }
            

        }
    }
}