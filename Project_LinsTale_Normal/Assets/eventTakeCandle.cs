using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTakeCandle : MonoBehaviour
{
    public GameObject offCandle, onCandle;
    public Animator anim;

    public void getCandle()
    {
        offCandle.SetActive(false);
        onCandle.SetActive(true);

        anim.SetLayerWeight(1, 1f);
    }
}
