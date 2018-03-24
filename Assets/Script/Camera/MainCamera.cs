using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : Singleton<MainCamera> {

    private enum ECameraState
    {
        Follow = 0,
    }


    [SerializeField]
    private Transform FollowingTransform;
    private ECameraState CurrentCameraState = ECameraState.Follow;
    private Vector3 FollowingOffset;



    private void Awake()
    {
        FollowingOffset = transform.position - FollowingTransform.position;
    }

    private void Update()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        transform.position = FollowingTransform.position + FollowingOffset;
    }

}
