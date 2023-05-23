using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour
{
    [SerializeField]
    private Button ProfileBtn;
    [SerializeField]
    private Button CourseBtn;
    [SerializeField]
    private Button ScoreBtn;
    [SerializeField]
    private Button LogOutBtn;

    [SerializeField]
    private GameObject ProfileContent;
    [SerializeField]
    private GameObject CourseContent;
    [SerializeField]
    private GameObject ScoreContent;

    private ProfilePresenter _profilePresenter;

    // Start is called before the first frame update
    void Start()
    {
        _profilePresenter = new ProfilePresenter(this, ProfileContent);
        ProfileBtn?.onClick.AddListener(() => _profilePresenter.ChangeContentWindow(ProfileContent));
        
        CourseBtn?.onClick.AddListener(() => _profilePresenter.ChangeContentWindow(CourseContent));
        CourseBtn?.onClick.AddListener(() => _profilePresenter.FillCourseContent());

        ScoreBtn?.onClick.AddListener(() => _profilePresenter.ChangeContentWindow(ScoreContent));
        ScoreBtn?.onClick.AddListener(() => _profilePresenter.FillScoreContent());

        LogOutBtn?.onClick.AddListener(() => _profilePresenter.Logout());
    }
}
