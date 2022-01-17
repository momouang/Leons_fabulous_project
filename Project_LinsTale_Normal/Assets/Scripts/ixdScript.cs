using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum ixdState { Teleport, Item, Interactable, LockedDoor, DisableAndEnable}
[RequireComponent(typeof(BoxCollider2D))]
public class ixdScript : MonoBehaviour
{
    GameObject player;
    private Renderer _renderer;
    private Material _material;
    
    [Header("Select Mode")]
    public ixdState interactionMode;

    [Header("Enable/Disable Objects")]
    [SerializeField]
    bool CanDisableObjects = true;

    [SerializeField]
    bool CanEnableObjects = true;

    [SerializeField]
    bool disableAfterUnlock = true;

    [Header("Extra Renderers")]
    public Renderer[] extraRenderers;

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

    [Header("Events")]
    public UnityEvent InteractionEvents;

    private void Start()
    {
        if (GetComponent<Renderer>())
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material.SetFloat("Vector1_9378A4B7", 0f);
        }

        if (extraRenderers.Length != 0)
        {
            for (int i = 0; i < extraRenderers.Length; i++)
            {
                Renderer _exRenderer = extraRenderers[i];
                _exRenderer.material.SetFloat("Vector1_9378A4B7", 0f);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name + "Entered" + gameObject.name);
        if (collision.tag == "Player" && GetComponent<Renderer>())
            _renderer.material.SetFloat("Vector1_9378A4B7", 0.99f);

        if (extraRenderers.Length != 0)
        {
            for (int i = 0; i < extraRenderers.Length; i++)
            {
                Renderer _exRenderer = extraRenderers[i];
                _exRenderer.material.SetFloat("Vector1_9378A4B7", 0.99f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GetComponent<Renderer>())
            _renderer.material.SetFloat("Vector1_9378A4B7", 0f);

        if (extraRenderers.Length != 0)
        {
            for (int i = 0; i < extraRenderers.Length; i++)
            {
                Renderer _exRenderer = extraRenderers[i];
                _exRenderer.material.SetFloat("Vector1_9378A4B7", 0f);
            }
        }
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
                //disableObjects();
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
                if (disableAfterUnlock) gameObject.SetActive(false);
                break;

            case ixdState.Interactable:
                InteractionEvents.Invoke();
                break;

            case ixdState.DisableAndEnable:
                enAndDis();

                break;
        }

        //if (CanDisableObjects) disableObjects();
        //if (CanEnableObjects) enableObjects();
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
