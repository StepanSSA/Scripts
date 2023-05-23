using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursePresenter
{
    private readonly CourseView _courseView;
    
    private GameObject _previouseLesson;

    public CoursePresenter(CourseView courseView)
    {
        _courseView = courseView;
        _previouseLesson = null;
    }

    /// <summary>
    /// Включает новый урок, выключает текущий
    /// </summary>
    /// <param name="nextLesson">Новый урок</param>
    /// <param name="homePage">Домашняя страница</param>
    public void ChangeLesson(GameObject nextLesson, GameObject homePage)
    {
        if(_previouseLesson != null)
            _previouseLesson?.SetActive(false);
        
        homePage.SetActive(false);//?
        nextLesson.SetActive(true);
        _previouseLesson = nextLesson;
    }

    /// <summary>
    /// Выключает текущий урок, включает домашнюю страницу
    /// </summary>
    /// <param name="homePage"></param>
    public void OpenHomePage(GameObject homePage)
    {
        _previouseLesson?.SetActive(false);
        homePage.SetActive(true);
    }


}
