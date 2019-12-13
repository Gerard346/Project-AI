using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
public class cashierManager : MonoBehaviour
{
    public DayCycle cycleday;

    public GameObject Cashier1;
    public GameObject Cashier2;
    public GameObject Cashier3;

    public GameObject ATM_1;
    public GameObject ATM_2;
    public GameObject ATM_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cycleday.spawn_employees == true)
        {
            if (ATM_1.activeSelf)
            {
                GameObject new_employer1 = Instantiate(Cashier1);
                new_employer1.transform.parent = ATM_1.transform;
                References.data.queue_controller.AddCashier(new_employer1.GetComponentInChildren<CashierController>());
                new_employer1.SetActive(true);
            }
            if (ATM_2.activeSelf)
            {
                GameObject new_employer2 = Instantiate(Cashier2);
                new_employer2.transform.parent = ATM_2.transform;
                References.data.queue_controller.AddCashier(new_employer2.GetComponentInChildren<CashierController>());

                new_employer2.SetActive(true);
            }
            if (ATM_3.activeSelf)
            {
                GameObject new_employer3 = Instantiate(Cashier3);
                new_employer3.transform.parent = ATM_3.transform;
                References.data.queue_controller.AddCashier(new_employer3.GetComponentInChildren<CashierController>());

                new_employer3.SetActive(true);
            }
            cycleday.spawn_employees = false;
        }
    }
}
