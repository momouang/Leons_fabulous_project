using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    float camY = 32f;
    //public float val_Y = 10.8f;
    // Update is called once per frame
    void Update()
    {
        if (target.position.y > 20f && target.position.y < 40f) camY = 32f;
        else if (target.position.y > 60f && target.position.y < 80f) camY = 72f;
        
        transform.position = new Vector3(target.position.x, camY, -10f);
    }
}
