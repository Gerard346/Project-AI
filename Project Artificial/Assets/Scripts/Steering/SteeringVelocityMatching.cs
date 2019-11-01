using UnityEngine;
using System.Collections;

public class SteeringVelocityMatching : MonoBehaviour {

	public float time_to_accel = 0.25f;

	Move move;
	Move target_move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		target_move = move.entity_target.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(target_move)
		{
            // TODO 8: First come up with your ideal velocity
            // then accelerate to it.
            Vector3 vel_target = target_move.mov_velocity;

            move.AccelerateMovement(new Vector3(Mathf.Clamp(vel_target.x - move.mov_velocity.x, -move.max_mov_acceleration, move.max_mov_acceleration), Mathf.Clamp(vel_target.y - move.mov_velocity.y, -move.max_mov_acceleration, move.max_mov_acceleration), Mathf.Clamp(vel_target.z - move.mov_velocity.z, -move.max_mov_acceleration, move.max_mov_acceleration)));
    
        }
    }
}
