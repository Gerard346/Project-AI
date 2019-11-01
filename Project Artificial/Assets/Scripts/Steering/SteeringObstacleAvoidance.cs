using UnityEngine;
using System.Collections;


public class SteeringObstacleAvoidance : CombineBehaviours
{

    public LayerMask mask;
    public float avoid_distance = 5.0f;

    [System.Serializable]
    public class Rays
    {
        public Vector3 direction;
        public float length;
    }
    public Rays[] rays;
    private RaycastHit hit1;

    Move move;
    SteeringSeek seek;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
        Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

        foreach (Rays ray in rays)
        {
            Vector3 dirRay = q * ray.direction;

            if (Physics.Raycast(transform.position, dirRay, out hit1, ray.length, mask))
            {
                Vector3 escapeTargetPosition = hit1.point + hit1.normal * avoid_distance;
                if (!move)
                    move = GetComponent<Move>();

                Vector3 diff = escapeTargetPosition - transform.position;
                diff.Normalize();

                move.mov_velocity += diff;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (move && this.isActiveAndEnabled)
        {
            Gizmos.color = Color.red;
            float angle = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z);
            Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

            foreach (Rays ray in rays)
            {
                Vector3 dirRay = q * ray.direction;

                Debug.DrawRay(transform.position, dirRay * ray.length, Color.red);
            }
        }
    }
}
