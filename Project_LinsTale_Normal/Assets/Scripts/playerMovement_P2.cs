using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement_P2 : MonoBehaviour
{
    public characterController2D controller;
    public Animator anim;

    public float moveSpeed = 40f;

    float horizontalMove = 0f;

    private void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal2") * moveSpeed;
        anim.SetFloat("moveSpeed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
