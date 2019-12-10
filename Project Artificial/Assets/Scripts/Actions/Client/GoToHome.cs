using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GoToHome : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Vector3>("SpawnPos"));
        
        if (blackboard.GetValue<bool>("Bought") == true)
        {
            agent.gameObject.SetActive(true);
        }
        
        if (blackboard.GetValue<bool>("OutOfTime") == true)
        {
            agent.gameObject.SetActive(true);
        }
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.gameObject.SetActive(false);

            //References.data.manager_client.spawn_points.Add(blackboard.GetValue<Vector3>("SpawnPos"));

            GameObject.Destroy(agent.gameObject);
        }
    }
}
