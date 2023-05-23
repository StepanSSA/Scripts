using UnityEngine;
using UnityEngine.UI;

public class MainScreenNavigation : MonoBehaviour
{
    [SerializeField] private GameObject ListCourseWindow;
    [SerializeField] private GameObject CourseWindow;
    [SerializeField] private GameObject ProfileWindow;
    [SerializeField] private Button ProfileBtn;
    [SerializeField] private Button CourseBtn;
    

    private void Start()
    {
        ProfileBtn?.onClick.AddListener(() => OpenProfile());
        CourseBtn?.onClick.AddListener(() => OpenCourseList());
    }

    /// <summary>
    /// �������� ���� ����� � �������� ������ CourseModel � CourseView
    /// </summary>
    /// <param name="courseModel"></param>
    public void OpenCourseWindow(CourseModel courseModel)
    {
        WindowHelper.ChangeWindow(ListCourseWindow, CourseWindow);
        CourseWindow.GetComponent<CourseView>().FillWindow(courseModel);
    }

    /// <summary>
    /// �������� ���� ������ ������
    /// </summary>
    private void OpenCourseList()
    {
        ProfileWindow.SetActive(false);
        CourseWindow.SetActive(false);
        ListCourseWindow.SetActive(true);
    }

    /// <summary>
    /// �������� ���� �������
    /// </summary>
    private void OpenProfile()
    {
        CourseWindow.SetActive(false);
        ListCourseWindow.SetActive(false);
        ProfileWindow.SetActive(true);
    }

}
