using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationspeed = 15f;


    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    public Rigidbody2D rb;

    private float movement = 0f;
    private float rotation = 0f;


    //get user input
    void Update()
    {

        //as numbers to do math
        movement  =- Input.GetAxisRaw("Vertical") * speed;

        //need to apply force since wheels follow the basis, raw no smoothing
        Input.GetAxisRaw("Horizontal");



        
    }

    //do movement
    void FixedUpdate()
    {
        // check whether there is movement to disable motor

        if (movement == 0f)
        {
            frontWheel.useMotor = false;
            backWheel.useMotor = false;
        }
        else
        {
            frontWheel.useMotor = true;
            backWheel.useMotor = true;
        }
        { 
        // cannot access motor properties directly, need to go via joint
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
            frontWheel.motor = motor;

        }

        rb.AddTorque(-rotation *rotationspeed * Time.fixedDeltaTime);
    }

}
