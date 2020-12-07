using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public static float speed;
    public static bool isGameOver;
    Rigidbody rigid;
    Animator anim;
    bool isJump = true, isMoveLeft = true, isMoveRight = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        isGameOver = false;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;

        Boost();
        Move();
        Jump();
        Attack();
        Defend();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box" || collision.gameObject.tag == "Enemy")
        {
            isGameOver = true;
        }
        if(collision.gameObject.tag == "Ground")
            isJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isJump = false;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void Move2()
    {
        if (transform.position.x <= -3)
        {
            isMoveRight = true;
            isMoveLeft = false;
        }
        else if (transform.position.x >= 3)
        {
            isMoveLeft = true;
            isMoveRight = false;
        }
        else
        {
            isMoveLeft = true;
            isMoveRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && isMoveLeft)
        {
            transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);

        }

        if (Input.GetKeyDown(KeyCode.D) && isMoveRight)
        {
            transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);

        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.W) && !isJump)
        {
            speed = 15f;
        }
        else
        {
            speed = 10f;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isJump)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * 250);
            isJump = false;
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }

    void Defend()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Defend");
        }
    }
}
