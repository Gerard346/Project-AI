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
    public GameObject orientation_pos1;
    public GameObject orientation_pos2;
    public GameObject orientation_pos3;

    public BGCcMath start_path_1;
    public BGCcMath end_path_1;
    public BGCcMath start_path_2;
    public BGCcMath end_path_2;
    public BGCcMath start_path_3;
    public BGCcMath end_path_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cycleday.spawn_employees == true)
        {
            GameObject new_employer1 = Instantiate(Cashier1);
            new_employer1.SetActive(true);
            
            new_employer1.transform.position = Cashier1.transform.position;
          
            new_employer1.GetComponent<CashierController>().orientation_pos = orientation_pos1;
            new_employer1.GetComponent<CashierController>().walk_to_work_path = start_path_1;
            new_employer1.GetComponent<CashierController>().go_home_path = end_path_1;

            GameObject new_employer2 = Instantiate(Cashier2);
            new_employer2.SetActive(true);

            new_employer2.transform.position = Cashier2.transform.position;
           
            new_employer2.GetComponent<CashierController>().orientation_pos = orientation_pos2;
            new_employer2.GetComponent<CashierController>().walk_to_work_path = start_path_2;
            new_employer2.GetComponent<CashierController>().go_home_path = end_path_2;

            GameObject new_employer3 = Instantiate(Cashier3);
            new_employer3.SetActive(true);

            new_employer3.transform.position = Cashier3.transform.position;

            new_employer3.GetComponent<CashierController>().orientation_pos = orientation_pos3;
            new_employer3.GetComponent<CashierController>().walk_to_work_path = start_path_3;
            new_employer3.GetComponent<CashierController>().go_home_path = end_path_3;


            cycleday.spawn_employees = false;
        }
    }
}
