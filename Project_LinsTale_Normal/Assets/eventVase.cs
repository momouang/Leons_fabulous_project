using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventVase : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    public void vaseFall()
    {
        anim.SetTrigger("fall");
        Destroy(GetComponent<ixdScript>());
        GetComponent<Renderer>().material.SetFloat("Vector1_9378A4B7", 0f);
        Destroy(this);
    }
}
