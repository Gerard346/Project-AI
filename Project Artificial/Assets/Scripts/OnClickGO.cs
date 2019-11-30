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

    public Vector3 center_cash1;
    public Vector3 size_cash1;

    public Vector3 center_cash2;
    public Vector3 size_cash2;

    public Vector3 center_park;
    public Vector3 size_park;

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
                if (isInside(center_cash1, size_cash1, hit.point) && cashier1_active == false)
                {

                    red_x.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab, hit.point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                        cashier1_active = true;
                    }
                }
                else if (isInside(center_cash2, size_cash2, hit.point) && cashier2_active == false)
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
                if (isInside(center_park, size_park, hit.point) || hit.collider.tag != "Untagged")
                {
                    red_x.transform.position = Input.mousePosition;
                    red_x.gameObject.SetActive(true);
                }
                else
                {
                    red_x.gameObject.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(prefab2, hit.point, Quaternion.AngleAxis(-90, new Vector3(1, 0, 0)));
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center_cash1, size_cash1);
        Gizmos.DrawCube(center_cash2, size_cash2);
        Gizmos.DrawCube(center_park, size_park);
    }

    bool isInside(Vector3 center, Vector3 size, Vector3 positionRay)
    {
        if((center.x + (size.x / 2)) > positionRay.x && positionRay.x > (center.x - (size.x / 2)) && (center.y + (size.y / 2)) > positionRay.y && positionRay.y > (center.y - (size.y / 2)) && (center.z + (size.z / 2)) > positionRay.z && positionRay.z > (center.z - (size.z / 2)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
