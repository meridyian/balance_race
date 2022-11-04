using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500f;
    private float movement = 0f;
    public WheelJoint2D backWheel;


    //get user input
    void Update()
    {

        //as numbers to do math
        movement  =- Input.GetAxisRaw("Vertical") * speed;

        
    }

    //do movement
    void FixedUpdate()
    {
        // check whether there is movement to disable motor

        if (movement == 0f)
        {
            backWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
        }
        { 
        // cannot access motor properties directly, need to go via joint
        JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
        backWheel.motor = motor;

        }
    }

}
