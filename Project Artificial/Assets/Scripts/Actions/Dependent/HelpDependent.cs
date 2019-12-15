using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NodeCanvas.Framework;
public class HelpDependent : ActionTask
{
    // Start is called before the first frame update
    float timer = 0.0f;
    float attend_time = 10.0f;
    Image watch_image = null;

    DependentController dependent_controller;
    protected override void OnExecute()
    {
        //Watch

        dependent_controller = agent.GetComponent<DependentController>();
        dependent_controller.GetClient().GetComponent<Blackboard>().SetValue("GettingHelp", true);
        dependent_controller.FixRotation();
        watch_image = agent.transform.Find("Canvas").Find("watch_image").GetComponent<Image>();

    }
    protected override void OnUpdate()
    {
        float watch_value = timer / attend_time;
        watch_image.fillAmount = watch_value;

        timer += Time.deltaTime;

        if (timer > attend_time)
        {
            dependent_controller.FreeRotation();
            dependent_controller.GetClient().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
            blackboard.SetValue("Selected", false);
            EndAction(true);
        }
    }
}
