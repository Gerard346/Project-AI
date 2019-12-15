using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoWorkDependent : ActionTask
{
    protected override void OnExecute()
    {
       agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Transform>("ObserverPoint").position);
        References.data.entites_selection.ResetSelection();
    }
    protected override void OnUpdate()
    {
        if (References.data.entites_selection.GetSelection())
        {
            agent.GetComponent<Blackboard>().SetValue("IsWorking", true);
            References.data.day_cycle.NotifyReadyWorker();

            EndAction(true);
        }
        else if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.GetComponent<DependentController>().FixRotation();
            agent.GetComponent<Blackboard>().SetValue("IsWorking", true);
            References.data.day_cycle.NotifyReadyWorker();

            EndAction(true);
        }
        

    }
}
