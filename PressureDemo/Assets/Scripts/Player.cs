using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Player : MonoBehaviour
{
    public InputMaster controls;
    Rigidbody rb;
    Vector3 origin;

    // Thrusters for controlling movement
    public Transform leftThruster;
    public Transform rightThruster;
    public float thrustScale = 100.0f;
    Vector2 force;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls.Player.Right.performed += ctx => Right(ctx.ReadValue<float>());
        controls.Player.Left.performed += ctx => Left(ctx.ReadValue<float>());
        controls.Player.Reset.performed += ctx => Reset();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkForLevelOut();     
    }

    // Reset player if they travel to far from the level.
    void checkForLevelOut()
    {
        if (transform.position.y < -10)
        {
            Reset();
        }
        else if (transform.position.x < -25)
        {
            Reset();
        }
        else if (transform.position.x > 70)
        {
            Reset();
        }
    }

    // Applying forces to player game object.
    private void FixedUpdate()
    {
        rb.GetComponent<Rigidbody>().AddForceAtPosition(leftThruster.up * force.x * thrustScale, leftThruster.position);
        rb.GetComponent<Rigidbody>().AddForceAtPosition(rightThruster.up * force.y * thrustScale, rightThruster.position);
    }

    // On input change, update force values.
    void Right(float value)
    {  
         force.y = fixValue(value);
    }
    void Left(float value)
    {
        force.x = fixValue(value);
    }

    // Unity reads the values back-to-front, fix it.
    float fixValue(float value)
    {
        if (value < 0)
        {
            // negative number
            value = -1 - value;
        }
        else if (value > 0)
        {
            // positive number 
            value = 1 - value;
        }
        return value;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Reset player postition and rotation.
    void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(origin, new Quaternion(0, 0, 0, 0));
    }

    // Check for collision with end of level landing pad.
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name.Equals("Landing"))
        {
            if (Vector3.Dot(transform.up, Vector3.up) > 0.8f)
            {
                //safe landing
                Invoke("Reset", 2);
            }
        }
    }
}
