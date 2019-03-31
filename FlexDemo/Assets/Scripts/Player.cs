using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class Player : MonoBehaviour
{
    public InputMaster controls;
    public float theshold = 0.25f;
    public float thrust = 20;
    float previousValue;
    float diff;
    Rigidbody rb;
    Vector3 origin;

    // Start is called before the first frame update
    void Awake()
    {
        previousValue = 0.0f;
        rb = GetComponent<Rigidbody>();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Reset.performed += ctx => Reset();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            Reset();
        }
    }

    void Move(float direction)
    {
        if(direction < 0)
        {
            // negative number
            direction = -1 - direction;
        }
        else if(direction > 0)
        {
            // positive number 
            direction = 1 - direction;
        }

        if(checkForFling(direction))
        {
            fling();
        }

    }

    bool checkForFling(float currentValue)
    {
        diff = currentValue - previousValue;
        previousValue = currentValue;

        if (diff >= theshold)
        {
            return true;
        }
        return false;
    }

    void fling()
    {
        Debug.Log("FLING");
        rb.AddForce((transform.up + transform.forward) * thrust);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(origin, new Quaternion(0, 0, 0, 0));
    }
}
