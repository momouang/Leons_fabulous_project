using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ixdState { Teleport, Item}

public class ixdScript : MonoBehaviour
{
    GameObject player;

    [Header("Select Mode")]
    public ixdState interactionMode;

    [Header("Teleporter info")]
    public Vector3 tpPosition;

    private void Start()
    {
        //Interact();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.gameObject.GetComponent<playerState>().isInteract)
        {
            player = collision.gameObject;
            Interact();
            collision.gameObject.GetComponent<playerState>().setIxdFalse();
        }
    }

    public void Interact()
    {
        //if (interactionMode == ixdState.Teleport) Debug.Log("Oh yeah it's 0");
        //else if (interactionMode == ixdState.Item) Debug.Log("Oh snap it's 1");

        switch (interactionMode)
        {
            case ixdState.Teleport:
                player.transform.position = tpPosition;
                break;
        }
    }
}
