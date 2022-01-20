using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gameStartScript : MonoBehaviour
{
    public gameManager gm;
    public Animator blackAnim;
    public GameObject opening, black;

    public void gameStart()
    {
        //black.SetActive(true);
        StartCoroutine(gameStartingIE());
        Debug.Log("!!!!!!!");
    }

    IEnumerator gameStartingIE()
    {
        //blackAnim.gameObject.SetActive(true);
        //yield return new WaitForSeconds(0.1f);
        opening.SetActive(false);
        blackAnim.Play("black_fadeBlack");
        Debug.Log("Fading");
        yield return new WaitForSeconds(2);
        gm.simpleLoadScene(1);
    }
}
