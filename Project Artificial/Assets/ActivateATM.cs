using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateATM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject atm_1;
    public GameObject atm_2;
    public GameObject atm_3;
    private int count = 1;
    public void ActivateMoreATM()
    {
        if(count > 4)
        {
            return;
        }
        count++;
        return;
        /*
        if (!atm_2.activeInHierarchy)
        {
            atm_2.SetActive(true);
            
            References.data.queue_controller.AddQueuePoints(atm_2.transform.Find("ATM_QUEUE_POINTS_2"));

            return;
        }
        if (atm_2.activeInHierarchy && !atm_3.activeInHierarchy)
        {
            atm_3.SetActive(true);

            References.data.queue_controller.AddQueuePoints(atm_2.transform.Find("ATM_QUEUE_POINTS_3"));

            return;
        }

        return;*/
    }
}
