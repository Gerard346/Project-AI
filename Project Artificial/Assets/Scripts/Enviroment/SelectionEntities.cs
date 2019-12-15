using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEntities : MonoBehaviour
{
    GameObject selection;
    public LayerMask layer;
    GameObject dependent_selected;
    GameObject client_selected;

    public void ResetSelection()
    {
        if (dependent_selected != null)
        {
            dependent_selected.transform.Find("circle_selected").gameObject.SetActive(false);
            dependent_selected = null;
        }

        if (client_selected != null)
        {
            client_selected.transform.Find("circle_selected").gameObject.SetActive(false);
            client_selected = null;
        }
        enabled = true;
    }
    public bool GetSelection()
    {
        return client_selected != null && dependent_selected != null;
    }
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f, layer))
        {
            selection = hit.collider.gameObject;

            if (Input.GetMouseButtonDown(0) && selection != null)
            {
                if(selection.gameObject.tag == "dependent")
                {
                    if (dependent_selected != null)
                    {
                        dependent_selected.transform.Find("circle_selected").gameObject.SetActive(false);

                        if (selection == dependent_selected)
                        { 
                            dependent_selected = null;
                        }
                        else
                        {
                            dependent_selected = selection;
                            dependent_selected.transform.Find("circle_selected").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        dependent_selected = selection;
                        dependent_selected.transform.Find("circle_selected").gameObject.SetActive(true);

                        if (client_selected != null)
                        {
                            dependent_selected.GetComponentInChildren<DependentController>().HelpClient(client_selected.GetComponentInChildren<ClientController>());
                            enabled = false;
                        }
                    }
                }
                if(selection.gameObject.tag == "Client")
                {
                    if (client_selected != null)
                    {
                        client_selected.transform.Find("circle_selected").gameObject.SetActive(false);

                        if (selection == client_selected)
                        {
                            client_selected = null;
                        }
                        else
                        {
                            client_selected = selection;
                            client_selected.transform.Find("circle_selected").gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        client_selected = selection;
                        client_selected.transform.Find("circle_selected").gameObject.SetActive(true);

                        if (dependent_selected != null)
                        {
                            dependent_selected.GetComponentInChildren<DependentController>().HelpClient(client_selected.GetComponentInChildren<ClientController>());
                            enabled = false;
                        }
                    }
                }
            }
        }
    }
}
