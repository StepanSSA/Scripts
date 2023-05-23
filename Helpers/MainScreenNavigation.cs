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
    /// Включает окно курса и передает данные CourseModel в CourseView
    /// </summary>
    /// <param name="courseModel"></param>
    public void OpenCourseWindow(CourseModel courseModel)
    {
        WindowHelper.ChangeWindow(ListCourseWindow, CourseWindow);
        CourseWindow.GetComponent<CourseView>().FillWindow(courseModel);
    }

    /// <summary>
    /// Включает окно списка курсов
    /// </summary>
    private void OpenCourseList()
    {
        ProfileWindow.SetActive(false);
        CourseWindow.SetActive(false);
        ListCourseWindow.SetActive(true);
    }

    /// <summary>
    /// Включает окно профиля
    /// </summary>
    private void OpenProfile()
    {
        CourseWindow.SetActive(false);
        ListCourseWindow.SetActive(false);
        ProfileWindow.SetActive(true);
    }

}
