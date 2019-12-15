using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NodeCanvas.Framework;

public class GoToHome : ActionTask
{
    Image idk_icon = null;
    Image happy_icon = null;
    Image not_happy_icon = null;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        happy_icon = agent.transform.Find("Canvas").Find("happy_img").GetComponent<Image>();

        idk_icon = agent.transform.Find("Canvas").Find("idk_img").GetComponent<Image>();
        idk_icon.enabled = false;

        not_happy_icon = agent.transform.Find("Canvas").Find("not_happy_img").GetComponent<Image>();

        agent.gameObject.GetComponent<PathFinding>().SetTarget(blackboard.GetValue<Vector3>("SpawnPos"));
        
        if (blackboard.GetValue<bool>("Bought") == true)
        {
            happy_icon.enabled = true;
            agent.gameObject.SetActive(true);
        }
        
        if (blackboard.GetValue<bool>("OutOfTime") == true)
        {
            References.data.shop_rating.DesactivateStars();
            happy_icon.enabled = false;
            not_happy_icon.enabled = true;
            agent.gameObject.SetActive(true);
        }
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            agent.gameObject.SetActive(false);

            References.data.manager_client.AddPoints(blackboard.GetValue<Vector3>("SpawnPos"));

            GameObject.Destroy(agent.gameObject);

            if (References.data.day_cycle.store_is_open)
            {
                References.data.manager_client.SpawnClients();
            }
        }
    }
}
