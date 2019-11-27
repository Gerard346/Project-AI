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
    bool collided = false;
    bool bought = false;

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

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true; 
            yield return new WaitForSeconds(4); 
            if (collided == true) 
            {
                //c_animator.SetTrigger("CustomerClose");
                random = Random.Range(1, 99);
                points.text = "+" + random;
                ui.gameObject.SetActive(true);
                bought = true;
            }
            
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
            collided = false;
            if (bought == true)
            {
                ui.gameObject.SetActive(false);
                cash.Play();
                bought = false;
            }
        }

    }
}
