using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class CleanerController : MonoBehaviour
{
    public enum CLEANER_STATE
    {
        CLEANER_START_WORKING = 0,
        CLEANER_WORKING,
        CLEANER_END_WOKING
    };

    public SteeringFollowPath follow_path;
    public GameObject mop;
    public GameObject scene_mop;
    public BGCcMath start_working_path;
    public BGCcMath working_path;
    public BGCcMath end_working_path;
    public CLEANER_STATE cleaner_state;

    // Start is called before the first frame update
    void Start()
    {
        follow_path = GetComponent<SteeringFollowPath>();

        mop = this.transform.GetChild(0).gameObject;
        mop.SetActive(false);
        follow_path.enabled = true;
        follow_path.SetPath(start_working_path,false);
        cleaner_state = CLEANER_STATE.CLEANER_START_WORKING;
    }

    // Update is called once per frame
    void Update()
    {
        if(cleaner_state == CLEANER_STATE.CLEANER_START_WORKING && follow_path.path_completed)
        {
            cleaner_state = CLEANER_STATE.CLEANER_WORKING;
            mop.SetActive(true);
            scene_mop.SetActive(false);
            follow_path.SetPath(working_path, false);
        }
        else if(cleaner_state == CLEANER_STATE.CLEANER_WORKING && follow_path.path_completed)
        {
            cleaner_state = CLEANER_STATE.CLEANER_END_WOKING;
            mop.SetActive(false);
            scene_mop.SetActive(true);
            follow_path.SetPath(end_working_path,false);
        }
        else if(cleaner_state == CLEANER_STATE.CLEANER_END_WOKING && follow_path.path_completed)
        {
            Destroy(gameObject,0.5f);
        }
    }
}
