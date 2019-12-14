using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class DependentController : MonoBehaviour
{
    private ClientController client = null;
    SteeringAlign align = null;
    StaticAlign static_align = null;
    void Start()
    {
        align = GetComponent<SteeringAlign>();
        static_align = GetComponent<StaticAlign>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelpClient(ClientController new_client)
    {
        GetComponent<Blackboard>().SetValue("Selected", true);
        client = new_client;
    }
    public ClientController GetClient()
    {
        return client;
    }

    public void FixRotation()
    {
        FixRotationWithAngle(GetComponent<Blackboard>().GetValue<Transform>("ObserverPoint").localRotation.eulerAngles.y);
    }

    private void FixRotationWithAngle(float angle)
    {
        align.enabled = false;
        static_align.enabled = true;
        static_align.target_angle = angle;
    }

    public void FreeRotation()
    {
        align.enabled = true;
        static_align.enabled = false;
    }
}
