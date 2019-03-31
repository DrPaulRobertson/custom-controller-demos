using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 0.5f;
    GameObject emptyGO;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        emptyGO = new GameObject();
        emptyGO.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        
        emptyGO.transform.Rotate(mouseY, mouseX, 0);
        
        float desiredAngle = emptyGO.transform.eulerAngles.y;
        float desiredAngleX = emptyGO.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredAngleX, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);

        transform.LookAt(target.transform);
    }
}
