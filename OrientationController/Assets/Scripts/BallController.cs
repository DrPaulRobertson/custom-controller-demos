using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    OrientationController controller;
    public float speed = 1.0f;
    GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        // Store starting position as default/reset position.
        origin = new GameObject();
        origin.transform.SetPositionAndRotation(transform.position, transform.rotation);

        controller = new OrientationController("COM5");
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

    // Apply force based on sensor data, to push the player/ball around
    void FixedUpdate()
    {
        Vector3 gravity = controller.getGravityVector();
        GetComponent<Rigidbody>().AddForce(new Vector3(-gravity.y, 0, gravity.x) * speed);
    }

    // Reset position and velocity of the player
    void Reset()
    {
        transform.SetPositionAndRotation(origin.transform.position, origin.transform.rotation);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
