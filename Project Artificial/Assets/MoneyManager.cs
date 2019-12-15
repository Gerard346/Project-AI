using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    float coins;
    public Text coins_text;
    void Start()
    {
        coins = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        coins_text.text = "Total Coins: " + coins;
    }

    public void AddMoney(float money)
    {
        coins += money;
    }

    public float TotalMoney()
    {
        return coins;
    }
}
