using UnityEngine;
using NodeCanvas.Framework;
using System.Collections.Generic;
public class ClientManager : MonoBehaviour
{
    public GameObject client_container = null;

    public Transform scene_spawns_container = null;

    public List<Vector3> spawn_points;
    public Transform pick_point;
    public Transform buy_point;
    public Transform kill_point;

    public int client_prefabs = 0;

    float timer = 0.0f;

    public DayCycle day_cycle;

    public QueueController queue_controller;

    private void Start()
    {
        Transform[] scene_spawns = scene_spawns_container.GetComponentsInChildren<Transform>();
        foreach(Transform scene_spawn in scene_spawns)
        {
            spawn_points.Add(scene_spawn.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       /* if (day_cycle.store_is_open == true)
        {*/
        foreach(Vector3 spawn_point_item in spawn_points)
        {
            int client_index = Random.Range(0, client_prefabs);
            GameObject client_prefab = Resources.Load<GameObject>("Clients/Client" + client_index);

            Vector3 spawn_point = spawn_point_item;
            Vector3 target_pick_point = pick_point.GetChild(Random.Range(0, pick_point.childCount)).position;
            Vector3 target_kill_point = spawn_point_item;

            GameObject new_client = Instantiate(client_prefab);

            new_client.GetComponent<Blackboard>().SetValue("myQueueController", queue_controller);

            new_client.transform.parent = client_container.transform;

            new_client.GetComponent<Blackboard>().SetValue("SpawnPos", spawn_point);
            new_client.transform.position = spawn_point;

            new_client.GetComponent<ClientController>().buy_point = buy_point.position;
            new_client.GetComponent<ClientController>().pick_point = target_pick_point;
            new_client.GetComponent<ClientController>().kill_point = target_kill_point;

            spawn_points.Remove(spawn_point_item);

            break;
        }
            //}
        //}
    }
}
