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
        dependent_controller.FixRotation();
    }
    protected override void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer > attend_time)
        {
            dependent_controller.FreeRotation();
            dependent_controller.GetClient().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
            EndAction(true);
        }
    }
}
