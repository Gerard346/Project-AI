using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependentController : MonoBehaviour
{
    private ClientController client = null;
    public Transform spawn_pos;
    public Transform observer_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelpClient(ClientController new_client)
    {
        client = new_client;
    }
    public ClientController GetClient()
    {
        return client;
    }
}
