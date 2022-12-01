using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public int questId;
    public bool startPoint, endPoint;
    public bool acceptQuestAutomatically;

    private QuestManager questManager;
    private bool playerInZone;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (acceptQuestAutomatically ||
             (!acceptQuestAutomatically && Input.GetMouseButtonDown(1)))
            {
                Quest q = questManager.GetQuestWithId(questId);
                if (q == null)
                {
                    // Mensaje que solo sale en fase de desarrollo
                    Debug.LogErrorFormat("La misión con id {0} no existe", questId);
                    return;
                }
                if (!q.questCompleted)
                {
                    if (startPoint)
                    {
                        if (!q.gameObject.activeInHierarchy)
                        {
                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }

                    if (endPoint)
                    {
                        if (q.gameObject.activeInHierarchy)
                        {
                            q.CompleteQuest();
                        }
                    }
                }
            }
        }

    }
}