using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving = true;

    [Tooltip("Time it takes for the enemy to take a step")]
    [SerializeField] private float timeToMakeStep;
    //Time the enemy has been taking a step

    private float timeToMakeStepCounter;

    [Tooltip("Time the enemy takes between succesive steps")]
    [SerializeField] private float timeBetweenStep;
    //Time since the last step taekn by the enemy

    [Tooltip("If enemy movement is not random, enemyDirections needs to have at least two elements")]
    [SerializeField] private bool hasRandomMove;
    [Tooltip("Directions the enemy will follow to complete a path. The idea is that it should be cyclical.Components must be - 1, 0 or 1")]
    [SerializeField] private Vector2[] enemyDirections;
    private int indexDirection;

    private float timeBetweenStepCounter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepCounter = timeBetweenStep * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);
        timeToMakeStepCounter = timeToMakeStep * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);

        indexDirection = 0;

        directionToMove = hasRandomMove ? new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) : enemyDirections[indexDirection]    ;
    }

    private void Update()
    {
        if(isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;

            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepCounter = timeBetweenStep;
                _rigidbody.velocity = Vector2.zero;
            }
        }

        else
        {
            timeBetweenStepCounter -= Time.deltaTime;
            if(timeBetweenStepCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                if (hasRandomMove)
                {
                    directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                }
                else
                {
                    indexDirection++;
                    if (indexDirection >= enemyDirections.Length)
                    {
                        indexDirection = 0;
                    }
                    directionToMove = enemyDirections[indexDirection];
                }
            }
        }
    }
}   
