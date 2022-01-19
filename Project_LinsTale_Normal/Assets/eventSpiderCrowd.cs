using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSpiderCrowd : MonoBehaviour
{
    public bool detectionZone;
    public Animator spiderCrowdAnim;
    public gameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!detectionZone)
            {
                collision.GetComponent<playerMovement>().ctrlable = false;
                collision.GetComponent<playerMovement>().setMovementZero();
                collision.GetComponent<playerState>().anim.Play("leon_scared");
                gm.gameoverReloadScene();
            }
            else
            {
                spiderCrowdAnim.Play("spiderCrowdDown");
                gameObject.SetActive(false);
            }
            
        }
    }
}
