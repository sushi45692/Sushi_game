using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camra : MonoBehaviour
{
    public float roationX = 0f;
    float roationY = 0f;
    public float sensitivity;
    public GameObject playerbody;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        roationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        roationY += Input.GetAxis("Mouse X") * sensitivity;

        //roationY = Mathf.Clamp (roationY,  -60, 60);
        roationX = Mathf.Clamp (roationX,  -60, 60); 

        transform.localEulerAngles = new Vector3(roationX, roationY, 0);

        Vector3 RotateBody = new Vector3(0,  roationY, 0);
        playerbody.transform.Rotate(RotateBody * Time.deltaTime, Space.World);
    }
}
