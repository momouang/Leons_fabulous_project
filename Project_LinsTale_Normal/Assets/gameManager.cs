using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    [SerializeField]
    Animator panelAnimator;

    public void Awake()
    {
        panelAnimator.Play("CameraCap_fadeOut");
    }

    public void loadSceneIndex(int i)
    {
        StartCoroutine(gameOverLoadScene(i));
    }

    IEnumerator gameOverLoadScene(int i)
    {
        yield return new WaitForSeconds(4);
        panelAnimator.Play("CameraCap_fadeBlack");
        SceneManager.LoadScene(i);
    }
}
