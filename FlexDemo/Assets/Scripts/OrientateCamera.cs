using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class OrientateCamera : MonoBehaviour
{
    public InputMaster controls;
    public GameObject target;
    public float rotateSpeed = 0.5f;
    GameObject emptyGO;
    Vector3 offset;

    private void Awake()
    {
        controls.Camera.MouseMove.performed += ctx => Move(ctx.ReadValue<float>());
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        emptyGO = new GameObject();
        emptyGO.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    void Move(float v)
    {
        Debug.Log("MouseMove");
        target.transform.Rotate(0, v, 0);
    }

    void Update()
    {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        Debug.Log("Mouse position: " + mouse.position.x);

        float mouseX = mouse.delta.x.ReadValue() * rotateSpeed;
        float mouseY = mouse.delta.y.ReadValue() * rotateSpeed;
        target.transform.Rotate(0, mouseX, 0);
        
        emptyGO.transform.Rotate(mouseY, 0, 0);
       
        float desiredAngle = target.transform.eulerAngles.y;
        float desiredAngleX = emptyGO.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredAngleX, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);

        transform.LookAt(target.transform);
    }

}
