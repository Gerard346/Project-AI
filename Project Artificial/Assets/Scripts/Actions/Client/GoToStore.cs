using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.UI;
public class GoToStore : ActionTask
{
    Image happy_icon = null;
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        blackboard.SetValue("SpawnPos", agent.gameObject.transform.position);

        agent.gameObject.GetComponent<PathFinding>().SetTarget(agent.gameObject.GetComponent<ClientController>().pick_point);

        happy_icon = agent.transform.Find("Canvas").Find("happy_img").GetComponent<Image>();
        happy_icon.enabled = true;
    }
    protected override void OnUpdate()
    {
        if (agent.gameObject.GetComponent<PathFinding>().IsOnTarget())
        {
            EndAction(true);
        }
      
    }
}
