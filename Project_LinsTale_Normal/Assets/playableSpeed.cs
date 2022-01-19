using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playableSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public float playSpeed = 1f;

    void Start()
    {
        GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).SetSpeed(playSpeed);
    }

}
