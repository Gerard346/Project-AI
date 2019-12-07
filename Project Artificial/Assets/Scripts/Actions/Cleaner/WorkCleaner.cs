using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class WorkCleaner : ActionTask
{
    private CleanerController controller;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        controller = agent.gameObject.GetComponent<CleanerController>();
        controller.cleaner_state = CleanerController.CLEANER_STATE.CLEANER_WORKING;
        controller.mop.SetActive(true);
        controller.follow_path.SetPath(agent.gameObject.GetComponent<CleanerController>().working_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (controller.cleaner_state == CleanerController.CLEANER_STATE.CLEANER_WORKING && controller.follow_path.path_completed)
        {
            blackboard.SetValue("CleaningDone", true);
            EndAction(true);
        }
    }
}
