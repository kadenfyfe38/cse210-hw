class Assignment
{
   //Attributes
   private string _studentName;
   private string _topic;


   //Constructors
   public Assignment(string studentName, string topic)
   {
       //sets the private vars to input to the Assignment Constructor
       _studentName = studentName;
       _topic = topic;
   }
   //Behaviours


   public string GetSummary()
   {
       string _summary = $"{_studentName} - {_topic}";
       return _summary;
   }
  
   public string GetStudentName() //public method to allow sub-classes to get a value for private variables in this base class
   {
       string studentName = _studentName;
       return studentName;
   }
}
