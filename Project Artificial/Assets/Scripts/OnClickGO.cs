using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickGO : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    Ray ray;
    RaycastHit hit;
    public static bool cashier1_active = false;
    public static bool cashier2_active = false;

    public RawImage red_x;

    // Start is called before the first frame update
    void Start()
    {
        red_x.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        red_x.gameObject.SetActive(false);
        if (Input.GetKey(KeyCode.Alpha1)) 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.point.x < 21 && hit.point.x > 17) && (hit.point.z < -6.2 && hit.point.z > -7.5) && cashier1_active == false)
                {

                    red_x.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                        cashier1_active = true;
                    }
                }
                else if ((hit.point.x < 21 && hit.point.x > 17.5) && (hit.point.z < 14.3 && hit.point.z > 13.2) && cashier2_active == false)
                {
                 
                    red_x.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                        cashier2_active = true;
                    }
                }
                else
                {
                    red_x.transform.position = Input.mousePosition;
                    red_x.gameObject.SetActive(true);
                }
            }
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if ((hit.point.x < 45) && (hit.point.z < 26 && hit.point.z > -45) || hit.collider.tag != "Untagged")
                {
                    red_x.transform.position = Input.mousePosition;
                    red_x.gameObject.SetActive(true);
                }
                else
                {
                    //TODO 
                    //(change prefab to a parking and add&edit box collider + change tag to it)

                    red_x.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab2, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }

}
