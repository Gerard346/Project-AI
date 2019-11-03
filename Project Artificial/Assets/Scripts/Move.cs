using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour
{
    public GameObject entity_target;
    public Vector3 target;
    //public GameObject aim;
    //public Slider arrow;
    Animator move_animator;

    public float max_mov_velocity = 25.0f;
    public float max_mov_acceleration = 5.0f;
    public float rotation_velocity = 0.1f;
    public float max_rot_acceleration = 1.0f;
    public float max_rot_speed = 10.0f;
    public Vector3 mov_velocity = Vector3.zero;

    Vector3[] movementvelocity = new Vector3[10];
    float[] rotationvelocity = new float[10];

    private void Start()
    {
        target = transform.position;
        move_animator = gameObject.GetComponent<Animator>();
    }
    // Use this for initialization
    public void SetMovementVelocity(Vector3 vel)
    {
        mov_velocity = vel;
    }
    public void AccelerateMovement(Vector3 vel, int priority)
    {
        if(vel.magnitude > max_mov_acceleration)
        {
            vel = vel.normalized * max_mov_acceleration;
        }
        movementvelocity[priority] = vel;
    }
    public void SetRotationVelocity(float rot_velocity)
    {
        rotation_velocity = rot_velocity;
    }
    public void AccelerateRotation(float rot_acceleration, int priority)
    {
        if(Mathf.Abs(rot_acceleration) > max_rot_acceleration)
        {
            rot_acceleration = max_rot_acceleration * rot_acceleration / (Mathf.Abs(rot_acceleration));
        }
        rotationvelocity[priority] = rot_acceleration;
    }
    // Update is called once per frame
    void Update()
    {

        for(int i = movementvelocity.Length-1; i>0; i--)
        {
            if(movementvelocity[i].magnitude > 0.0f)
            {
                mov_velocity += movementvelocity[i]*Time.deltaTime;
                break;
            }
        }
        for (int i = rotationvelocity.Length-1; i > 0; i--)
        {
            if (Mathf.Abs(rotationvelocity[i]) > 0.0f)
            {
                rotation_velocity += rotationvelocity[i]*Time.deltaTime;
                break;
            }
        }

        if (mov_velocity.magnitude > max_mov_velocity)//magnitude->Vector size
        {
            mov_velocity.Normalize(); //If so put the vector at 1
            mov_velocity *= max_mov_velocity;//then multply by his maximum number
        }
        //caping rotation
        Mathf.Clamp(rotation_velocity, -max_rot_speed, max_rot_speed);//Makes sure the value is between this two values.

        float angle = Mathf.Atan2(mov_velocity.x, mov_velocity.z);//Atan2->Angle vector of axis y
        //aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);//


        //arrow.value = mov_velocity.magnitude * 4;

        transform.rotation *= Quaternion.AngleAxis(rotation_velocity * Time.deltaTime, Vector3.up);
        mov_velocity.y = 0.0f;
        transform.position += mov_velocity * Time.deltaTime;

        //Reset to 0
        for(int i = 0; i<movementvelocity.Length; i++)
        {
            movementvelocity[i] = Vector3.zero;
        }

        for(int i = 0; i < rotationvelocity.Length; i++)
        {
            rotationvelocity[i] = 0.0f;
        }

        //rotation_velocity = 0.0f;
        //mov_velocity = Vector3.zero;
        move_animator.SetFloat("velocity", mov_velocity.magnitude);
    }

    public void GoTo(Vector3 target_point)
    {
        GetComponent<PathFinding>().SetTarget(target_point);
    }
}
