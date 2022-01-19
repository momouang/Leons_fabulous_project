using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class momScript : MonoBehaviour
{
    //public Animator leonAnim;
    public UnityEvent gmEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            if (collision.GetComponent<playerState>().isVisible)
            {
                collision.GetComponent<playerMovement>().ctrlable = false;
                collision.GetComponent<playerMovement>().setMovementZero();
                collision.GetComponent<playerState>().anim.Play("leon_scared");
                gmEvent.Invoke();
            }
                
    }

    
}
