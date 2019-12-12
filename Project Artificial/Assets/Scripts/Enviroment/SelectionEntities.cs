using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEntities : MonoBehaviour
{

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.collider.gameObject;
            // var gameobject_selected = selection.GetComponent<GameObject>();
            if (Input.GetMouseButtonDown(0))
            {
                if (selection != null)
                {
                    Debug.Log(selection.name);
                }
            }
        }
    }
}
