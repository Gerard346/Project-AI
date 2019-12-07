using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoWorkCashier : ActionTask
{
    // Start is called before the first frame update
    private CashierController controller;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        controller = agent.gameObject.GetComponent<CashierController>();
        controller.cashier_state = CashierController.CASHIER_STATE.CASHIER_WALK_TO_WORK;
        controller.follow_path.SetPath(controller.walk_to_work_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (controller.cashier_state == CashierController.CASHIER_STATE.CASHIER_WALK_TO_WORK && controller.follow_path.path_completed)
        {
            controller.cashier_state = CashierController.CASHIER_STATE.CASHIER_WORKING;
            controller.FixRotation();
            EndAction(true);
        }

    }
}
