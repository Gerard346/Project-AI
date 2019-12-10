using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoor : MonoBehaviour
{
    public float angle;
    public float speed;
    public Vector3 direction;
    public float ret;
    public Vector3 start_rotation;
    void Start()
    {
        start_rotation = this.transform.rotation.eulerAngles;
        angle = start_rotation.y;
    }
    void Update()
    {
        ret = Mathf.Round(transform.eulerAngles.y);
      
        if(Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed);
        }
    }
    void OnTriggersEnter(Collider other)
    {
        if (other.gameObject.tag == "Cleaner")
        {
            angle = start_rotation.y - 90;
            direction = Vector3.down;
        }
    }
    void OnTriggersExit(Collider other) {
        if (other.gameObject.tag == "Cleaner")
        {
            angle = start_rotation.y;
            direction = -Vector3.down;
        }
    }
}
