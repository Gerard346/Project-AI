using UnityEngine;
using System.Collections;

public class SteeringSeparation : CombineBehaviours
{

    public LayerMask mask;
    public float search_radius = 5.0f;
    public AnimationCurve strength;

    Move move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

        Collider[] tanks = Physics.OverlapSphere(transform.position, search_radius, mask.value);
        Vector3 separation = Vector3.zero;

        foreach (Collider col in tanks)
        {
            if (transform.GetComponent<Collider>() != col)
            {
                separation = transform.position - col.transform.position;
                separation.Normalize();
                separation *= 0.1f - strength.Evaluate(separation.magnitude / search_radius);
            }
            move.mov_velocity += separation;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, search_radius);
    }
}