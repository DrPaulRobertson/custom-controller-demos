using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public InputMaster controls;

    public GameObject capture;
    public float minHeight = -1.0f;
    public float maxHeight = 1.0f;
    public float speed = 1.0f;
    float currentTime = 0f;
    Rigidbody rb;
    Vector3 destination;

    void Awake()
    {
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<float>());

        rb = GetComponent<Rigidbody>();
        destination = transform.position;
    }

    void Update()
    {
        currentTime = Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, destination, currentTime * speed);
    }

    void Move(float axisValue)
    {
        axisValue = fixValue(axisValue);
               
        float scale = maxHeight - minHeight;
        destination = new Vector3(transform.position.x, axisValue * scale, transform.position.z);
    }

    float fixValue(float axisValue)
    {
        if (axisValue < 0)
        {
            // negative number
            axisValue = -1 - axisValue;
        }
        else if (axisValue > 0)
        {
            // positive number 
            axisValue = 1 - axisValue;
        }
        return axisValue;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT2");
        capture.GetComponent<LevelController>().Reset();
    }
}
