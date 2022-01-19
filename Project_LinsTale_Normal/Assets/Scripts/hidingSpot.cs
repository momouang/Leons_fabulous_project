using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<playerState>().setVisible(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<playerState>().setVisible(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<playerState>().setVisible(true);
    }
}
