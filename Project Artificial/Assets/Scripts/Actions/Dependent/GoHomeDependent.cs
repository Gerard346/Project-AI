using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoHomeDependent : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Vector3>("SpawnPos"));
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.gameObject.SetActive(false);

            GameObject.Destroy(agent.gameObject);
        }
    }
}
