using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int speed = 5;
    private Rigidbody rb;
    bool grounded = true;



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
    }








}