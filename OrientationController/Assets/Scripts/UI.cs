using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject player;

    private GUIStyle guiStyle = new GUIStyle(); //create a new variable

    // Start is called before the first frame update
    void Start()
    {
        guiStyle.fontSize = 24; //change the font size
        //guiStyle.alignment = TextAnchor.MiddleLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 40), "Press R to Reset", guiStyle);
        Vector3 velo = player.GetComponent<Rigidbody>().velocity;
        GUI.Label(new Rect(10, 50, 200, 40), "Velocity: \n" + velo.x + ", \n" + velo.y + ", \n" + velo.z, guiStyle);
    }
}
