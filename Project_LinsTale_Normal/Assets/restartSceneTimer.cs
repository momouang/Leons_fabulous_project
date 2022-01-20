using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartSceneTimer : MonoBehaviour
{
    public float timeLimit = 90f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(counter());
    }

    // Update is called once per frame
    IEnumerator counter()
    {
        yield return new WaitForSeconds(timeLimit);
        SceneManager.LoadScene(0);
    }
}
