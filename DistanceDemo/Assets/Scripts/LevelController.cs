using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    private GameObject[] missiles;
    private int score = 0;
    private GUIStyle guiStyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        guiStyle.fontSize = 32; //change the font size
        guiStyle.alignment = TextAnchor.MiddleCenter;
    }


    public void Reset()
    {
        missiles = GameObject.FindGameObjectsWithTag("Missile");
        foreach(GameObject go in missiles)
        {
            Destroy(go);
        }
        score = 0;
    }

    void OnGUI()
    {
        GUI.Label(new Rect((Screen.width/2)-100, 10, 200, 40), "Score: " + score.ToString(), guiStyle);
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Destroy(other);
    }
}
