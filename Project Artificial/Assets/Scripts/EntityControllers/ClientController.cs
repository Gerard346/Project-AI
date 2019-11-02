using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : MonoBehaviour
{
    public Vector3 pick_point;
    public Vector3 sell_point;
    public Vector3 kill_point;

    Move move = null;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();

        move.GoTo(pick_point);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
