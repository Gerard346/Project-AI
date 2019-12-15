using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine.UI;
using NodeCanvas.Framework;

public class CashierController : MonoBehaviour
{
    public enum CASHIER_STATE
    {
        CASHIER_IDLE = 0,
        CASHIER_WALK_TO_WORK,
        CASHIER_WORKING,
        CASHIER_ATTENDING,
        CASHIER_GO_HOME
    };
    
    public int level = 1;
    
    private float attention_time = 10.0f;
    public float attend_time
    {
        get
        {
            return attention_time;
        }
    }

    public AudioSource cashier_sound;
    public SteeringFollowPath follow_path = null;
    public BGCcMath walk_to_work_path;
    public BGCcMath go_home_path;
    public Transform spawn_pos;
    SteeringAlign align = null;
    StaticAlign static_align = null;
    public ClientController client_on_attention = null;
    public GameObject orientation_pos;

    public GameObject lvl_2;
    public GameObject lvl_3;

    public CASHIER_STATE cashier_state;
    // Start is called before the first frame update
    void Start()
    {
        align = GetComponent<SteeringAlign>();
        static_align = GetComponent<StaticAlign>();
        follow_path = GetComponent<SteeringFollowPath>();
        cashier_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Blackboard>().GetValue<bool>("StoreIsOpened") != References.data.day_cycle.store_is_open)
        {
            GetComponent<Blackboard>().SetValue("StoreIsOpened", References.data.day_cycle.store_is_open);
        }
    }

    public void AttendClient(ClientController target_client)
    {
        if (cashier_state == CASHIER_STATE.CASHIER_WORKING)
        {
            cashier_state = CASHIER_STATE.CASHIER_ATTENDING;
            client_on_attention = target_client;
            client_on_attention.client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUYING;
        }
    }

    public void FixRotation()
    {
        FixRotationWithAngle(orientation_pos.transform.localRotation.eulerAngles.y);
        if (client_on_attention != null && client_on_attention.assigned_queue_point != null)
        {
            client_on_attention.FixRotation(client_on_attention.assigned_queue_point.localRotation.eulerAngles.y);
        }
    }

    private void FixRotationWithAngle(float angle)
    {
        static_align.target_angle = angle;
        align.enabled = false;
        static_align.enabled = true;
    }

    public void FreeRotation()
    {
        align.enabled = true;
        static_align.enabled = false;
    }

    public void levelUp(Button target_button)
    {
        if(level > 2)
        {
            target_button.interactable = false;
            return;
        }
        if(level == 1)
        {
            References.data.manager_money.AddMoney(-100);
            level += 1;
            lvl_2.SetActive(true);
            return;
        }

        if (level == 2)
        {
            References.data.manager_money.AddMoney(-100);

            level += 1;
            lvl_3.SetActive(true);
            return;
        }
    }
}
