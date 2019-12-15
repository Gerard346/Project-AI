using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using NodeCanvas.Framework;

public class DayCycle : MonoBehaviour
{
    public float actual_time = 25000;
    public int days;
    public TimeSpan current_time;
    public TimeSpan current_day;

    public float speed;

    public Light sun;

    public Text time_ui;
    public Text day_ui;
    public Text coin_ui;
    private static int coins = 0;
    static public bool next_day = false;
    public bool time_to_clean = false;
    public bool store_is_open = false;
    public bool spawn_employees = true;
    float total_time_day = 24 * 60 * 60;
    bool day_has_passed = false;

    int workers_ready = 0;

    [Header("Entities")]
    public GameObject scene_entities = null;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        store_is_open = true;

        Blackboard[] entities_blackboard = scene_entities.GetComponentsInChildren<Blackboard>(true);
        foreach (Blackboard entity_blackboard in entities_blackboard)
        {
            entity_blackboard.SetValue("StoreIsOpened", true);
        }
        spawn_employees = true;
    }

    // Update is called once per frame
    void Update()
    {
        //DAY
        actual_time += Time.deltaTime * speed;

        if (actual_time > total_time_day)
        {
            workers_ready = 0;

            actual_time = 0;
            days += 1;
            day_has_passed = false;
            time_to_clean = true;
            next_day = true;
        }
        /*if (actual_time > (total_time_day / 3) && day_has_passed == false){
            spawn_employees = true;
            day_has_passed = true;
        }*/

        if(actual_time > total_time_day / 2.5)
        {
            store_is_open = true;

            Blackboard[] entities_blackboard = scene_entities.GetComponentsInChildren<Blackboard>(true);
            foreach(Blackboard entity_blackboard in entities_blackboard)
            {
                entity_blackboard.SetValue("StoreIsOpened", true);
            }

        }
        if (actual_time > 62000)
        {
            store_is_open = false;
        }

        if (actual_time < total_time_day/2)
        {
            sun.intensity = 1 - ((total_time_day / 2) - actual_time) / total_time_day / 2;

        }
        else
        {
            sun.intensity = 1 - (((total_time_day / 2) - actual_time) / total_time_day / 2 * -1);
        }

        sun.transform.rotation = Quaternion.Euler(new Vector3((actual_time - total_time_day / 4) / total_time_day * 360, 0, 0));

        //UI
        current_day = TimeSpan.FromDays(days);
        current_time = TimeSpan.FromSeconds(actual_time);

        string tempday = current_day.ToString();
        day_ui.text = "Days passed: " + tempday[0];

        string[] temptime = current_time.ToString().Split(":"[0]);
        time_ui.text = "Actual Time: " + temptime[0] + "h" + temptime[1] + "min";

        if (Trigger.needs_adding == true)
        {
            coins += Trigger.coin;
            Trigger.cash.Play();
            Trigger.needs_adding = false;
        }
        coin_ui.text = "Total Coins: " + coins;
    }

    public void NotifyReadyWorker()
    {
        workers_ready += 1;
        
        /*if(workers_ready >= References.data.queue_controller.CashiersCount() + References.data.dependents_manager.DependentsCount())
        {

        }*/
    }
}
