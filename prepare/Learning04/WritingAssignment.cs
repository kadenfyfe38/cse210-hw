class WritingAssignment : Assignment
{
   //attributes
   private string _title;
   //constructor
   public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
   {
       _title = title;
   }
   //behaviours
   public string GetWritingInformation()
   {
       string studentName = GetStudentName();
       string WritingInfo = $"{_title} by {studentName}";
       return WritingInfo;
   }
}
