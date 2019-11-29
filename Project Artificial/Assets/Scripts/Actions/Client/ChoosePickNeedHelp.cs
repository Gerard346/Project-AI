using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class ChoosePickNeedHelp : ActionTask
{
    // Start is called before the first frame update
    protected override string OnInit()
    {
        return null;
    }
    protected override void OnExecute()
    {
        int i = Random.Range(0, 100);

        if (i > 80)
        {
            blackboard.SetValue("NeedHelp", true);
            blackboard.SetValue("Picked", false);
        }
        else
        {
            blackboard.SetValue("NeedHelp", false);
            blackboard.SetValue("Picked", true);
        }

        EndAction(true);
    }
}
