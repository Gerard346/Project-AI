using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGO : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    Ray ray;
    RaycastHit hit;
    public static bool cashier1_active = false;
    public static bool cashier2_active = false;

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
                if ((hit.point.x < 21 && hit.point.x > 17) && (hit.point.y < -1 && hit.point.y > -3) && (hit.point.z < -6.2 && hit.point.z > -7.5) && cashier1_active == false)
                {
                    //TODO
                    //set active false X 

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                        cashier1_active = true;
                    }
                }
                else if ((hit.point.x < 21 && hit.point.x > 17.5) && (hit.point.y < -1 && hit.point.y > -3) && (hit.point.z < 14.3 && hit.point.z > 13.2) && cashier2_active == false)
                {
                    //TODO
                    //set active false X

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                        cashier2_active = true;
                    }
                }
                else
                {
                    //TODO
                    //set active true X
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if ((hit.point.x < 45) && (hit.point.y < -1 && hit.point.y > -3) && (hit.point.z < 26 && hit.point.z > -45))
                {
                    //TODO
                    //set active true X
                }
                else
                {
                    //TODO
                    //set active false X
                    //separation between cars 
                    //(change prefab)

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab2, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }

}
