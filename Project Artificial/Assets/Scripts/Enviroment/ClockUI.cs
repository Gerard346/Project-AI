using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClockUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject clock_hand_minutes;
    public GameObject clock_hand_hours;
    TimeSpan currentTime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = TimeSpan.FromSeconds(References.data.day_cycle.actual_time);
        string[] temptime = currentTime.ToString().Split(":"[0]);
        
        int hours = int.Parse(temptime[0]);
        
        if(hours > 11)
        {
            hours -= 12;
        }
        int minutes = int.Parse(temptime[1]);
        
        iTween.RotateTo(clock_hand_minutes, iTween.Hash("z", minutes * 6 * -1, "time", 1, "easetype", "easeOutQuint"));
        
        float hour_dist = (float)(minutes) / 60;
        iTween.RotateTo(clock_hand_hours, iTween.Hash("z", (hours + hour_dist)* 360/12 * -1, "time", 1, "easetype", "easeOutQuint"));
    }


}
