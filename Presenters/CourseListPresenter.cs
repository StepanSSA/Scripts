using Newtonsoft.Json;
using System.Collections.Generic;

public class CourseListPresenter
{
    private CourseListView _coursesView;
    private CourseRequests _courseRequests;

    public CourseListPresenter(CourseListView listCoursesView)
    {
        _coursesView = listCoursesView;
        _courseRequests = new CourseRequests();
        
    }

    /// <summary>
    /// Запрашивает список курсов пользователя и передает его представлению списка курсов
    /// </summary>
    public async void GetCourseListContent()
    {
        var stringCourseData = await _courseRequests.GetUserCourses();
        var CourseBlockList = JsonConvert.DeserializeObject<List<CourseBlockModel>>(stringCourseData);

        _coursesView.FillCourseListContent(CourseBlockList);
    }


    /// <summary>
    /// Запрашивает данные курса и передает их представления курса
    /// </summary>
    /// <param name="courseId">Id курса</param>
    public async void GetCourseContent(string courseId)
    {
        var stringCourseData = await _courseRequests.GetCourse(courseId);
        var CourseData = JsonConvert.DeserializeObject<CourseModel>(stringCourseData);

        _coursesView.GetComponentInParent<MainScreenNavigation>().OpenCourseWindow(CourseData);
    }


}
