using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressedHandler : MonoBehaviour
{
    public KeyCode keyLeon;
    public KeyCode keyLily;
    private Button _button;

    void Awake() {
        _button = GetComponent<Button>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyLeon) || Input.GetKeyDown(keyLily)) {
            //click the button
            _button.onClick.Invoke();
        }
    }

    
}
