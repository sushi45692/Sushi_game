using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody rb;
    bool grounded = true;


    private int health = 100;

    float burger1attackspeed = 1f;
    float attacktimer = 0f;
    bool attacked = false;









    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 y = new Vector3(0f, rb.velocity.y, 0f);
        rb.velocity = (transform.forward * moveZ + transform.right * moveX).normalized * speed + y;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            grounded = false;
        }
if(attacked == true)
        {
            attacktimer += Time.deltaTime;
            if(attacktimer >= burger1attackspeed)
            {
                attacktimer = 0;
                attacked = false;
            }

        }

        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        }*/





    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="ground") {
            grounded = true;
        }

        if (collision.gameObject.tag == "Burger" && attacktimer == 0)
        {
            health -= 15;
            attacked = true;
        }



        if(health <= 0) 
        {
            gameover();
        }
    }




    public void gameover()
    {
        Debug.Log("game over");
    }



}