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
    /// �������� ����� ����, ��������� �������
    /// </summary>
    /// <param name="nextLesson">����� ����</param>
    /// <param name="homePage">�������� ��������</param>
    public void ChangeLesson(GameObject nextLesson, GameObject homePage)
    {
        if(_previouseLesson != null)
            _previouseLesson?.SetActive(false);
        
        homePage.SetActive(false);//?
        nextLesson.SetActive(true);
        _previouseLesson = nextLesson;
    }

    /// <summary>
    /// ��������� ������� ����, �������� �������� ��������
    /// </summary>
    /// <param name="homePage"></param>
    public void OpenHomePage(GameObject homePage)
    {
        _previouseLesson?.SetActive(false);
        homePage.SetActive(true);
    }


}
