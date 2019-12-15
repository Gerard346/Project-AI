using NodeCanvas.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
public class GoToQueue : ActionTask
{
    float timer = 0.0f;
    float max_timer = 30.0f;

    Image idk_icon = null;
    Image happy_icon = null;

    protected override void OnExecute()
    {
        agent.gameObject.transform.Find("circle_selected").gameObject.SetActive(false);
        agent.gameObject.GetComponent<ClientController>().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
        References.data.queue_controller.ClientIn(agent.gameObject.GetComponent<ClientController>());
        happy_icon = agent.transform.Find("Canvas").Find("happy_img").GetComponent<Image>();
        happy_icon.enabled = true;
        idk_icon = agent.transform.Find("Canvas").Find("idk_img").GetComponent<Image>();
        idk_icon.enabled = false;
    }
    protected override void OnUpdate()
    {
        if (blackboard.GetValue<bool>("OutOfTime"))
        {
            EndAction(true);
        }

        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            if (References.data.queue_controller.ClientOnPoint(agent.gameObject.GetComponent<ClientController>()))
            {
                EndAction(true);
            }
        }
    }
}
