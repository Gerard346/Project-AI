using UnityEngine;
using System.Collections;

public class StaticAlign : CombineBehaviours
{

    public float min_angle = 0.01f;
    public float slow_angle = 0.1f;
    public float time_to_target = 0.1f;

    public float target_angle = 0.0f;

    Move move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions
        float diff = target_angle - transform.localRotation.eulerAngles.y;

        if(target_angle < transform.localRotation.eulerAngles.y)
        {
            if(Mathf.Abs(target_angle - transform.localRotation.eulerAngles.y) < 180)
            {
                diff *= 1;
            }
            else
            {
                diff *= -1;
            }
        }
        else
        {
            if (Mathf.Abs(target_angle - transform.localRotation.eulerAngles.y) < 180)
            {
                diff *= -1;
            }
            else
            {
                diff *= +1;
            }
        }

        if (Mathf.Abs(diff) > min_angle)
        {
            float ideal_rot_velocity = 0.0f;

            if (Mathf.Abs(diff) > slow_angle)
            {
                ideal_rot_velocity = diff / Mathf.Abs(diff) * move.max_rot_acceleration;
                //move.AccelerateRotation(Mathf.Clamp(diff/Mathf.Abs(diff) *  move.max_rot_acceleration, -move.max_rot_acceleration, move.max_rot_acceleration), priority);
            }
            else
            {
                ideal_rot_velocity = (move.max_rot_speed * (Mathf.Abs(diff) / slow_angle)) * diff / Mathf.Abs(diff); //diff direcció a la que vols anar . ()el vector cap on val anar a la màxima velocitat.
            }

            ideal_rot_velocity /= time_to_target;

            move.AccelerateRotation(ideal_rot_velocity - move.rotation_velocity, priority);
        }
        else
        {
            move.SetRotationVelocity(0.0f);
            enabled = false;
        }

    }
}
