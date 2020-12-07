using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody rigid;
    public GameObject target;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y + 2f, target.transform.position.z), 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attack")
        {
            explode();
        }
    }

    void explode()
    {
        gameObject.SetActive(false);
        CreateGO();
    }

    void CreateGO()
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position;
        piece.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        piece.AddComponent<Rigidbody>();
    }
}
