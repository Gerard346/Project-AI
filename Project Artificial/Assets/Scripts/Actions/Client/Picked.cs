using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class Picked : ActionTask
{
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<ClientController>().client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUY;
        blackboard.SetValue("Picked", true);
        EndAction(true);
    }

}
