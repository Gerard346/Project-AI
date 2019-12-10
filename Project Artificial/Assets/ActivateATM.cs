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
        if (!atm_2.activeSelf)
        {
            atm_2.SetActive(true);
            return;
        }
        if (atm_2.activeSelf && !atm_3.activeSelf)
        {
            atm_3.SetActive(true);
            return;
        }
        if (atm_3.activeSelf)
        {
            atm_4.SetActive(true);
            return;
        }
        return;
    }
}
