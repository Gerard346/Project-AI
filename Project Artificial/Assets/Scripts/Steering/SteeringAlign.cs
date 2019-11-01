using UnityEngine;
using System.Collections;

public class SteeringAlign : CombineBehaviours
{

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions
        float diff = Vector3.SignedAngle(transform.forward, move.mov_velocity, transform.up);
        if (Mathf.Abs(diff) < min_angle)
        {
            move.AccelerateRotation(0.0f, priority);
        }
        else if (Mathf.Abs(diff) > slow_angle)
        {
            move.AccelerateRotation(Mathf.Clamp(diff, -move.max_rot_acceleration, move.max_rot_acceleration), priority);
        }
     

    }
}
