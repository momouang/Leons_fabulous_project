using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character { Leon, Lily}
public class playerMovement : MonoBehaviour
{
    public Character playingCharacter;

    public characterController2D controller;
    public Animator anim;

    public bool ctrlable = true;
    public float moveSpeed = 40f;

    float horizontalMove = 0f;
    float _moveSpeed;
    bool jump = false;
    bool crouch = false;

    string _horizontal, _vertical, _interact, _jump;

    private void Start()
    {
        _moveSpeed = moveSpeed;

        switch (playingCharacter)
        {
            case Character.Leon:
                _horizontal = "Horizontal";
                _vertical = "Vertical";
                _jump = "Jump";
                _interact = "Interact";
                break;

            case Character.Lily:
                _horizontal = "Horizontal2";
                _vertical = "Vertical2";
                _jump = "Jump2";
                _interact = "Interact2";
                break;
        }
        
    }
    private void Update()
    {
        if (ctrlable)
        {
            //Debug.Log(Input.GetAxisRaw("Horizontal"));
            
            horizontalMove = Input.GetAxisRaw(_horizontal) * _moveSpeed;
            anim.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));
            if (Input.GetAxisRaw(_vertical) < 0f)
            {
                anim.SetBool("isCrouch", true);
                crouch = true;
                //_moveSpeed = moveSpeed / 2;
            }
            else
            {
                anim.SetBool("isCrouch", false);
                crouch = false;
                //_moveSpeed = moveSpeed;
            }

            if (Input.GetButtonDown(_jump) && Input.GetAxisRaw(_vertical) >= 0f)
            {
                jump = true;
                anim.SetBool("isJump", true);
            }

            //if (Input.GetKeyDown(KeyCode.E)) GetComponent<playerState>().setIxd();
            if (Input.GetButtonDown(_interact)) GetComponent<playerState>().setIxd();
        }
        
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void onLanding()
    {
        anim.SetBool("isJump", false);
    }
}
