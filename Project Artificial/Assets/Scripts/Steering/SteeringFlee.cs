using UnityEngine;
using System.Collections;

public class SteeringFlee : CombineBehaviours
{

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target);
	}

	public void Steer(Vector3 target)
	{
        // TODO 2: Same as Steering seek but opposite direction
        if (!move)
            move = GetComponent<Move>();

        Vector3 diff = target - transform.position;
        diff = diff.normalized * move.max_mov_acceleration;
        move.AccelerateMovement(-diff, priority);
        move.target = target;
    }
}
