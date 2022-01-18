using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectActivator : MonoBehaviour
{
    [SerializeField]
    GameObject activateObject;

    [SerializeField]
    GameObject deactivateObject;

    public void objectActivate()
    {
        activateObject.SetActive(true);
        deactivateObject.SetActive(false);
    }
}
