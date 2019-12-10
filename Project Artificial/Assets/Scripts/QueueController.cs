using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    public GameObject points_queue;
    private List<KeyValuePair<ClientController,int>> clients = null;
    private List<CashierController> cashiers = new List<CashierController>();
    private List<List<KeyValuePair<bool, Transform>>> queue_points;

    // Start is called before the first frame update
    void Start()
    {
        clients = new List<KeyValuePair<ClientController, int>>();
        queue_points = new List<List<KeyValuePair<bool, Transform>>>();

        AddQueuePoints(points_queue.transform);
    }

    void Update()
    {
        if(DayCycle.next_day)
        {
            cashiers.Clear();
            DayCycle.next_day = false;
        }
    }

    public void ClientIn(ClientController target)
    {
        if (target != null && target.client_state == ClientController.CLIENT_STATE.CLIENT_GO_BUY)
        {
            target.client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUYING;

            KeyValuePair<int, Transform> row_and_position = GetRandomQueuePoint();
            target.SetTarget(row_and_position.Value.position);
            target.assigned_queue_point = row_and_position.Value;
            target.queue_controller = this;

            clients.Add(new KeyValuePair<ClientController,int>(target, row_and_position.Key));
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        ClientController target = coll.GetComponentInParent<ClientController>();
        if (target != null && target.client_state == ClientController.CLIENT_STATE.CLIENT_GO_BUY)
        {
            target.client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUYING;

            KeyValuePair<int, Transform> row_and_position = GetRandomQueuePoint();
            target.SetTarget(row_and_position.Value.position);
            target.assigned_queue_point = row_and_position.Value;

            clients.Add(new KeyValuePair<ClientController, int>(target, row_and_position.Key));
        }
    }

    public bool ClientOnPoint(ClientController client)
    {
        if(client.assigned_queue_point.GetSiblingIndex() == 0)
        {
           for(int i = 0; i< clients.Count; i++)
            {
                if(clients[i].Key == client)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool AttendClient(ClientController client)
    {
        for (int i = 0; i < clients.Count; i++)
        {
            if (clients[i].Key == client)
            {
                cashiers[clients[i].Value].AttendClient(client);
                return true;
            }
        }
        return false;
    }

    public void ClientDone(ClientController client)
    {
        int target_row = 0;
        for(int i = 0; i< clients.Count; i++)
        {
            if(clients[i].Key == client)
            {
                FreeClientQueuePoint(client);
                target_row = clients[i].Value;
                client.client_state = ClientController.CLIENT_STATE.CLIENT_BUY_DONE;
                client.assigned_queue_point = null;
                client.queue_controller = null;
                client.FreeRotation();

                clients.RemoveAt(i);

                break;

            }
        }

        for (int x = 0; x < clients.Count; x++)
        {
            if (clients[x].Value == target_row)
            {
                Transform new_target_point = clients[x].Key.assigned_queue_point.parent.GetChild(clients[x].Key.assigned_queue_point.GetSiblingIndex() - 1);
                FreeClientQueuePoint(clients[x].Key);
                GetQueuePoint(clients[x].Key, new_target_point);
                clients[x].Key.client_state = ClientController.CLIENT_STATE.CLIENT_GO_BUYING;
                clients[x].Key.SetTarget(clients[x].Key.assigned_queue_point.position);
            }
        }

        client.client_state = ClientController.CLIENT_STATE.CLIENT_BUY_DONE;
    }

    private KeyValuePair<int, Transform> GetRandomQueuePoint()
    {
        int random_row = Random.Range(0, queue_points.Count);

        List<KeyValuePair<bool, Transform>> target_row = queue_points[random_row];
        for(int i = 0; i< target_row.Count; i++)
        {
            if(target_row[i].Key == true)
            {
                target_row[i] = new KeyValuePair<bool, Transform>(false, target_row[i].Value);
                
                return new KeyValuePair<int, Transform>(random_row, target_row[i].Value); 
            }
        }

        return new KeyValuePair<int, Transform>();
    }

    private void GetQueuePoint(ClientController client, Transform target_point)
    {
        for (int i = 0; i < queue_points.Count; i++)
        {
            List<KeyValuePair<bool, Transform>> row_points = queue_points[i];
            for (int x = 0; x < row_points.Count; x++)
            {
                if (row_points[x].Value == target_point)
                {
                    row_points[x] = new KeyValuePair<bool, Transform>(false, row_points[x].Value);
                    client.assigned_queue_point = row_points[x].Value;
                    break;
                }
            }
        }
    }

    private void FreeClientQueuePoint(ClientController client)
    {
        for(int i = 0; i < queue_points.Count; i++)
        {
            List<KeyValuePair<bool, Transform>> row_points = queue_points[i];
            for (int x = 0; x<row_points.Count;x++)
            {
                if(row_points[x].Value == client.assigned_queue_point)
                {
                    row_points[x] = new KeyValuePair<bool, Transform>(true, row_points[x].Value);
                    break;
                }
            }
        }
    }

    public void AddQueuePoints(Transform points)
    {
        List<KeyValuePair<bool, Transform>> points_list = new List<KeyValuePair<bool, Transform>>();
        
        Transform[] new_queue_points = points.GetComponentsInChildren<Transform>();
        
        foreach(Transform queue_point in new_queue_points)
        {
            if (queue_point == points.transform) continue;

            points_list.Add(new KeyValuePair<bool, Transform>(true, queue_point));
        }
        
        queue_points.Add(points_list);
    }
    public void AddCashier(CashierController cashier)
    {
        cashiers.Add(cashier);
    }
}
