using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GoToHome : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        blackboard.SetValue("SpawnPos", agent.gameObject.transform.position);

        agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Vector3>("SpawnPos"));

    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            if (blackboard.GetValue<bool>("Bought") == true)
            {
                agent.gameObject.SetActive(false);
            }
            if (blackboard.GetValue<bool>("StoreIsClosed") == true)
            {
                agent.gameObject.SetActive(false);
            }
            if (blackboard.GetValue<bool>("OutOfTime") == true)
            {
                agent.gameObject.SetActive(false);
            }
        }

    }
}
