using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourseListView : MonoBehaviour
{
    [SerializeField]
    private GameObject CourseBlockPrefab;

    private CourseListPresenter _coursePresenter;

    private void Start()
    {
        _coursePresenter = new CourseListPresenter(this);
        StartFilling();
    } 

    public void StartFilling()
    {
        if(_coursePresenter != null)
            _coursePresenter.GetCourseListContent();
    }


    /// <summary>
    /// Заполняет окно списка курсов объектами CourseBlock
    /// </summary>
    public void FillCourseListContent(List<CourseBlockModel> courseBlocks = null)
    {

        if(courseBlocks.Count < 1)
            return;

        float posLeft = 0f;
        float posTop = 0f;
        float widthFromLeftToFirst = 300f;

        for (int i = 0; i < courseBlocks.Count; i++)
        {
            var block = Instantiate(CourseBlockPrefab, gameObject.transform);
            block.GetComponent<RectTransform>().anchoredPosition = new Vector2(posLeft, posTop);

            var textList = block.GetComponentsInChildren<TMP_Text>();
            foreach (var text in textList) 
            {
                if(text.tag == "CourseName")
                {
                    text.text = courseBlocks[i].Name;
                }
                else if(text.tag == "CourseDescription")
                {
                    text.text = courseBlocks[i].Description;
                }
            }
            var courseId = courseBlocks[i].Id;
            block.GetComponentInChildren<Button>().onClick.AddListener(() => _coursePresenter.GetCourseContent(courseId));

            posLeft += 300;
            if (posLeft + widthFromLeftToFirst > Screen.width)
            {
                posLeft = 0;
                posTop -= 400;
            }
        }        
    }
    
}
