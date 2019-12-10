using NodeCanvas.Framework;

public class Buy : ActionTask
{
    protected override void OnExecute()
    {
        References.data.queue_controller.AttendClient(agent.gameObject.GetComponent<ClientController>());
    }
    protected override void OnUpdate()
    {
        if(agent.gameObject.GetComponent<ClientController>().queue_controller == null)
        {
            blackboard.SetValue("Bought", true);
            EndAction(true);
        }
    }
}
