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

        if (!atm_2.activeInHierarchy)
        {
            References.data.manager_money.AddMoney(-500);
            atm_2.SetActive(true);
            atm_2.transform.Find("BoughtCanvas").gameObject.SetActive(true);

            return;
        }
        if (atm_2.activeInHierarchy && !atm_3.activeInHierarchy)
        {
            References.data.manager_money.AddMoney(-500);

            atm_3.SetActive(true);
            atm_3.transform.Find("BoughtCanvas").gameObject.SetActive(true);

            return;
        }

        return;
    }
}
