using NodeCanvas.Framework;

public class Buy : ActionTask
{
    protected override void OnExecute()
    {
        References.data.queue_controller.AttendClient(agent.gameObject.GetComponent<ClientController>());

    }
    protected override void OnUpdate()
    {
        if(agent.gameObject.GetComponent<ClientController>().client_state == ClientController.CLIENT_STATE.CLIENT_BUY_DONE)
        {
            blackboard.SetValue("Bought", true);
            EndAction(true);
        }
    }
}
