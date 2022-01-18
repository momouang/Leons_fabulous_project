using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTeleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform toPosition;
    public bool duplicator;

    public GameObject item;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!duplicator)
        {
            collision.transform.position = toPosition.position;
        }
        else
        {
            item.SetActive(true);
            Destroy(collision.gameObject);
        }
        
    }
}
