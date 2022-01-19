using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_slave : MonoBehaviour
{
    public Animator anim;
    public float floor1Y = -58f, floor2Y = -98;  //x35 185
    public float speed = 1f;
    public float idleTime;
    public bool faceRight = true;
    //public float    
    public float destiX = 180f;
    
    public bool canGetin = true, intoRoom = false;
    public float yVal;
    public gameManager gm;

    float moveSpeed = 0;
    bool isResting = false;

    // Start is called before the first frame update
    private void Awake()
    {
        moveSpeed = speed;
        if (Random.Range(0, 100) > 50) intoRoom = true;
        else intoRoom = false;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(destiX, transform.position.y, 0), moveSpeed * Time.deltaTime);
        if (transform.position.x == destiX && !isResting)
        {
            isResting = true;
            StartCoroutine(idle());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if must, go in, if chance -> 50%
        //timer to check can get in doors
        //ne ne
        if (collision.tag == "Player")
            if (collision.GetComponent<playerState>().isVisible)
            {
                kill(collision.gameObject);
            }

        if (canGetin && collision.tag == "IxdObject" && collision.GetComponent<ixdScript>() != null)
        {
            ixdScript ixd = collision.GetComponent<ixdScript>();
            if (ixd.itemName == "chance" && !intoRoom)
                return;



                if (ixd.itemName == "chance") yVal = floor2Y;
            else yVal = floor1Y;

            canGetin = false;
            StartCoroutine(getInDoorIE(ixd.tpPosition, yVal));

        }

    }
    IEnumerator getInDoorIE(Vector3 pos, float y)
    {
        transform.position = new Vector3(pos.x, y, 0);
        yield return new WaitForSeconds(2);
        canGetin = true;

    }

    IEnumerator rest()
    {
        moveSpeed = 0;
        anim.Play("slave_idle");
        yield return new WaitForSeconds(Random.Range(2, 5));

        moveSpeed = speed;
        anim.Play("slave_walk");
    }

    IEnumerator idle() //decide goinig in door here
    {
        moveSpeed = 0;
        anim.Play("slave_idle");
        yield return new WaitForSeconds(Random.Range(2, 5));

        if (Random.Range(0, 100) > 50) intoRoom = true;
        else intoRoom = false;

        if (faceRight) destiX = 180f;
        else destiX = 35;
        moveSpeed = speed;
        anim.Play("slave_walk");
        flip();
        yield return new WaitForSeconds(1);
        isResting = false;

        
    }
    void flip()
    {
        faceRight = !faceRight;

        if (faceRight)
            transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);

    }

    void kill(GameObject target)
    {

        target.GetComponent<playerMovement>().ctrlable = false;
        target.GetComponent<playerMovement>().setMovementZero();
        target.GetComponent<playerState>().anim.Play("leon_scared");
        gm.gameoverReloadScene();
    }
}
