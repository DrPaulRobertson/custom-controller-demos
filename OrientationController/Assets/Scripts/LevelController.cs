using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    OrientationController controller;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = new OrientationController();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rotate = controller.getOrientation().eulerAngles;
        rotate.y = 0;
        transform.rotation = Quaternion.Euler(rotate);
        Quaternion to = Quaternion.Euler(rotate);
        transform.rotation = Quaternion.Lerp(transform.rotation, to, 0.2f);
    }
}
