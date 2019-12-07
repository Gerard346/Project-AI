﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class GoToWorkCleaner : ActionTask
{
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        agent.gameObject.GetComponent<CleanerController>().cleaner_state = CleanerController.CLEANER_STATE.CLEANER_START_WORKING;
        agent.gameObject.GetComponent<CleanerController>().mop.SetActive(false);
        agent.gameObject.GetComponent<CleanerController>().follow_path.enabled = true;
        agent.gameObject.GetComponent<CleanerController>().follow_path.SetPath(agent.gameObject.GetComponent<CleanerController>().start_working_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<CleanerController>().cleaner_state == CleanerController.CLEANER_STATE.CLEANER_START_WORKING && agent.gameObject.GetComponent<CleanerController>().follow_path.path_completed)
        {
            EndAction(true);
        }
    }
}