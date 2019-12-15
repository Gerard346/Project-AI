using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewParkingPlaces : MonoBehaviour
{
    Ray myRay;
    RaycastHit hit;
    public GameObject car;
    public LayerMask terrain;
    private LayerMask car_layer;
    private GameObject temp_car;
    private Renderer temp_car_render;
    Vector3 new_pos;
    bool spawned;
    void OnEnable()
    {
        temp_car = Instantiate(car, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        temp_car.layer = 9;
        car_layer = ~(terrain);
        temp_car.GetComponent<Collider>().enabled = false;
        temp_car_render = temp_car.GetComponent<Renderer>();
        spawned = false;
    }
    private void OnDisable()
    {
        if (temp_car != null)
        {
            Destroy(temp_car);
        }
    }
    void Update()
    {
        if (spawned)
        {
            this.GetComponent<CreateNewParkingPlaces>().enabled = false;
        }

        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        new_pos = new Vector3(hit.point.x, hit.point.y + (temp_car.GetComponent<Collider>().bounds.size.y / 2), hit.point.z);
        temp_car.transform.position = new_pos;
        if (Physics.Raycast(myRay, out hit, 100.0f, car_layer))
        {
            temp_car_render.material.SetColor("_Color", Color.red);
            return;
        }

        if (Physics.Raycast(myRay, out hit, 100.0f, terrain))
        {
            temp_car_render.material.SetColor("_Color", Color.green);
            if (Input.GetMouseButtonDown(0))
            {
                spawned = true;

                GameObject temp = Instantiate(car, hit.point, Quaternion.identity);
                temp.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                Vector3 temp_v = new Vector3(0, (temp.GetComponent<Collider>().bounds.size.y / 2), 0);
                temp.transform.position += temp_v;
                temp.GetComponents<BoxCollider>()[0].enabled = true;

                Vector3 new_spawn_point = temp.transform.Find("SpawnPoint").position;
                new_spawn_point.y = -2.01f;

                References.data.manager_client.AddPoints(new_spawn_point);
                if (References.data.day_cycle.ReadyWorkers())
                {
                    References.data.manager_client.SpawnClients();
                }
                References.data.manager_money.AddMoney(-100);
            }
        }

    }
}
