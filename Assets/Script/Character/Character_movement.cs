using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour {
    private float right_thrust,left_thrust;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        right_thrust = 0f;
        left_thrust = 0f;
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        right_thrust = Thrust("right_thrust", right_thrust);
        left_thrust = Thrust("left_thrust", left_thrust);
        rbody.AddForceAtPosition(right_thrust * transform.up, transform.position + transform.right);
        rbody.AddForceAtPosition(left_thrust * transform.up, transform.position - transform.right);
        Debug.Log(right_thrust);
	}

    private float Thrust(string l_or_r, float cur_velocity)
    {
        if (Input.GetButton(l_or_r))
        {
            if(cur_velocity < 1f)
            {
                return cur_velocity + Time.deltaTime;
            }else
            {
                return 1f;
            }
        }
        else
        {
            if(cur_velocity > 0f)
            {
                return cur_velocity - 2f * Time.deltaTime;
            }
            else
            {
                return 0f;
            }
        }
    }
}
