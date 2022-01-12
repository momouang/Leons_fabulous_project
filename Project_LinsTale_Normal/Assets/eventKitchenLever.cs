using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventKitchenLever : MonoBehaviour
{
    public Animator trapdoorAnim;

    public void trapdoorOpen()
    {
        trapdoorAnim.SetTrigger("open");
    }
}
