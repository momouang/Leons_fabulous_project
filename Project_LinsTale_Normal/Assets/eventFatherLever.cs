using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventFatherLever : MonoBehaviour
{
    public Animator gateAnim;
    bool canOpen = true;

    public void gateOpen()
    {
        if (canOpen)
        {
            canOpen = false;
            gateAnim.SetTrigger("gateTrigger");
            StartCoroutine(gateTimer());
        }
    }

    IEnumerator gateTimer()
    {
        yield return new WaitForSeconds(4);
        canOpen = true;
    }
}
