using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerInput : IInputSystem
{
    private PlayableEntity _entity;
    private bool _leftTriggered;
    private bool _rightTriggered;
    private bool _upTriggered;
    private bool _downTriggered;

    public MainPlayerInput(PlayableEntity entity)
    {
        _entity = entity;
        _leftTriggered = false;
        _rightTriggered = false;
        _upTriggered = false;
        _downTriggered = false;
    }

	List<Action> IInputSystem.RetreiveInputActions()
    {
        return new List<Action>(new Action[]
        {
            new Action(KeyCode.Space, "Jump", OnJumpKeyDown, null, OnJumpKeyUp),
            new Action(KeyCode.A, "MoveLeft", OnLeft, MoveLeft, OffLeft),
            new Action(KeyCode.D, "MoveRight", OnRight, MoveRight, OffRight),
            new Action(KeyCode.W, "MoveUp", OnUp, MoveUp, OffUp),
            new Action(KeyCode.S, "MoveDown", OnDown, MoveDown, OffDown)
        });
    }

    private void OnJumpKeyDown()
    {
        // do something;
        Debug.Log("Key Down");
        //_entity.Body.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
    }

    private void OnJumpKeyUp()
    {
        // do something;
        Debug.Log("Key Up");
    }

    private void OnLeft()
    {
        TriggerLeftBool(true, true);
    }

    private void OffLeft()
    {
        TriggerLeftBool(false);
    }

    private void OnRight()
    {
        TriggerRightBool(true, true);
    }

    private void OffRight()
    {
        TriggerRightBool(false);
    }

    private void OnUp()
    {
        TriggerUpBool(true, true);
    }
    private void OffUp()
    {
        TriggerUpBool(false);
    }

    private void OnDown()
    {
        TriggerDownBool(true, true);
    }

    private void OffDown()
    {
        TriggerDownBool(false);
    }

    private void MoveLeft()
    {
        //_entity.Body.AddForce(new Vector2(-3, 0));
        if (_leftTriggered)
        {
            _entity.transform.Translate(-3 * Time.deltaTime, 0, 0);
        }
    }

    private void MoveRight()
    {
        //_entity.Body.AddForce(new Vector2(3, 0));
        if (_rightTriggered)
        {
            _entity.transform.Translate(3 * Time.deltaTime, 0, 0);
        }
    }

    private void MoveUp()
    {
        if (_upTriggered)
        {
            _entity.transform.Translate(0, 0, 3 * Time.deltaTime);
        }
    }

    private void MoveDown()
    {
        if (_downTriggered)
        {
            _entity.transform.Translate(0, 0, -3 * Time.deltaTime);
        }
    }

    private void TriggerLeftBool(bool isTriggered, bool resetOther = false)
    {
        _leftTriggered = isTriggered;
        _rightTriggered = resetOther ? false : _rightTriggered;
    }

    private void TriggerRightBool(bool isTriggered, bool resetOther = false)
    {
        _rightTriggered = isTriggered;
        _leftTriggered = resetOther ? false : _leftTriggered;
    }

    private void TriggerUpBool(bool isTriggered, bool resetOther = false)
    {
        _upTriggered = isTriggered;
        _downTriggered = resetOther ? false : _upTriggered;
    }

    private void TriggerDownBool(bool isTriggered, bool resetOther = false)
    {
        _downTriggered = isTriggered;
        _upTriggered = resetOther ? false : _downTriggered;
    }
}
