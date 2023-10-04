using Microsoft.EntityFrameworkCore;
using multiple_choice.Data;
using multiple_choice.Models;
using multiple_choice.viewmodel;
using System.Web.Mvc;

namespace multiple_choice.Controllers
{
    public Microsoft.AspNetCore.Mvc.JsonResult Add(SurveyViewModel surveyViewModel)
    {
        SurveyModel surveyModel = new SurveyModel();
        surveyModel.DateTimeColumn = DateTime.Now;

        SurveyModel retievedSurveyModel = DbContext.Survey.Where(x => x.DateTimeColumn == surveyModel.DateTimeColumn).FirstOrDefault();
        foreach (var answer in surveyViewModel.questionsViews)
        {
            Feedback feedback = new Feedback();
            feedback.Survey_Id = retievedSurveyModel.Survey_Id;
            feedback.Question_Id = answer.questionId;
            feedback.Option_Id = answer.answerId;
            DbContext.Feedback.Add(feedback);
        }
        return Json("sucess", JsonRequestBehavior.AllowGet);
    }
}
