using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public delegate void OnTrigger();
    public delegate void OnHold();
    public delegate void OnRelease();

    public KeyCode Key { get; private set; }
    public string Name { get; private set; }
    public OnTrigger OnTriggerMethod { get; private set; }
    public OnHold OnHoldMethod { get; private set; }
    public OnRelease OnReleaseMethod { get; private set; }

    public Action(KeyCode key, 
                    string name,
                    OnTrigger onTrigger = null,
                    OnHold onHold = null,
                    OnRelease onRelease = null)
    {
        Key = key;
        Name = name;
        OnTriggerMethod = onTrigger;
        OnHoldMethod = onHold;
        OnReleaseMethod = onRelease;
    }

    // Set up these operator overloads so that when these Actions are added to a dictionary and are refernced by Name,
    // the Dictionary will be able to find it by Name in the [] rather than the Action object. 

    public static bool operator ==(Action a, string s)
    {
        return a.Name == s;
    }

    public static bool operator !=(Action a, string s)
    {
        return a.Name != s;
    }

    public override string ToString()
    {
        return Name;
    }
}
