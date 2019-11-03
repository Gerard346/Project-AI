using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    //Animator c_animator;
    Canvas ui;
    Text points;
    int random;
    AudioSource cash;

    void Start()
    {
        //c_animator = gameObject.GetComponentInParent<Animator>();
        ui = gameObject.GetComponentInChildren<Canvas>();
        points = ui.gameObject.GetComponentInChildren<Text>();
        ui.gameObject.SetActive(false);
        cash = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           //c_animator.SetTrigger("CustomerClose");
            random = Random.Range(1, 99);
            points.text = "+" + random;
            ui.gameObject.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
           // c_animator.SetTrigger("CustomerClose");
    }
    void OnTriggerExit(Collider other)
    {
        //UI coins
        if (other.gameObject.CompareTag("Player"))
        {
            ui.gameObject.SetActive(false);
            cash.Play();
        }

    }
}
