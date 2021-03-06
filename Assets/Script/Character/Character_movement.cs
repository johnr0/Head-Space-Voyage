﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour {
    private float spin_vel;
    private float max_spin_vel;
    private float max_thrust_vel;
    private float thrust_vel;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        max_spin_vel = 10f;
        spin_vel = 0f;
        max_thrust_vel = 10f;
        thrust_vel = 0f;
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	void FixedUpdate(){
		bool r_input = Input.GetButton("right_thrust");
		bool l_input = Input.GetButton("left_thrust");
		rbody.angularVelocity = 5f/Time.deltaTime * new Vector3(0,0, Add_Spin(r_input, l_input));
		spin_vel = rbody.angularVelocity.z;
		rbody.velocity += 5f*transform.up * Add_Thrust(r_input, l_input);
		thrust_vel = rbody.velocity.magnitude;
	}

    private float Add_Spin(bool r_input, bool l_input)
    {
        if (Mathf.Abs(spin_vel) < max_spin_vel)
        {
            if(r_input && l_input)
            {
                return 0;
            }
            else if (r_input)
            {
                //spin right
                return Time.deltaTime;

            }
            else if (l_input)
            {
                //spin left
                return -Time.deltaTime;
            }else
            {
                return 0;
            }
        }else
        {
            if (spin_vel>max_spin_vel)
            {
                if (l_input)
                {
                    return -Time.deltaTime;
                }else
                {
                    return 0;
                }
            }else if (spin_vel < -max_spin_vel)
            {
                if (r_input)
                {
                    return Time.deltaTime;
                }else
                {
                    return 0;
                }
            }else
            {
                return 0;
            }
        }
        
    }

    private float Add_Thrust(bool r_input, bool l_input)
    {
        if (Mathf.Abs(thrust_vel) < max_thrust_vel)
        {
            if (r_input && l_input)
            {
                //thrust
                return Time.deltaTime;

            }
            else
            {
                return 0;
            }
        }
        else
        {
            if(r_input && l_input)
            {
                float cur_vel = rbody.velocity.magnitude;
                float expected_vel = (rbody.velocity + Time.deltaTime * transform.up).magnitude;
                //when expected velocity value decreases
                if (cur_vel >= expected_vel)
                {
                    return Time.deltaTime;
                }else//when expected velocity value increases
                {
                    return 0;
                }
            }else
            {
                return 0;
            }
        }
    }


}
