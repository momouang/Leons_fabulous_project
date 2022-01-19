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

    public GameObject cameraCanvas;
    public GameObject final;
    public AudioSource goSfx;
    public Animator lilyAnim;

    int currentSceneIndex;
    public int nextSceneIndex = 0;
    public bool lilyCandleOnStart;
    public bool leonReady = false, lilyReady = false, leonFinal = false, lilyFinal = false;
    public void Awake()
    {
        cameraCanvas.SetActive(true);
        panelAnimator.Play("CameraCap_fadeOut");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (lilyCandleOnStart)
        {
            lilyAnim.SetLayerWeight(1, 1f);
        }
    }

    private void Update()
    {
        if (leonReady && lilyReady)
            StartCoroutine(loadNextSceneIE(nextSceneIndex));

        if (leonFinal && lilyFinal) final.SetActive(true);
    }

    public void simpleLoadScene(int i)
    {
        SceneManager.LoadScene(i);
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
        goSfx.Play();
        yield return new WaitForSeconds(3);
        gameOverAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        panelAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        gameOverAnimator.Play("CameraCap_fadeOut");
        yield return new WaitForSeconds(6);
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
