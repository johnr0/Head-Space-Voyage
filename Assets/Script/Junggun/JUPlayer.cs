using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUUtil;

public class JUPlayer : Singleton<JUPlayer> {

    private Transform _bodyTransform;
    public Transform bodyTransform
    {
        get
        {
            if (_bodyTransform == null)
                _bodyTransform = transform.GetChild(0);
            return _bodyTransform;
        }
    }
    private Vector3 relativeBodyPosition;
    private Rigidbody _prigidbody;
    public Rigidbody prigidbody
    {
        get
        {
            if (_prigidbody == null)
                _prigidbody = GetComponent<Rigidbody>();
            return _prigidbody;
        }
    }
    [SerializeField]
    private float Power;
    private EPlayerState CurrentState = EPlayerState.Inputable;


	private void Awake()
	{
        Init();
	}

	public void Init()
    {
        relativeBodyPosition = bodyTransform.localPosition;
    }

	private void Update()
	{
        if (Input.GetButtonDown("Eject"))
            Eject();
	}

	private void FixedUpdate()
	{
        Debug.LogFormat("CurrentVelocity is : {0}. Current Speed is : {1}", prigidbody.velocity, prigidbody.velocity.magnitude);
	}

	public void Eject()
    {
        if (CurrentState != EPlayerState.Inputable)
            return;
        bodyTransform.parent = null;
        prigidbody.AddForce(Power * transform.forward, ForceMode.Impulse);
        CurrentState = EPlayerState.NotInputable;
    }

    public void ReloadBody()
    {
        bodyTransform.parent = transform;
        bodyTransform.localPosition = relativeBodyPosition;
    }

}
