using Assets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private GameObject ScoreItemPrefab;
    [SerializeField]
    private GameObject ScoreInfoPanel;

    public bool isFilling = false;

    public void FillScore(List<HomeworkDescription> homeworks)
    {
        if(homeworks.Count < 1)
            return;

        var posY = -50;

        foreach (var item in homeworks)
        {
            var block = Instantiate(ScoreItemPrefab, ScoreInfoPanel.transform);
            block.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, posY);

            var textList = block.GetComponentsInChildren<TMP_Text>();

            if (string.IsNullOrEmpty(item.CourseName))
                item.CourseName = "Нет данных";
            if (string.IsNullOrEmpty(item.LessonName))
                item.LessonName = "Нет данных";

            textList.Where(t => t.tag == "ScoreCourse").FirstOrDefault().text = item.CourseName;
            textList.Where(t => t.tag == "ScoreLesson").FirstOrDefault().text = item.LessonName;
            textList.Where(t => t.tag == "ScoreScore").FirstOrDefault().text = item.Score.ToString();
            textList.Where(t => t.tag == "ScoreHomework").FirstOrDefault().text = item.date.ToString();

            if(block != null) isFilling = true;
            posY -= 100;
        }
    }
}
