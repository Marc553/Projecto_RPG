using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public const string HORIZONTAL= "Horizontal", VERTICAL = "Vertical";
    private float inputTol = 0.2f; // Input tolerance 
    private float xInput, yInput;

    private bool isWalking;
    private Vector2 lastDirection;
    private Animator _animator;

    private Rigidbody2D _rigidbody;
 
       private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {   
        yInput = Input.GetAxisRaw(VERTICAL);
        xInput = Input.GetAxisRaw(HORIZONTAL);
        isWalking = false;
       
        //  Horizontal Input
        if(Mathf.Abs(xInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(xInput * speed, 0);
            
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }
        
        
        if(Mathf.Abs(yInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(0 , yInput * speed);
            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }

    private void LateUpdate()
    {   if(!isWalking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);
        _animator.SetFloat("LasHorizontal", lastDirection.x);
        _animator.SetFloat("LastVertical", lastDirection.y);
        _animator.SetBool("IsWalking", isWalking);
        
    }

}
