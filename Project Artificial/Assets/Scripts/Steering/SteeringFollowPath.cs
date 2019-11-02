using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;

    public float ratio_increment = 0.1f;
    public float min_distance = 1.0f;
    float current_ratio = 0.0f;
    public BGCcMath curve;

    Vector3 closestpoint;
    float dist;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();

        // TODO 1: Calculate the closest point from the tank to the curve
        closestpoint = curve.CalcPositionByClosestPoint(transform.position, out dist);
        current_ratio = dist / curve.GetDistance();
    }
	// Update is called once per frame
	void Update ()
     {
            // TODO 2: Check if the tank is close enough to the desired point
            // If so, create a new point further ahead in the path
            if (Vector3.Magnitude(transform.position - move.target) <= min_distance)
            {
                current_ratio += ratio_increment;
                closestpoint = curve.CalcPositionByDistanceRatio(current_ratio);
            }

            if (current_ratio > 1.0f)
            {
                current_ratio = 0.0f;
            }

            seek.Steer(closestpoint);
     }
    
	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		}

	}
}
