using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        // Store starting position as default/reset position.
        origin = new GameObject();
        origin.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // if R pressed reset, velocity and position;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        if (transform.position.y <= -10.0f)
        {
            // Probably gone over the edge
            Reset();
        }
    }

    // Reset position and velocity of the player
    void Reset()
    {
        transform.SetPositionAndRotation(origin.transform.position, origin.transform.rotation);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
