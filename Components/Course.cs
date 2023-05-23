using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Course : MonoBehaviour
{
    [SerializeField]
    private GameObject CourseItemPrefab;
    [SerializeField]
    private GameObject CourseList;
    public bool isFilling = false;
    public void FillCourse(List<CourseBlockModel> course)
    {
        if(course.Count < 1) 
            return;

        var posY = -50;

        foreach (var item in course)
        {
            var block = Instantiate(CourseItemPrefab, CourseList.transform);
            block.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY);
            block.GetComponentInChildren<Button>().onClick.AddListener(() => { Debug.Log(item.Id); });
            block.GetComponentInChildren<TMP_Text>().text = item.Name;

            if(block != null) isFilling = true;

            posY -= 100;
        }
    }
}
