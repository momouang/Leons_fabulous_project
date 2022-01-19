using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingCheck : MonoBehaviour
{
    public Character Player;
    public gameManager gm;
    public GameObject Canvas;
    bool leonReady = false;
    bool lilyReady = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (Player)
        {
            case Character.Leon:
                leonReady = true;
                gm.leonFinal = true;
                break;
            case Character.Lily:
                lilyReady = true;
                gm.lilyFinal = true;
                break;
        }

        Canvas.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (Player)
        {
            case Character.Leon:
                leonReady = false;
                gm.leonFinal = false;
                break;
            case Character.Lily:
                lilyReady = false;
                gm.lilyFinal = false;
                break;
        }

        Canvas.SetActive(false);
    }
}
