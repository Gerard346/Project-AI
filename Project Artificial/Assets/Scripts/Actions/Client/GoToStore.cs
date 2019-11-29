using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GoToStore : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        blackboard.SetValue("SpawnPos", agent.gameObject.transform.position);

        agent.gameObject.GetComponent<PathFinding>().SetTarget(agent.gameObject.GetComponent<ClientController>().pick_point);

    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            EndAction(true);
        }
      
    }
}
