using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {


    public Texture2D CursorTrans;
    public Texture2D CursorOpaque;
    public GameObject projectile;

    private int range;
    private Vector2 hotspot;
    private bool InRange;

	void Start () {
        hotspot = new Vector2(CursorOpaque.width / 2, CursorOpaque.height / 2);
        range = projectile.GetComponent<ProjectileMove>().range;
        Cursor.SetCursor(CursorOpaque, hotspot, CursorMode.Auto);
        InRange = true;
    }
	
	void FixedUpdate () {
        float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition),(transform.position));
        if (distance > range && InRange == true)
        {
            Cursor.SetCursor(CursorTrans, hotspot, CursorMode.Auto);
            InRange = false;
        }
        else if (distance <= range && InRange == false)
        {
            Cursor.SetCursor(CursorOpaque, hotspot, CursorMode.Auto);
            InRange = true;
        }
    } 
}
