﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGO : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                //if(hit.collider.name == "GameController")
                if (Input.GetMouseButtonDown(0))
                {
                    //Instantiate(prefab, new Vector3(hit.point.x, -2, hit.point.z), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                    Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                    //GameObject obj = Instantiate(prefab, new Vector3(20, -2, 13), Quaternion.AngleAxis(180, new Vector3(0, 1, 0))) as GameObject;
                    //GameObject obj = Instantiate(prefab, new Vector3(20, -2, -6)), Quaternion.AngleAxis(180, new Vector3(0, 1, 0))) as GameObject;
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                //if(hit.collider.name == "GameController")
                if (Input.GetMouseButtonDown(0))
                {
                    //Instantiate(prefab, new Vector3(hit.point.x, -2, hit.point.z), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                    Instantiate(prefab2, hit.point, Quaternion.identity);
                    //GameObject obj = Instantiate(prefab, new Vector3(20, -2, 13), Quaternion.AngleAxis(180, new Vector3(0, 1, 0))) as GameObject;
                    //GameObject obj = Instantiate(prefab, new Vector3(20, -2, -6)), Quaternion.AngleAxis(180, new Vector3(0, 1, 0))) as GameObject;
                }
            }
        }
    }

}
