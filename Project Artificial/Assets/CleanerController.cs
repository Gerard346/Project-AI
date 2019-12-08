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


}
