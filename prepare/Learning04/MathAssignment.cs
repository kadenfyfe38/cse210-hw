class MathAssignment : Assignment
{
   //attributes
   private string _textbookSection;
   private string _problems;
   //constructor
   public MathAssignment(string studentName, string topic, string textbookSection, string problems) //must call it here then specify base after :
       : base(studentName, topic)
   {
       _textbookSection = textbookSection;
       _problems = problems;
   }
   //behavoiours
   public string GetHomeworkList()
   {
       string HomeworkList = $"{_textbookSection}, Problems:{_problems}";
       return HomeworkList;
   }
}
