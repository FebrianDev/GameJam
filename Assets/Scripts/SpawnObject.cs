using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] box;
    float timer, delay = 0.5f;

    float posZ = 50f;
    int rand;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay)
        {
            rand = Random.Range(0, 3);
            Instantiate(box[rand], new Vector3(transform.position.x, transform.position.y, posZ), Quaternion.identity);
            posZ += 20f;
            timer = 0f;
        }
    }
}
