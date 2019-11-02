using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 5.0f;

    Vector3 initial_pos;

    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.x < (initial_pos.x + 15))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.z < (initial_pos.z + 10))
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.z > (initial_pos.z - 40))
            {
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.x > (initial_pos.x - 10))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = initial_pos;
        }
    }
}
