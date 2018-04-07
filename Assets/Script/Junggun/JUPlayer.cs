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
    private Quaternion relativeBodyRotation;
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
        relativeBodyRotation = bodyTransform.localRotation;
    }

	private void Update()
	{
        if (Input.GetButtonDown("Eject"))
            Eject();
	}

	private void FixedUpdate()
	{
        CheckState();
	}

	public void Eject()
    {
        if (CurrentState != EPlayerState.Inputable)
            return;
        bodyTransform.parent = null;
        Debug.LogFormat("ForceAdd! {0}",Power * transform.up);
        prigidbody.AddForce(Power * transform.up, ForceMode.Impulse);
    }

    public void ReloadBody()
    {
        Debug.Log("Reloadbody!");
        bodyTransform.parent = transform;
        bodyTransform.localPosition = relativeBodyPosition;
        bodyTransform.localRotation = relativeBodyRotation;
        CurrentState = EPlayerState.Inputable;
    }

    public void CheckState()
    {
        Debug.LogFormat("CurrentVelocity is : {0}. Current Speed is : {1}", prigidbody.velocity, prigidbody.velocity.magnitude);
        if (CurrentState == EPlayerState.Inputable)
        {
            if(prigidbody.velocity.magnitude > 0.5f)
                CurrentState = EPlayerState.NotInputable;
            return;
        }
        if (prigidbody.velocity.magnitude < 0.5f)
            ReloadBody(); 
    }

}
