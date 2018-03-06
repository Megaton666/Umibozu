using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursor : MonoBehaviour {

    public Texture2D menuCursor;
	void Start ()
    {
        Cursor.visible = true;
        Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
	

	void OnEnable ()
    {
        Cursor.visible = true;
        Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
