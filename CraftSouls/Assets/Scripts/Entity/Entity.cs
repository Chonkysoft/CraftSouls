using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected InputManager _input;

	// Use this for initialization
	public virtual void Start ()
    {
        _input = new InputManager();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
