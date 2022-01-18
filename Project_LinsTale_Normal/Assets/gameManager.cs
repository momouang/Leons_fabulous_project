using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    [SerializeField]
    Animator panelAnimator;
    [SerializeField]
    Animator gameOverAnimator;

    public Animator lilyAnim;

    int currentSceneIndex;
    public int nextSceneIndex = 0;
    public bool leonReady = false, lilyReady = false;
    public void Awake()
    {
        panelAnimator.Play("CameraCap_fadeOut");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (leonReady && lilyReady)
            StartCoroutine(loadNextSceneIE(nextSceneIndex));
    }

    public void gameoverReloadScene()
    {
        StartCoroutine(gameOverLoadScene(currentSceneIndex));
    }

    public void loadSceneIndex(int i)
    {
        StartCoroutine(gameOverLoadScene(i));
    }

    IEnumerator gameOverLoadScene(int i)
    {
        yield return new WaitForSeconds(3);
        gameOverAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        panelAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        gameOverAnimator.Play("CameraCap_fadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(i);
    }

    IEnumerator loadNextSceneIE(int i)
    {
        yield return new WaitForSeconds(2);
        panelAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(i);
    }
}
