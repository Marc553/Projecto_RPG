using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving;

    [Tooltip("Time it takes for the enemy to take a step")]
    [SerializeField] private float timeToMakeStep;
    //Time the enemy has been taking a step

    private float timeToMakeStepCounter;

    [Tooltip("Time the enemy takes between succesive steps")]
    [SerializeField] private float timeBetweenStep;
    //Time since the last step taekn by the enemy

    private float timeBetweenStepCounter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepCounter = timeBetweenStep;
        timeToMakeStepCounter = timeToMakeStep;
    }

    private void Update()
    {
        if(isMoving)
        {
            timeToMakeStep -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;

            if(timeToMakeStep < 0)
            {
                isMoving = false;
                timeBetweenStepCounter = timeBetweenStep;
                _rigidbody.velocity = Vector2.zero;
            }
        }

        else
        {
            timeBetweenStep -= Time.deltaTime;
            if(timeBetweenStepCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }
    }

}
