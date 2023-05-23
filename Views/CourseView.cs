using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CourseView : MonoBehaviour
{
    [SerializeField]
    private GameObject LessonBtnPrefab;
    [SerializeField]
    private GameObject LessonPrefab;
    [SerializeField]
    private GameObject LessonWindow;
    [SerializeField]
    private Button CourseHomePageBtn;
    [SerializeField]
    private GameObject CourseHomePage;
    [SerializeField]
    private GameObject LessonsPanel;
    [SerializeField]
    private TMP_Text CourseDescriptionText;

    private List<GameObject> LessonList = new List<GameObject>();
    private List<GameObject> BtnList = new List<GameObject>();

    private CoursePresenter _coursePresenter;

    private void Start()
    {
        
        _coursePresenter = new CoursePresenter(this);
        CourseHomePageBtn?.onClick.AddListener(() => _coursePresenter.OpenHomePage(CourseHomePage));
    }


    /// <summary>
    /// ��������� ������� ���� ���������� �����
    /// </summary>
    /// <param name="courseModel">������ �����</param>
    public void FillWindow(CourseModel courseModel)
    {
        if(courseModel == null)
            return;

        if (LessonList.Count > 0)
            Clear();

        CourseDescriptionText.text = courseModel.Name +": "+ courseModel.Description;
        var posY = -100;

        for (int i = 0; i < courseModel.Lessons.Count; i++)
        {
            CreateLessonBtn(posY, courseModel.Lessons[i]);
            posY -= 100;

        }

    }


    /// <summary>
    /// ������� ������ � ���� ��� ������ �����
    /// </summary>
    /// <param name="positionY">������ ������</param>
    /// <param name="lesson">������ �����</param>
    private void CreateLessonBtn(float positionY, LessonModel lesson)
    {

        var block = Instantiate(LessonBtnPrefab, LessonsPanel.transform);

        var blockAnchoredPositionX = block.GetComponent<RectTransform>().anchoredPosition.x;
        block.GetComponent<RectTransform>().anchoredPosition = new Vector2(blockAnchoredPositionX, positionY);

        var textList = block.GetComponentsInChildren<TMP_Text>().Where(t => t.tag == "ButtonName").FirstOrDefault();
        textList.text = lesson.Name;

        var lessonWindow = CreateLessonWindowContent(lesson);
        block.GetComponentInChildren<Button>().onClick.AddListener(() => _coursePresenter.ChangeLesson(lessonWindow, CourseHomePage));

        LessonList.Add(lessonWindow);
        BtnList.Add(block);
    }


    /// <summary>
    /// ������ ���� �����
    /// </summary>
    /// <param name="lesson">������ �����</param>
    /// <returns></returns>
    private GameObject CreateLessonWindowContent(LessonModel lesson)
    {
        var window = Instantiate(LessonPrefab, LessonWindow.transform);
        window.GetComponentInChildren<TMP_Text>().text = lesson.Name + ": " + lesson.Description;
        window.GetComponentInChildren<VideoPlayer>().url = lesson.VideoPath;
        window.SetActive(false);

        return window;
    }


    /// <summary>
    /// ������� ������ ������
    /// </summary>
    private void Clear()
    {
        foreach (var item in LessonList)
        {
            Destroy(item.gameObject);
        }
        
        foreach (var item in BtnList)
        {
            Destroy(item.gameObject);
        }
        BtnList.RemoveRange(0, BtnList.Count);
    }

}

