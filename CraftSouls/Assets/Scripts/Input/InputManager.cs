using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    // The player class for each character will have it's own Input class (eg 'MainPlayerInput')
    // which follows the IInputSystem interface contract.

    // This will be passed into the input manager at a interface level where it will watch for those inputs, allowing for
    // customizable inputs for each character without input manager code change.

    private List<List<Action>> _inputs;

    public InputManager()
    {
        _inputs = new List<List<Action>>();
    }

	public void RegisterActions(IInputSystem system)
    {
        _inputs.Add(system.RetreiveInputActions());
    }
	
	public void UpdateInputs ()
    {
		foreach (var system in _inputs)
        {
            foreach (var action in system)
            {
                if (Input.GetKeyDown(action.Key))
                {
                    if (action.OnTriggerMethod != null)
                        action.OnTriggerMethod();
                }
                // We are keeping the OnHold in an else if as we don't want this triggerring during a key down event.
                else if (Input.GetKey(action.Key))
                {
                    if (action.OnHoldMethod != null)
                        action.OnHoldMethod();
                }

                if (Input.GetKeyUp(action.Key))
                {
                    if (action.OnReleaseMethod != null)
                        action.OnReleaseMethod();
                }
            }
        }
	}
}
