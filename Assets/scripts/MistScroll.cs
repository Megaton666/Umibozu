using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistScroll : MonoBehaviour {

    void FixedUpdate () {
        Vector3 Position = transform.position;
        Position.x -= 0.03f;
        transform.position = Position;
    }
}
