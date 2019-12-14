using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoWorkDependent : ActionTask
{
    protected override void OnExecute()
    {
       agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Transform>("ObserverPoint").position);

    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.GetComponent<DependentController>().FixRotation();
            agent.GetComponent<Blackboard>().SetValue("IsWorking", true);
            EndAction(true);
        }

    }
}
