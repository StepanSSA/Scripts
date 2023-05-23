using System.Collections.Generic;
public class CourseModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public double Price { get; set; }
    public bool Confirmed { get; set; }
    public List<LessonModel> Lessons { get; set; }
    public TeacherModel Teacher { get; set; }


}
