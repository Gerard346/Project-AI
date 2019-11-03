using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class CleanerManager : MonoBehaviour
{
    public DayCycle cycleday;

    public Transform spawn_cleaner_point;
    public GameObject cleaner;
    public GameObject door;
    public GameObject mop;

    public BGCcMath start_working_path;
    public BGCcMath working_path;
    public BGCcMath end_working_path;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cycleday.time_to_clean == true)
        {
            GameObject new_cleaner = Instantiate(cleaner);
            new_cleaner.SetActive(true);
            new_cleaner.transform.position = spawn_cleaner_point.position;
            new_cleaner.GetComponent<CleanerController>().scene_mop = mop;

            new_cleaner.GetComponent<CleanerController>().start_working_path = start_working_path;
            new_cleaner.GetComponent<CleanerController>().end_working_path = end_working_path;
            new_cleaner.GetComponent<CleanerController>().working_path = working_path;

            cycleday.time_to_clean = false;
        }
    }
}
