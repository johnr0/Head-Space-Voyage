using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JURotation : MonoBehaviour {
    [SerializeField]
    private float rotationspeed;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckMousePosition();
	}

    public void CheckMousePosition()
    {
        Vector3 diffpos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Vector3.SignedAngle(Vector3.up, diffpos, Vector3.back);
        transform.up = Quaternion.Euler(Vector3.back * angle) * Vector3.up;
    }

    public void Rotate()
    {
        
    }
}
