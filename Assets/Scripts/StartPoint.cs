using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
