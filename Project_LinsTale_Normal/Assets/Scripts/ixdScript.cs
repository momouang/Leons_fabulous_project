using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ixdState { Teleport, Item, Interactable, LockedDoor, DisableAndEnable}
[RequireComponent(typeof(BoxCollider2D))]
public class ixdScript : MonoBehaviour
{
    GameObject player;

    [Header("Select Mode")]
    public ixdState interactionMode;

    [Header("Teleporter info")]
    public Vector3 tpPosition;

    [Header("Item Info")]
    public string itemName;

    [Header("Lock Info")]
    public string[] requiredKeys;

    [Header("Enable Objects")]
    public GameObject[] enObjs;

    [Header("Disable Objects")]
    public GameObject[] disObjs;


    private void Start()
    {
        //Interact();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if(collision.tag == "Player")
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

            case ixdState.Item:
                player.GetComponent<playerState>().giveItem(itemName);
                disableObjects();
                gameObject.SetActive(false);
                break;

            case ixdState.LockedDoor:
                for(int i = 0; i<requiredKeys.Length; i++)
                {
                    if (!player.GetComponent<playerState>().itemList.Contains(requiredKeys[i]))
                    {
                        //player.GetComponent<playerState>().itemList.Remove(requiredKeys[i]);

                        Debug.Log("You need required keys.");
                        return;
                        //player.GetComponent<playerState>().removeItem(requiredKeys[i]);
                        //enAndDis();
                    }
                }

                for (int i = 0; i < requiredKeys.Length; i++)
                    player.GetComponent<playerState>().removeItem(requiredKeys[i]);
                enAndDis();
                gameObject.SetActive(false);
                break;

            case ixdState.DisableAndEnable:
                enAndDis();

                break;
        }
    }

    void enAndDis()
    {
        enableObjects();
        disableObjects();
    }

    void enableObjects()
    {
        if(enObjs.Length!=0)
            for (int i = 0; i < enObjs.Length; i++)
                enObjs[i].SetActive(true);
    }

    void disableObjects()
    {
        if(disObjs.Length!=0)
            for (int i = 0; i < disObjs.Length; i++)
                disObjs[i].SetActive(false);
    }
}
