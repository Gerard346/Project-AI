using NodeCanvas.Framework;
using System;
using UnityEngine;

public class GoToQueue : ActionTask
{
    float timer = 0.0f;
    float max_timer = 30.0f;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<ClientController>().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
        References.data.queue_controller.ClientIn(agent.gameObject.GetComponent<ClientController>());
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            if (agent.gameObject.GetComponent<ClientController>().queue_controller.ClientOnPoint(agent.gameObject.GetComponent<ClientController>()))
            {
                EndAction(true);
            }
        }

        timer += Time.deltaTime;

        if(timer > max_timer)
        {
            blackboard.SetValue("OutOfTime", true);
            EndAction(true);
        }

    }
}
