using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoToQueue : ActionTask
{
    float timer = 0.0f;
    float max_timer = 30.0f;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<ClientController>().client_state = ClientController.CLIENT_STATE.CLIENT_WAIT_BUYING;
        agent.gameObject.GetComponent<QueueController>().ClientIn(agent.gameObject.GetComponent<ClientController>());
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.gameObject.GetComponent<ClientController>().client_state = ClientController.CLIENT_STATE.CLIENT_WAIT_BUYING;
            if (agent.gameObject.GetComponent<QueueController>().ClientOnPoint(agent.gameObject.GetComponent<ClientController>()))
            {
                EndAction(true);
            }
        }

    }
}
