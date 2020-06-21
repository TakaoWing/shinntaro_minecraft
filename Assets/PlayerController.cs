using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    public Rigidbody rb;
    float move_x;

    float move_z;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerTransform = transform.parent;
            CameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        move_x = 0f;

        move_z = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            move_x += speed;

        }

        if (Input.GetKey(KeyCode.A))
        {
            move_x -= speed;

        }

        if (Input.GetKey(KeyCode.W))
        {
            move_z += speed;
           

        }

        if (Input.GetKey(KeyCode.S))
        {
            move_z -= speed;

        }
        //rb.AddForce(move_x, 0, move_z);
        transform.Translate(move_x, 0, move_z);
    }
}
