using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObstacle : Obstacle {

    [SerializeField]
    private float speed;

    public void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("horizontal"), Input.GetAxis("vertical"));
        input *= speed;
        ChangeVelocity(input);
    }
}
