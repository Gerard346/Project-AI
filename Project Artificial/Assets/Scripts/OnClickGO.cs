using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGO : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
            }
        }
    }
}
