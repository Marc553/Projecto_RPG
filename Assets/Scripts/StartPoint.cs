using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    private PlayerController player;
    public string uuid; //uuid : universal unique identifier;

    [SerializeField] private Vector2 facingDirection;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if(!player.nextUuid.Equals(uuid))
        {
            return;
        }
        player.transform.position = transform.position;
        player.lastDirection = facingDirection;

        GameObject confiner = GameObject.Find("Camera Confiner");
        if (confiner != null)
        {
            FindObjectOfType<CinemachineConfiner2D>() .
            m_BoundingShape2D = confiner.GetComponent<PolygonCollider2D>();
        }
    }
}