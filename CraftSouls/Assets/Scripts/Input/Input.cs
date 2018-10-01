using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using XInputDotNetPure;

namespace Assets.Scripts.Input
{
    public class Input
    {
        public enum GamePadButtons { Start, Back, LeftStick, RightStick, LeftShoulder, RightShoulder, XboxButton, A, B, X, Y }
        public enum GamePadAnalog { LeftStick, RightStick }

        public Input() { }


        // I'm thinking of moving these over to the actual classes down the bottom.
        public Input(KeyCode code)
        {

        }

        public Input(GamePadButtons button)
        {

        }

        public Input(GamePadAnalog analog, float pressedThresholdX, float pressedThresholdY)
        {

        }

        public virtual void PreCheck() { }
        public virtual bool IsFirstPressed() { return false; }
        public virtual bool IsHeld() { return false; }
        public virtual bool IsFirstReleased() { return false; }
        public virtual bool IsReleased() { return false; }

        private class KeyboardInput : Input
        {

        }

        private class GamePadInput : Input
        {
            private bool _isFirstPressed;
            private bool _isPrevPressed;
            private bool _isHeld;
            private bool _isFirstReleased;
            private bool _isPrevReleased;
            private float _pressedThreshold;
            private GamePadButtons _button;

            public GamePadInput(GamePadButtons button)
            {
                Init(button);
            }

            public GamePadInput(GamePadButtons button, float pressedThreshold)
            {
                Init(button);
                _pressedThreshold = pressedThreshold;
            }

            private void Init(GamePadButtons button)
            {
                _isFirstPressed = false;
                _isPrevPressed = false;
                _isHeld = false;
                _isFirstReleased = false;
                _isPrevReleased = true;
                _button = button;
            }

            public override void PreCheck()
            {
                var state = GamePad.GetState(PlayerIndex.One);
                ButtonState buttonState;

                if (_button == GamePadButtons.LeftShoulder)
                {
                    if (state.Triggers.Left >= _pressedThreshold)
                    {
                        buttonState = ButtonState.Pressed;
                    }
                    else
                    {
                        buttonState = ButtonState.Released;
                    }
                }
                else if (_button == GamePadButtons.RightShoulder)
                {
                    if (state.Triggers.Right >= _pressedThreshold)
                    {
                        buttonState = ButtonState.Pressed;
                    }
                    else
                    {
                        buttonState = ButtonState.Released;
                    }
                }
                else
                {
                    switch (_button)
                    {
                        case GamePadButtons.A:
                            buttonState = state.Buttons.A;
                            break;
                        case GamePadButtons.B:
                            buttonState = state.Buttons.B;
                            break;
                        case GamePadButtons.Back:
                            buttonState = state.Buttons.Back;
                            break;
                        case GamePadButtons.LeftShoulder:
                            buttonState = state.Buttons.LeftShoulder;
                            break;
                        case GamePadButtons.LeftStick:
                            buttonState = state.Buttons.LeftStick;
                            break;
                        case GamePadButtons.RightShoulder:
                            buttonState = state.Buttons.RightShoulder;
                            break;
                        case GamePadButtons.RightStick:
                            buttonState = state.Buttons.RightStick;
                            break;
                        case GamePadButtons.Start:
                            buttonState = state.Buttons.Start;
                            break;
                        case GamePadButtons.X:
                            buttonState = state.Buttons.X;
                            break;
                        case GamePadButtons.XboxButton:
                            buttonState = state.Buttons.Guide;
                            break;
                        case GamePadButtons.Y:
                            buttonState = state.Buttons.Y;
                            break;
                        default:
                            buttonState = ButtonState.Released;
                            break;
                    }
                }

                if (buttonState == ButtonState.Pressed)
                {
                    _isFirstPressed = true;

                    if (!_isPrevPressed)
                    {
                        _isFirstPressed = true;
                        _isHeld = false;
                    }
                    else
                    {
                        _isFirstPressed = false;
                        _isHeld = true;
                    }

                    _isPrevPressed = _isFirstPressed || _isHeld;
                }
                else
                {
                    if (_isPrevPressed)
                    {
                        _isFirstReleased = true;
                    }
                    else
                    {
                        _isFirstReleased = false;
                    }

                    _isPrevReleased = _isFirstReleased;
                }
            }

            public override bool IsFirstPressed()
            {
                return _isFirstPressed;
            }

            public override bool IsFirstReleased()
            {
                return _isFirstReleased;
            }

            public override bool IsHeld()
            {
                return _isHeld;
            }

            public override bool IsReleased()
            {
                return !_isHeld && !_isFirstPressed;
            }
        }

        private class GamePadAnalogInput : Input
        {
            private float _pressedThresholdX;
            private float _pressedThresholdY;
            private bool _isFirstPressed;
            private bool _isPrevPressed;

            public GamePadAnalogInput(float pressedThresholdX, float pressedThresholdY)
            {
                _pressedThresholdX = pressedThresholdX;
                _pressedThresholdY = pressedThresholdY;
            }

            public override void PreCheck()
            {
                
            }
        }
    }
}
