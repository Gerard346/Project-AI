using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class CashierController : MonoBehaviour
{
    enum CASHIER_STATE
    {
        CASHIER_IDLE = 0,
        CASHIER_WALK_TO_WORK,
        CASHIER_WORKING,
        CASHIER_ATTENDING,
        CASHIER_GO_HOME
    };

    private float timer = 0.0f;
    public float attention_time = 3.0f;

    SteeringFollowPath follow_path = null;
    public BGCcMath walk_to_work_path;
    public BGCcMath go_home_path;

    public QueueController queue_controller = null;
    private ClientController client_on_attention = null;

    CASHIER_STATE cashier_state;

    // Start is called before the first frame update
    void Start()
    {
        //follow_path.enabled = true;
        //follow_path.SetPath(walk_to_work_path, false);
        cashier_state = CASHIER_STATE.CASHIER_WALK_TO_WORK;
    }

    // Update is called once per frame
    void Update()
    {
        if (cashier_state == CASHIER_STATE.CASHIER_WALK_TO_WORK)
        {
            cashier_state = CASHIER_STATE.CASHIER_WORKING;
        }
        if(cashier_state == CASHIER_STATE.CASHIER_ATTENDING)
        {
            timer += Time.deltaTime;
            if (timer > attention_time)
            {
                timer = 0;
                cashier_state = CASHIER_STATE.CASHIER_WORKING;
                queue_controller.ClientDone(client_on_attention);
            }
        }
        if (cashier_state == CASHIER_STATE.CASHIER_GO_HOME)
        {
            gameObject.SetActive(false);
        }
    }

    public void AttendClient(ClientController target_client)
    {
        if (cashier_state == CASHIER_STATE.CASHIER_WORKING)
        {
            timer = 0.0f;
            cashier_state = CASHIER_STATE.CASHIER_ATTENDING;
            client_on_attention = target_client;
            client_on_attention.client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUYING;
            //Client rot
            client_on_attention.FixRotation(client_on_attention.assigned_queue_point.localRotation.eulerAngles.y);
        }
        else
        {
            Debug.LogError("ERORRORO");
        }
    }
}
