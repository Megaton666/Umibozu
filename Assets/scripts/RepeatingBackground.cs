using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;       
    private float verticalLength;       

    
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        verticalLength = groundCollider.size.y;
    }


    private void FixedUpdate()
    {
        if (transform.position.y < -verticalLength)
        {
            Reposition();
        }
    }

 
    private void Reposition()
    {
        Vector2 offSet = new Vector2(0, verticalLength * 2f);
        transform.position = (Vector2)transform.position + offSet;
    }
}
