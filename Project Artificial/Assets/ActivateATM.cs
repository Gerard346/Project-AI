using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateATM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject atm_1;
    public GameObject atm_2;
    public GameObject atm_3;
    public GameObject atm_4;

    public void ActivateMoreATM()
    {
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
        if (atm_3.activeInHierarchy)
        {
            atm_4.SetActive(true);

            References.data.queue_controller.AddQueuePoints(atm_2.transform.Find("ATM_QUEUE_POINTS_4"));

            return;
        }

        return;
    }
}
