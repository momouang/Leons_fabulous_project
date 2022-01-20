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
    public bool hideCCanvasOnStart = false;

    int currentSceneIndex;
    public int nextSceneIndex = 0;
    public bool lilyCandleOnStart;
    public bool leonReady = false, lilyReady = false, leonFinal = false, lilyFinal = false;
    public void Awake()
    {
        //if(!hideCCanvasOnStart)cameraCanvas.SetActive(true);
        if(panelAnimator!=null)
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

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
        }

        else if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(2);
        }

        else if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(3);
        }

        //112 25, 190 -53

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

    public void loadNextSceneIEStarter()
    {
        StartCoroutine(loadNextSceneIE(nextSceneIndex));
    }

    IEnumerator loadNextSceneIE(int i)
    {
        yield return new WaitForSeconds(2);
        panelAnimator.Play("CameraCap_fadeBlack");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(i);
    }
}
