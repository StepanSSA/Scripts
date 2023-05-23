using Assets.Scripts.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePresenter 
{
    private UserRepository _userRepository;
    private readonly ProfileView _profileView;
    private GameObject _currentContentWindow;

    public ProfilePresenter(ProfileView profileView, GameObject currentContentWindow)
    {
        _userRepository = new UserRepository();
        _profileView=profileView;
        _currentContentWindow=currentContentWindow;
        FillProfileContent();
    }

    /// <summary>
    /// Включает выбранное окно, выключает предыдущее
    /// </summary>
    /// <param name="nextWindow">выбранное окно</param>
    public void ChangeContentWindow(GameObject nextWindow) 
    { 
        WindowHelper.ChangeWindow(_currentContentWindow, nextWindow);
        _currentContentWindow = nextWindow;
    }

    /// <summary>
    /// Выход из аккаунта
    /// </summary>
    public void Logout()
    {
        var userRepo = new UserRepository();
        userRepo.DropTable();
    }

    /// <summary>
    /// Запрашивает данные профиля пользователя и передает их в компонент Profile
    /// </summary>
    private void FillProfileContent()
    {
        var user = _userRepository.SelectUser();
        _profileView.GetComponentInChildren<Profile>().FillProfile(user);
    }

    /// <summary>
    /// Запрашивает данные курсов пользователя и передает их в компонент Course
    /// </summary>
    public async void FillCourseContent()
    {
        if (_profileView.GetComponentInChildren<Course>().isFilling)
            return;

        var request = new CourseRequests();
        var response = await request.GetUserCourses();
        var courseData = JsonConvert.DeserializeObject<List<CourseBlockModel>>(response);
        
        _profileView.GetComponentInChildren<Course>().FillCourse(courseData);
    }


    /// <summary>
    /// Запрашивает оценки пользователя и передает их в компонент Score
    /// </summary>
    public async void FillScoreContent()
    {
        if (_profileView.GetComponentInChildren<Score>().isFilling)
            return;

        var user = _userRepository.SelectUser();

        var request = new CourseRequests();
        var response = await request.GetHomeworkDescription(user.Id);
        var homework = JsonConvert.DeserializeObject<List<HomeworkDescription>>(response);

        _profileView.GetComponentInChildren<Score>().FillScore(homework);
    }

}
