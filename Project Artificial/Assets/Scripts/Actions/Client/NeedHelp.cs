using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.UI;
public class NeedHelp : ActionTask
{
    float timer = 0.0f;
    float max_timer = 30.0f;
    Image idk_icon = null;
    Image happy_icon = null;

    // Start is called before the first frame update
    protected override void OnExecute()
    {
        happy_icon = agent.transform.Find("Canvas").Find("happy_img").GetComponent<Image>();
        happy_icon.enabled = false;
        idk_icon = agent.transform.Find("Canvas").Find("idk_img").GetComponent<Image>();
        idk_icon.enabled = true;
    }

    protected override void OnUpdate()
    {
        if (blackboard.GetValue<bool>("GettingHelp"))
        {
            if (agent.gameObject.GetComponent<ClientController>().client_state == ClientController.CLIENT_STATE.CLIENT_GO_BUY)
            {
                blackboard.SetValue("GettingHelp", false);
                blackboard.SetValue("Picked", true);
                EndAction(true);
            }

        }
        else
        {
            if (timer > max_timer)
            {
                blackboard.SetValue("OutOfTime", true);
                EndAction(true);
            }

            timer += Time.deltaTime;
        }
    }
}
