using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;
public class Attend : ActionTask
{
    float timer = 0.0f;
    float attend_time = 10.0f;
    Image watch_image = null;

    private CashierController controller = null;
    
    // Start is called before the first frame update
    protected override void OnExecute()
    {
        controller = agent.GetComponent<CashierController>();

        if(controller.cashier_state != CashierController.CASHIER_STATE.CASHIER_ATTENDING)
        {
            EndAction(true);
        }

        attend_time = controller.attend_time / controller.level;

        watch_image = agent.transform.Find("Canvas").Find("watch_image").GetComponent<Image>();

        controller.FixRotation();

    }
    protected override void OnUpdate()
    {
        float watch_value = timer / attend_time;

        watch_image.fillAmount = watch_value;

        timer += Time.deltaTime;

        if (timer > attend_time)
        {
            controller.cashier_state = CashierController.CASHIER_STATE.CASHIER_WORKING;
            References.data.queue_controller.ClientDone(controller.client_on_attention);
            timer = 0.0f;
            controller.cashier_sound.Play(0);
            References.data.manager_money.AddMoney(Random.Range(50, 100));
            controller.FreeRotation();
            
            EndAction(true);
        }
    }
}
