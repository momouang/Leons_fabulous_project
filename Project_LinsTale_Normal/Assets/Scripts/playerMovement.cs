using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public characterController2D controller;
    public Animator anim;

    public bool ctrlable = true;
    public float moveSpeed = 40f;

    float horizontalMove = 0f;
    float _moveSpeed;
    bool jump = false;

    private void Start()
    {
        _moveSpeed = moveSpeed;
        
    }
    private void Update()
    {
        if (ctrlable)
        {
            //Debug.Log(Input.GetAxisRaw("Horizontal"));
            
            horizontalMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
            anim.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));
            if (Input.GetAxisRaw("Vertical") < 0f)
            {
                anim.SetBool("isCrouch", true);
                _moveSpeed = moveSpeed / 2;
            }
            else
            {
                anim.SetBool("isCrouch", false);
                _moveSpeed = moveSpeed;
            }

            if (Input.GetButtonDown("Jump") && Input.GetAxisRaw("Vertical") >= 0f)
            {
                jump = true;
            }

        }
        
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
