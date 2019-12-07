using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GoToWorkCleaner : ActionTask
{
    private CleanerController controller;
    protected override void OnExecute()
    {
        controller = agent.gameObject.GetComponent<CleanerController>();
        controller.cleaner_state = CleanerController.CLEANER_STATE.CLEANER_START_WORKING;
        controller.mop.SetActive(false);
        controller.follow_path.enabled = true;
        controller.follow_path.SetPath(agent.gameObject.GetComponent<CleanerController>().start_working_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (controller.cleaner_state == CleanerController.CLEANER_STATE.CLEANER_START_WORKING && controller.follow_path.path_completed)
        {
            EndAction(true);
        }
    }
}
