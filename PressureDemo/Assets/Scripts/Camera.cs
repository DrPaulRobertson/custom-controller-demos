using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Camera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Move camera to keep aligned with player
    void Update()
    {
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }

}
