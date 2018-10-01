using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableEntity
{
    public override void Start()
    {
        base.Start();
    }

    protected override IInputSystem RegsiterActions()
    {
        return new MainPlayerInput(this);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
