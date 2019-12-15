using UnityEngine;

public class ReferenceContainer : MonoBehaviour{
    public GameObject entities;
    public GameObject clients_container;
    public DayCycle day_cycle;
    
    public QueueController queue_controller;
    public DependentManager dependents_manager;

    public ClientManager manager_client;
    public CleanerController controller_cleaner;
    
    public MoneyManager manager_money;
    public WinLoseCondition win_lose;
    void Start()
    {
        References.data = this;
    }
}

public static class References
{
    public static ReferenceContainer data;
}
