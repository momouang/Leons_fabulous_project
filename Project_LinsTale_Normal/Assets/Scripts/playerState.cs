using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    public bool isInteract = false;
    public bool isVisible = true;

    public Animator anim;
    public List<string> itemList = new List<string>();

    public void giveItem(string item)
    {
        itemList.Add(item);
        string currentList = "Now has ";
        foreach (var x in itemList)
            currentList += x.ToString() + ", ";
        currentList += "nothing else.";
        Debug.Log(currentList);
            //Debug.Log(x.ToString());
    }
    
    public void removeItem(string item)
    {
        itemList.Remove(item);
        string currentList = "Now has ";
        foreach (var x in itemList)
            currentList += x.ToString() + ", ";
        currentList += "nothing else.";
        Debug.Log(currentList);
    }

    public void setIxd()
    {
        isInteract = true;
        //Debug.Log("IXD = " + isInteract);
        //setIxdFalse();
        Invoke("setIxdFalse", 0.3f);
    }

    public void setIxdFalse()
    {
        isInteract = false;
        //Debug.Log("IXD = " + isInteract);
    }

    public void setVisible(bool vis)
    {
        isVisible = vis;
    }

    public void setAnimOn()
    {
        anim.enabled = true;
    }
    public void setAnimOff()
    {
        anim.enabled = false;
    }
}
