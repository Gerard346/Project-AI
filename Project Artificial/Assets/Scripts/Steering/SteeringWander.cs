using UnityEngine;
using System.Collections;

public class SteeringWander : CombineBehaviours
{
    Move move;
    SteeringSeek seek;

    public GameObject plane;

    public float min_distance = 0.1f;
    public float time_to_target = 0.25f;
    public float max_angle = 0.5f;
    public float limits_distance = 0.2f;

    Rect area_to_wander;

    void Start()
    {
        move = GetComponent<Move>();

        float area_width = plane.GetComponent<MeshFilter>().mesh.bounds.size.x * plane.transform.localScale.x;
        float area_height = plane.GetComponent<MeshFilter>().mesh.bounds.size.z * plane.transform.localScale.z;

        area_to_wander =new Rect((-area_width/2)+limits_distance, (area_height/2)-limits_distance, area_width-limits_distance, area_height-limits_distance);

        CalculateNewTargetPosition();
    }

    // Update is called once per     frame
    void Update()
    {
        // TODO Homework: Update the target location to a random point in a circle
        // You could just call seek.Steer() / arrive.Steer() or simply do the calculations by yourself
        // like the code below.
        // TODO 9: Generate a velocity vector in a random rotation (use RandomBinominal) and some attenuation factor
        if (Mathf.Abs(Vector3.Distance(transform.position, move.target)) < min_distance)
        {
            CalculateNewTargetPosition();
        }
    }
    public void CalculateNewTargetPosition()
    {
        float random = Random.Range(-max_angle, max_angle);

        Vector3 current_direction = gameObject.transform.forward;
        Vector3 new_direction = Quaternion.AngleAxis(random, Vector3.up) * current_direction;

        if (!area_to_wander.Contains(transform.position))
        {
            random = max_angle;
            new_direction = Quaternion.AngleAxis(random, Vector3.up) * current_direction;
            move.target = new Vector3(transform.position.x + new_direction.x * move.max_mov_velocity * (time_to_target * 0.1f), transform.position.y + new_direction.y * move.max_mov_velocity * (time_to_target * 0.1f), transform.position.z + new_direction.z * move.max_mov_velocity * (time_to_target * 0.1f));
        }
        else
        {
            move.target = new Vector3(transform.position.x + new_direction.x * move.max_mov_velocity * time_to_target, transform.position.y + new_direction.y * move.max_mov_velocity * time_to_target, transform.position.z + new_direction.z * move.max_mov_velocity * time_to_target);
        }
    }
}
