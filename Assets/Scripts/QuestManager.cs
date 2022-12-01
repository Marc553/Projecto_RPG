using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        foreach (Transform t in transform)
        {
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
    }

    public void ShowQuestText(string questText)
    {
        dialogManager.ShowDialog(new string[] {questText});
    }

    public Quest GetQuestWithId(int id)
    {
        Quest q = null;
        foreach (Quest temp in quests)
        {
            if (temp.questId == id)
            {
                q = temp;
            }
        }
        return q;
    }

}
