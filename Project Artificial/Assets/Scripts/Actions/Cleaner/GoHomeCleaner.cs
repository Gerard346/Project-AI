using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoHomeCleaner : ActionTask
{
    private CleanerController controller;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        controller = agent.gameObject.GetComponent<CleanerController>();
        controller.cleaner_state = CleanerController.CLEANER_STATE.CLEANER_END_WOKING;
        controller.mop.SetActive(false);
        controller.follow_path.SetPath(agent.gameObject.GetComponent<CleanerController>().end_working_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (controller.cleaner_state == CleanerController.CLEANER_STATE.CLEANER_END_WOKING && controller.follow_path.path_completed)
        {
            //DESTROY
            EndAction(true);
        }
    }
}
