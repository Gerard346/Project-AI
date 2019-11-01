using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour
{
    public GameObject entity_target;
    public Vector3 target;
    public GameObject aim;
    public Slider arrow;
    public float max_mov_velocity = 25.0f;
    public float max_mov_acceleration = 5.0f;
    public float rotation_velocity = 0.1f;
    public float max_rot_acceleration = 1.0f;
    public float max_rot_speed = 10.0f;
    public Vector3 mov_velocity = Vector3.zero;


    private void Start()
    {
        target = transform.position;
    }
    // Use this for initialization
    public void SetMovementVelocity(Vector3 vel)
    {
        mov_velocity = vel;
    }
    public void AccelerateMovement(Vector3 vel)
    {
        mov_velocity += vel;
    }
    public void SetRotationVelocity(float rot_velocity)
    {
        rotation_velocity = rot_velocity;
    }
    public void AccelerateRotation(float rot_acceleration)
    {
        rotation_velocity += rot_acceleration;
    }
    // Update is called once per frame
    void Update()
    {
        if (mov_velocity.magnitude > max_mov_velocity)//magnitude->Vector size
        {
            mov_velocity.Normalize(); //If so put the vector at 1
            mov_velocity *= max_mov_velocity;//then multply by his maximum number
        }
        //caping rotation
        Mathf.Clamp(rotation_velocity, -max_rot_speed, max_rot_speed);//Makes sure the value is between this two values.

        float angle = Mathf.Atan2(mov_velocity.x, mov_velocity.z);//Atan2->Angle vector of axis y
        aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);//


        arrow.value = mov_velocity.magnitude * 4;

        transform.rotation *= Quaternion.AngleAxis(rotation_velocity * Time.deltaTime, Vector3.up);
        mov_velocity.y = 0.0f;
        transform.position += mov_velocity * Time.deltaTime;

        mov_velocity = Vector3.zero;
        rotation_velocity = 0.0f;

    }
}
