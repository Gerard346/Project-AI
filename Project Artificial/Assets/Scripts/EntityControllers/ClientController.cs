using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
public class ClientController : MonoBehaviour
{
    public enum CLIENT_STATE
    {
        CLIENT_IDLE = 0,
        CLIENT_GO_PICK,
        CLIENT_WAINTING_FOR_HELP,
        CLIENT_GO_BUY,
        CLIENT_GO_BUYING,
        CLIENT_WAIT_BUYING,
        CLIENT_BUY_DONE,
        CLIENT_GO_KILL
    };

    public Vector3 pick_point;
    public Vector3 buy_point;
    public Vector3 kill_point;

    PathFinding pathfinding = null;
    SteeringAlign align = null;
    StaticAlign static_align = null;

    public Transform assigned_queue_point = null;

    CLIENT_STATE _client_state = CLIENT_STATE.CLIENT_IDLE;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = GetComponent<PathFinding>();
        align = GetComponent<SteeringAlign>();
        static_align = GetComponent<StaticAlign>();

        pathfinding.SetTarget(pick_point);
        client_state = CLIENT_STATE.CLIENT_GO_PICK;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Blackboard>().GetValue<bool>("StoreIsOpened") != References.data.day_cycle.store_is_open)
        {
            GetComponent<Blackboard>().SetValue("StoreIsOpened", References.data.day_cycle.store_is_open);
        }
    }
    public CLIENT_STATE client_state
    {
        get
        {
            return _client_state;
        }
        set
        {
            _client_state = value;
        }
    }

    public void SetTarget(Vector3 pos)
    {
        pathfinding.SetTarget(pos);
    }

    public void FixRotation(float angle)
    {
        align.enabled = false;
        static_align.enabled = true;
        static_align.target_angle = angle;
    }

    public void FreeRotation()
    {
        align.enabled = true;
        static_align.enabled = false;
    }
}
