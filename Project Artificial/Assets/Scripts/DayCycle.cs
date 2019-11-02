using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    public float actual_time;
    public int total_time_day;
    public int days;
    public TimeSpan current_time;
    public TimeSpan current_day;
    public float speed;

    public Light sun;

    public Text time_ui;
    public Text day_ui;


    // Start is called before the first frame update
    void Start()
    {
        total_time_day = 24 * 60 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        //DAY
        actual_time += Time.deltaTime * speed;

        if (actual_time > total_time_day)
        {
            actual_time = 0;
            days += 1;
        }

        if (actual_time < 43200)
        {
            sun.intensity = 1 - (43200 - actual_time) / 43200;

        }
        else
        {
            sun.intensity = 1 - ((43200 - actual_time) / 43200 * -1);
        }

        sun.transform.rotation = Quaternion.Euler(new Vector3((actual_time - total_time_day / 4) / total_time_day * 360, 0, 0));

        //UI
        current_day = TimeSpan.FromDays(days);
        current_time = TimeSpan.FromSeconds(actual_time);

        string tempday = current_day.ToString();
        day_ui.text = "Days passed: " + tempday[0];

        string[] temptime = current_time.ToString().Split(":"[0]);
        time_ui.text = "Actual Time: " + temptime[0] + "h" + temptime[1] + "min";

       
    }
}
