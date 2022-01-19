using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTray : MonoBehaviour
{
    public float xPos = 0f;
    public float speed = 5f;
    bool canOpen = false;

    private void Update()
    {
        if (canOpen)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(xPos, transform.localPosition.y, 0), speed*Time.deltaTime);
        }
        if (transform.localPosition.x == xPos) Destroy(this);
    }

    public void trayOpen()
    {
        canOpen = true;
    }
}
