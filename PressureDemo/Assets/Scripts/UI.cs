using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        guiStyle.fontSize = 24; //change the font size
        guiStyle.alignment = TextAnchor.MiddleLeft;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 40), "Press R to Reset", guiStyle);
    }
}
