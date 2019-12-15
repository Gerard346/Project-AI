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
        int i = Random.Range(60, 80);

        if (i > 51)
        {
            //blackboard.SetValue("NeedHelp", true);
            //blackboard.SetValue("Picked", false);
            blackboard.SetValue("NeedHelp", false);
            blackboard.SetValue("Picked", true);
        }
        else
        {
            blackboard.SetValue("NeedHelp", true);
            blackboard.SetValue("Picked", false);
        }

        EndAction(true);
    }
}
