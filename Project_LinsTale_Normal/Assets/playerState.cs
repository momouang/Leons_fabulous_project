using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    public bool isInteract = false;
    public Animator anim;

    
    public void setIxd()
    {
        isInteract = true;
        Debug.Log("IXD = " + isInteract);
        //setIxdFalse();
    }

    public void setIxdFalse()
    {
        isInteract = false;
        Debug.Log("IXD = " + isInteract);
    }

    public void setAnimOn()
    {
        anim.enabled = true;
    }
    public void setAnimOff()
    {
        anim.enabled = false;
    }
}
