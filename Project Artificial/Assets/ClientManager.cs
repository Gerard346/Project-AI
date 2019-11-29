using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public GameObject client_container = null;

    public Transform spawn_points;
    public Transform pick_point;
    public Transform buy_point;
    public Transform kill_point;

    public int client_prefabs = 0;

    float timer = 0.0f;

    public float spawn_rate = 5.0f;
    public int client_limit = 20;
    public DayCycle day_cycle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       /* if (day_cycle.store_is_open == true)
        {
            if (timer > spawn_rate)
            {*/
                timer = 0.0f;
                if (client_container.transform.childCount >= client_limit)
                {

                }
                else
                {
                    int client_index = Random.Range(0, client_prefabs);
                    GameObject client_prefab = Resources.Load<GameObject>("Clients/Client" + client_index);

                    Vector3 spawn_point = spawn_points.GetChild(Random.Range(0, spawn_points.childCount)).position;
                    Vector3 target_pick_point = pick_point.GetChild(Random.Range(0, pick_point.childCount)).position;
                    Vector3 target_kill_point = kill_point.GetChild(Random.Range(0, kill_point.childCount)).position;

                    GameObject new_client = Instantiate(client_prefab);

                    new_client.transform.parent = client_container.transform;

                    new_client.transform.position = spawn_point;

                    new_client.GetComponent<ClientController>().buy_point = buy_point.position;
                    new_client.GetComponent<ClientController>().pick_point = target_pick_point;
                    new_client.GetComponent<ClientController>().kill_point = target_kill_point;
                }
            //}
        //}
    }
}
