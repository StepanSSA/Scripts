using System;
using System.Threading.Tasks;

public class CourseRequests : BaseRequest
{
    public CourseRequests()
        :base() { }

    public async Task<string> GetUserCourses()
    {
        var user = _userRepository.SelectUser();
        var requestPath = new Uri(_httpClient.BaseAddress.ToString() + $"/Course/Course/UserCourse?userId={user.Id}");
        var response =  await _httpClient.GetAsync(requestPath);
        return await response.Content.ReadAsStringAsync();
    }


    public async Task<string> GetCourse(string courseId)
    {
        var requestPath = new Uri(_httpClient.BaseAddress.ToString() + "/Course/" + courseId);
        var response = await _httpClient.GetAsync(requestPath);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetHomeworkDescription(string userId)
    {
        var requestPath = new Uri(_httpClient.BaseAddress.ToString() + "/Homework/Homework/GetDescription?userId=" + userId);
        var response = await _httpClient.GetAsync(requestPath);
        return await response.Content.ReadAsStringAsync();
    }

}
