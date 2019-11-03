using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    Animator c_animator;
    Canvas ui;
    Text points;
    int random;

    void Start()
    {
        c_animator = gameObject.GetComponentInParent<Animator>();
        ui = gameObject.GetComponentInChildren<Canvas>();
        points = ui.gameObject.GetComponentInChildren<Text>();
        ui.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            c_animator.SetTrigger("CustomerClose");
            ui.gameObject.SetActive(true);
            random = Random.Range(1, 99);
            points.text = "+" + random;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            c_animator.SetTrigger("CustomerClose");
    }
    void OnTriggerExit(Collider other)
    {
        //UI coins
        if (other.gameObject.CompareTag("Player"))
            ui.gameObject.SetActive(false);
    }
}
