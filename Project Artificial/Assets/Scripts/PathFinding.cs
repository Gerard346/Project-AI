using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    NavMeshAgent nav_mesh;
    Move move;
    SteeringArrive arrive;
    
    Vector3[] path_nav;
    Vector3 path_target;
    
    int path_pos;
    public float path_next_pos;
    private bool is_on_target = false;

    // Start is called before the first frame update
    void Start()
    {
        nav_mesh = GetComponent<NavMeshAgent>();
        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();

        if (path_nav == null)
        {
            enabled = false;
        }
    }
    void Update()
    {

        if (path_nav == null || path_nav.Length == 0)
        {
            enabled = false;
            path_nav = null;
            return;
        }
        if (move.target != path_nav[path_pos] && arrive.IsOnTarget())
        {
            move.target = path_nav[path_pos];
        }
        if (Vector3.Magnitude(path_nav[path_pos] - transform.position) < path_next_pos)
        {
            if (path_pos == path_nav.Length - 1)
            {
                enabled = false;
                path_nav = null;
                is_on_target = true;
            }
            else
            {
                path_pos += 1;
                move.target = path_nav[path_pos];
            }
        }
    }
    public void SetTarget(Vector3 target)
    {
        path_target = target;
        is_on_target = false;

        NavMeshPath path_calc = new NavMeshPath();

        if(nav_mesh == null)
        {
            nav_mesh = GetComponent<NavMeshAgent>();
        }
        if(move == null)
        {
            move = GetComponent<Move>();
        }

        nav_mesh.enabled = true;

        if (nav_mesh.CalculatePath(path_target, path_calc))
        {
            path_nav = new Vector3[path_calc.corners.Length];
            path_nav = path_calc.corners;
            move.target = path_nav[0];
            path_pos = 0;
            enabled = true;
        }

        nav_mesh.enabled = false;
    }

    public bool IsOnTarget()
    {
        return is_on_target;
    }

    public float DistanceToTarget()
    {
        if(move.target != null)
        {
            if (path_nav.Length > 0)
            {
                return Vector3.Distance(path_nav[path_nav.Length - 1], transform.position);
            }
            else
            {
                return Vector3.Distance(move.target, transform.position);
            }
        }
        else
        {
            return 0.0f;
        }
    }

    public void ClearPath()
    {
        enabled = false;
        path_nav = null;
        is_on_target = true;
        move.target = transform.position;
    }

    private void OnDrawGizmos()
    {
        if (path_nav != null)
        {
            foreach (Vector3 pos in path_nav)
            {
                Gizmos.DrawWireSphere(pos, 3);

            }
        }
        Gizmos.DrawWireSphere(path_target, 1);
    }
}
