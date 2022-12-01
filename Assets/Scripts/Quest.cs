using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questId;
    public bool questCompleted;
    public string title;
    public string startText;
    public string completedText;
    private QuestManager questManager;

    public void StartQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText($"{title}\n{ startText}");
    }

    public void CompleteQuest()
    {
        questManager = FindObjectOfType<QuestManager>();
        questManager.ShowQuestText($"{title}\n{ completedText}");
        questCompleted = true;
        gameObject.SetActive(false);
    }


}
