using Microsoft.AspNetCore.Mvc;
using multiple_choice.Data;
using multiple_choice.Models;
using multiple_choice.viewmodel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace multiple_choice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Multiple_choiceDbContext dbContext;
        public HomeController(ILogger<HomeController> logger, Multiple_choiceDbContext dbContext)
        {
            _logger = logger;
            dbContext = dbContext;
        }

        public IActionResult Index()
        {
            SurveyViewModel surveyViewModel = new SurveyViewModel();
            List<Question> questionModelList = dbContext.Questions.ToList();
            List<Feedback> answerModelList = dbContext.Feedback.ToList();

            List<QuestionsViewModel> questionsViewModelList = new List<QuestionsViewModel>();
            foreach (var quesion in questionModelList)
            {
                List<string> answers = new List<string>();
                QuestionsViewModel questionsViewModel = new QuestionsViewModel();
                questionsViewModel.QuestionsText = quesion.Question_Text;
                List<Feedback> feedbackList = answerModelList.Where(x => x.Question_Id == quesion.Question_Id).ToList();
                foreach (var answer in feedbackList)
                {
                    answers.Add(answer.Question_Id.Question_Text);
                }
                questionsViewModel.QuestionsAnswer = answers;
                questionsViewModelList.Add(questionsViewModel);
            }
            surveyViewModel.questionsViews = questionsViewModelList;
            return View(surveyViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}