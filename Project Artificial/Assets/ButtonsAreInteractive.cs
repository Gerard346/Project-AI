using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAreInteractive : MonoBehaviour
{
    // Start is called before the first frame update
    public Button car;
    public Button cashier;
    public Button mark_campaign;
    public Button atm_1;
    public Button atm_2;
    public Button atm_3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (References.data.manager_money.TotalMoney() > 100)
        {
            car.interactable = true;
            atm_1.interactable = true;
            atm_1.interactable = true;
            atm_1.interactable = true;
        }
        else
        {
            car.interactable = false;
            atm_1.interactable = false;
            atm_2.interactable = false;
            atm_3.interactable = false;
        }
        if (References.data.manager_money.TotalMoney() > 200)
        {
            mark_campaign.interactable = true;
        }
        else
        {
            mark_campaign.interactable = false;
        }
        if (References.data.manager_money.TotalMoney() > 500)
        {
            cashier.interactable = true;
        }
        else
        {
            cashier.interactable = false;
        }
    }
}
