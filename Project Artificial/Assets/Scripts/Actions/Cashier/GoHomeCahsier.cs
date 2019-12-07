using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class GoHomeCahsier : ActionTask
{
    private CashierController controller;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        controller = agent.gameObject.GetComponent<CashierController>();
        controller.cashier_state = CashierController.CASHIER_STATE.CASHIER_GO_HOME;
        controller.follow_path.SetPath(controller.go_home_path, false);
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        if (controller.cashier_state == CashierController.CASHIER_STATE.CASHIER_GO_HOME && controller.follow_path.path_completed)
        {
            EndAction(true);
        }

    }
}
