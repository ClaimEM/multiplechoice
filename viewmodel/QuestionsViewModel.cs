namespace multiple_choice.viewmodel
{
    public class QuestionsViewModel
    {
        public int questionId { get; set; }
        public string QuestionsText { get; set; }

        public int answerId { get; set; }
        public List<string> QuestionsAnswer { get; set; }
    }
}
