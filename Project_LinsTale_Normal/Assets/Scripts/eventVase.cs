using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventVase : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public playerMovement leonPM;
    public GameObject mom_Room;
    public GameObject mom_Timeline;
    public AudioSource sfx;

    public void vaseFall()
    {
        anim.SetTrigger("fall");
        Destroy(GetComponent<ixdScript>());
        GetComponent<Renderer>().material.SetFloat("Vector1_9378A4B7", 0f);
        StartCoroutine(vaseIE());

        //Destroy(this);
    }

    IEnumerator vaseIE()
    {
        leonPM.ctrlable = false;
        yield return new WaitForSeconds(2);
        leonPM.ctrlable = true;
        sfx.Play();
        yield return new WaitForSeconds(3);
        mom_Room.SetActive(false);
        mom_Timeline.SetActive(true);
    }
}
