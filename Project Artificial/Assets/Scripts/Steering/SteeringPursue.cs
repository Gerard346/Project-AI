using UnityEngine;
using System.Collections;

public class SteeringPursue : CombineBehaviours
{

	public float max_seconds_prediction;

	Move move;
    SteeringSeek seek;
    SteeringArrive arrive;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        arrive = GetComponent<SteeringArrive>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.entity_target.transform.position, move.mov_velocity, move.max_mov_velocity);
	}

	public void Steer(Vector3 target, Vector3 target_velocity, float max_target_speed)
	{
        // TODO 5: Create a fake position to represent
        // enemies predicted movement. Then call Steer()
        // on our Steering Seek / Arrive with the predicted position in
        // max_seconds_prediction time
        // Be sure that arrive / seek's update is not called at the same time

        // TODO 6: Improve the prediction based on the distance from
        // our target and the speed we have
        Vector3 predicted_pos = new Vector3(target.x + target_velocity.x * max_seconds_prediction, target.y + target_velocity.y * max_seconds_prediction, target.z + target_velocity.z * max_seconds_prediction);

        arrive.Steer(predicted_pos);
        seek.Steer(predicted_pos);

    }
}
