using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawn : MonoBehaviour
{
    public GameObject missile;
    public float maxSpawnHeight = 5;
    public float minSpawnHeight = -5;
    public float fireDelay = 6.0f;
    private float elapsedTime;
    public float speed = 200.0f;
    

    void Start()
    {
        elapsedTime = 0.0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > fireDelay)
        {
            elapsedTime = 0.0f;
            //Debug.Log("Missile Fired");
            // fire
            Vector3 pos = new Vector3(0, Random.Range(minSpawnHeight, maxSpawnHeight), 0);

            GameObject temp = Instantiate(missile, transform.position + pos, transform.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.up * speed);
            Destroy(temp, 15);

        }
    }
}
