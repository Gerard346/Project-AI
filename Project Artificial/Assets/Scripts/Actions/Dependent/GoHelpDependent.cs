using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoHelpDependent : ActionTask
{
    DependentController dependent_controller = null;
    PathFinding pathfinding = null;

    protected override void OnExecute()
    {
        dependent_controller = agent.GetComponent<DependentController>();
        pathfinding = agent.GetComponent<PathFinding>();

        if (dependent_controller.GetClient() == null) EndAction(true);

        pathfinding.SetTarget(dependent_controller.GetClient().transform.position);

    }
    protected override void OnUpdate()
    {
        if(pathfinding.DistanceToTarget() < 1.0f)
        {
            pathfinding.ClearPath();
            EndAction(true);
        }
    }
}
