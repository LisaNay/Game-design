using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip levelTheme;
    //public AudioClip mainTheme;

    void Start() {
        AudioManager.instance.PlayMusic (levelTheme);
    }

    // example
    /*
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            AudioManager.instance.PlayMusic (mainTheme, 3);
        }
    }
    */
}
