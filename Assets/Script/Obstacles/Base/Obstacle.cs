using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Obstacle : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody
    {
        get
        {
            if (_rigidbody == null)
                _rigidbody = GetComponent<Rigidbody>();
            return _rigidbody;
        }
    }

    public virtual void ChangeMass(float mass)
    {
        Rigidbody.mass = mass;
    }

    public virtual void ChangeVelocity(Vector2 vel)
    {
        Rigidbody.velocity = new Vector3(vel.x, vel.y, 0f);
    }
}