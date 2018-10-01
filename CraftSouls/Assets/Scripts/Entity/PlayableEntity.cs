using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayableEntity : Entity
{
    protected IInputSystem _inputs;

    public Rigidbody Body { get; private set; }

    protected virtual IInputSystem RegsiterActions() { throw new NotImplementedException(); }

    public override void Start()
    {
        _inputs = RegsiterActions();
        InputManager.Instance.RegisterActions(_inputs);
        Body = GetComponent<Rigidbody>();

        base.Start();
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
