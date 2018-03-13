using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgameMusic : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
