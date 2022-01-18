using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class checkPointScript : MonoBehaviour
{
    public Character Player;
    public gameManager gm;
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (Player)
        {
            case Character.Leon:
                gm.leonReady = true;
                break;
            case Character.Lily:
                gm.lilyReady = true;
                break;
        }

        Canvas.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (Player)
        {
            case Character.Leon:
                gm.leonReady = false;
                break;
            case Character.Lily:
                gm.lilyReady = false;
                break;
        }

        Canvas.SetActive(false);
    }
}
