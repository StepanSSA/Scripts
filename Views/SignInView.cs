using UnityEngine;
using UnityEngine.UI;

public class SignInView : MonoBehaviour
{
    [SerializeField]
    private Button SignInBtn;
    [SerializeField]
    private GameObject Username;
    [SerializeField]
    private GameObject Password;

    [SerializeField]
    private GameObject AuthWindow;
    [SerializeField]
    private GameObject MainWindow;

    private SignInPresenter _presenter;

    // Start is called before the first frame update
    void Start()
    {
        _presenter = new SignInPresenter(this);
        SignInBtn.onClick.AddListener(() => _presenter.SignIn(Username,Password));
    }

    public void ChangeWindow()
    {
        WindowHelper.ChangeWindow(AuthWindow, MainWindow);
        MainWindow.GetComponent<CourseListView>()?.FillCourseListContent();
    }


}
