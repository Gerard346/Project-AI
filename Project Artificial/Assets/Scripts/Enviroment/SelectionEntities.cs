using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEntities : MonoBehaviour
{
    GameObject selection;
    public LayerMask layer;
    GameObject selected;
    void Start()
    {
        
    }
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f, layer))
        {
            selection = hit.collider.gameObject;
            selection = selection.transform.parent.gameObject;

            if (Input.GetMouseButtonDown(0))
            {
                selected.transform.Find("circle_selected").gameObject.SetActive(false);

                selected = selection;
                if (selection != null)
                {
                    Debug.Log(selection.name);
                    if(selection.gameObject.tag == "dependent")
                    {
                        selected.transform.Find("circle_selected").gameObject.SetActive(true);
                    }
                }

            }
        }
    }
}
