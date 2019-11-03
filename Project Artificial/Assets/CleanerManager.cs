using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerManager : MonoBehaviour
{
    public DayCycle cycleday;

    public Transform spawn_cleaner_point;
    public GameObject cleaner;
    public GameObject door;
    public GameObject mop;
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
            new_cleaner.transform.position = spawn_cleaner_point.position;
            new_cleaner.GetComponent<CleanerController>().scene_mop = mop;

            cycleday.time_to_clean = false;
        }
    }
}
