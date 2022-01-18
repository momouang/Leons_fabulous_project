using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSpexialTile : MonoBehaviour
{
    public float currentWeight = 0f, smoothSpeed = 1f;
    public Transform gate;
    public Animator anim;

    bool ixable = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ixable)
        {
            anim.SetBool("isPressed", true);

            if (collision.tag == "Player")
                currentWeight += 2f;

            else if (collision.tag == "IxdObject")
                currentWeight += 5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ixable)
        {
            anim.SetBool("isPressed", false);

            if (collision.tag == "Player")
                currentWeight -= 2f;

            else if (collision.tag == "IxdObject")
                currentWeight -= 5f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "IxdObject")
        {
            currentWeight = 5f;
            ixable = false;
            anim.SetBool("isPressed", true);
        }
    }


    private void Update()
    {
        currentWeight = Mathf.Clamp(currentWeight, 0f, 6f);
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(0, currentWeight, 0f);
        Vector3 smoothedPos = Vector3.Lerp(gate.localPosition, desiredPos, smoothSpeed);
        gate.localPosition = smoothedPos;
    }
}
