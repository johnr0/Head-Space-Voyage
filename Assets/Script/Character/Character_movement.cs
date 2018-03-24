using System.Collections;
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
        bool r_input = Input.GetButton("right_thrust");
        bool l_input = Input.GetButton("left_thrust");
        Debug.Log(Add_Thrust(r_input, l_input));
        Debug.Log(new Vector3(0,0,10f)* Add_Thrust(r_input, l_input));
        rbody.angularVelocity += new Vector3(0,0, Add_Spin(r_input, l_input));
        spin_vel = rbody.angularVelocity.z;
        rbody.velocity += transform.up * Add_Thrust(r_input, l_input);
        thrust_vel = rbody.velocity.magnitude;
        
        //rbody.AddForceAtPosition(right_thrust * transform.up, transform.position + transform.right);
        //rbody.AddForceAtPosition(left_thrust * transform.up, transform.position - transform.right);
        //Debug.Log(right_thrust);
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
                Debug.Log("1");
                //thrust
                return Time.deltaTime;

            }
            else
            {
                Debug.Log("2");
                return 0;
            }
        }
        else
        {
            if(r_input && l_input)
            {
                Debug.Log("3");
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
                Debug.Log("4");
                return 0;
            }
        }
    }


}
