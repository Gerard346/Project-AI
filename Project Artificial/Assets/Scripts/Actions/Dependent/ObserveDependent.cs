using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class ObserveDependent : ActionTask
{
   protected override void OnExecute()
    {

    }

    protected override void OnUpdate()
    {
        if (blackboard.GetValue<bool>("Selected"))
        {
            EndAction(true);
        }
    }

}
