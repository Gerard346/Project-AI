using UnityEngine;
using NodeCanvas.Framework;
using System.Collections.Generic;
using System.Collections;

public class ClientManager : MonoBehaviour
{
    public GameObject client_container = null;

    public Transform scene_spawns_container = null;

    private List<Vector3> spawn_points = new List<Vector3>();
    public Transform pick_point;
    public Transform buy_point;
    public Transform kill_point;

    public int client_prefabs = 0;

    float timer = 0.0f;

    public DayCycle day_cycle;

    public QueueController queue_controller;

    bool pending_spawns = false;

    private void Start()
    {
        Transform[] scene_spawns = scene_spawns_container.GetComponentsInChildren<Transform>(true);
        foreach(Transform scene_spawn in scene_spawns)
        {
            if (scene_spawn.gameObject == scene_spawns_container.gameObject) continue;

            spawn_points.Add(scene_spawn.position);
        }
    }

    void Update()
    {
        if(pending_spawns)
        {
            StartCoroutine(ClientsSpawnRoutine());
        }
        
    }

    private IEnumerator ClientsSpawnRoutine()
    {
        while (pending_spawns)
        {
            float rand_time = Random.Range(4.0f, 8.0f);
            yield return new WaitForSeconds(rand_time);
            SpawnClients();
        }
    }

    public void SpawnClients()
    {
        if(References.data.day_cycle.actual_time > 62000){
            return;
        }
        foreach (Vector3 spawn_point_item in spawn_points)
        {
            int client_index = Random.Range(0, client_prefabs);
            GameObject client_prefab = Resources.Load<GameObject>("Clients/Client" + client_index);

            Vector3 spawn_point = spawn_point_item;
            Vector3 target_pick_point = pick_point.GetChild(Random.Range(0, pick_point.childCount)).position;
            Vector3 target_kill_point = spawn_point_item;

            GameObject new_client = Instantiate(client_prefab);

            new_client.transform.parent = client_container.transform;

            new_client.GetComponent<Blackboard>().SetValue("SpawnPos", spawn_point);
            new_client.transform.position = spawn_point;
            new_client.GetComponent<Blackboard>().SetValue("StoreIsOpened", true);
            new_client.GetComponent<ClientController>().pick_point = target_pick_point;
            new_client.GetComponent<ClientController>().kill_point = target_kill_point;

            spawn_points.Remove(spawn_point_item);

            pending_spawns = spawn_points.Count > 0;

            break;
        }
    }
    public void AddPoints(Vector3 point)
    {
        spawn_points.Add(point);
    }
}
