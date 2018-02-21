using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {



    void FixedUpdate()
    {
        Vector3 Position = transform.position;
        Position.y -= 0.01f;
        transform.position = Position;
    }
}
