using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    Animator c_animator;

    void Start()
    {
        c_animator = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Player"))
            c_animator.SetTrigger("CustomerClose");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            c_animator.SetTrigger("CustomerClose");
    }
    void OnTriggerExit(Collider other)
    {
        //UI coins

    }
}
