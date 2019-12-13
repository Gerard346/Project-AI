using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class HelpDependent : ActionTask
{
    // Start is called before the first frame update
    float timer = 0.0f;
    float attend_time = 10.0f;
    DependentController dependent_controller;
    protected override void OnExecute()
    {
        //Watch
        dependent_controller = agent.GetComponent<DependentController>();
        dependent_controller.GetClient().GetComponent<Blackboard>().SetValue("GettingHelp", true);
    }
    protected override void OnUpdate()
    {
        if(timer > attend_time)
        {
            dependent_controller.GetClient().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
        }
    }
}
