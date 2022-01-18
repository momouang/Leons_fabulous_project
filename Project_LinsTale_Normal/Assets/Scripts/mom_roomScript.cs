using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mom_roomScript : MonoBehaviour
{
    public Animator anim, leonAnim;
    public UnityEvent gmEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("isStare", true);
            if (collision.GetComponent<playerState>().isVisible)
            {
                collision.GetComponent<playerMovement>().ctrlable = false;
                collision.GetComponent<playerMovement>().setMovementZero();
                leonAnim.Play("leon_scared");
                gmEvent.Invoke();
            }
        }
            

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            anim.SetBool("isStare", false);
    }
}
