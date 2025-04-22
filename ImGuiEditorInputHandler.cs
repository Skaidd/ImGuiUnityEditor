using UnityEngine;
using System;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Handles Input events for the ImGui in Unity Editor.
    /// </summary>
    public class ImGuiEditorInputHandler : ImGuiRendererInputHandler
    {
        private readonly int _controlID;

        public ImGuiEditorInputHandler()
        {
            _controlID = GUIUtility.GetControlID(FocusType.Passive);
        }

        public override void MousePosition(Action<Vector2> mousePositionAction)
        {
            Event e = Event.current;
            if (e != null)
            {
                bool hasFocus = GUIUtility.hotControl == 0 || GUIUtility.hotControl == _controlID;

                if (hasFocus)
                {
                    mousePositionAction?.Invoke(e.mousePosition);
                }
                else
                {
                    ImGui.SetWindowFocus((string)null);
                }
            }
        }

        public override void MouseButton(Action<int, bool> mouseButtonAction)
        {
            Event e = Event.current;
            if (e != null)
            {
                bool hasFocus = GUIUtility.hotControl == 0 || GUIUtility.hotControl == _controlID;

                if (IO.WantCaptureMouse && hasFocus)
                {
                    if (e.type == EventType.MouseDown)
                    {
                        GUIUtility.hotControl = _controlID;
                        mouseButtonAction?.Invoke(e.button, true);
                        e.Use();
                    }
                    else if (e.type == EventType.MouseUp)
                    {
                        if (GUIUtility.hotControl == _controlID)
                        {
                            GUIUtility.hotControl = 0;
                        }
                        mouseButtonAction?.Invoke(e.button, false);
                        e.Use();
                    }
                    else if (e.type == EventType.MouseLeaveWindow)
                    {
                        mouseButtonAction?.Invoke(e.button, false);
                        if (GUIUtility.hotControl == _controlID)
                        {
                            GUIUtility.hotControl = 0;
                        }
                        e.Use();
                    }
                }
            }
        }

        public override void MouseScrollDelta(Action<Vector2> mouseScrollDeltaAction)
        {
            Event e = Event.current;
            bool hasFocus = GUIUtility.hotControl == 0 || GUIUtility.hotControl == _controlID;

            if (e != null && e.type == EventType.ScrollWheel && IO.WantCaptureMouse && hasFocus)
            {
                mouseScrollDeltaAction?.Invoke(new Vector2(0f, -e.delta.y * 0.3f));
                e.Use();
            }
        }

        public override void InputCharacter(Action<char> inputCharacterAction)
        {
            Event e = Event.current;
            bool hasFocus = GUIUtility.hotControl == 0 || GUIUtility.hotControl == _controlID;

            if (e != null && e.type == EventType.KeyDown && IO.WantCaptureKeyboard && hasFocus)
            {
                if (e.character != 0 && !char.IsControl(e.character))
                {
                    inputCharacterAction?.Invoke(e.character);
                    e.Use();
                }
            }
        }

        public override void KeyModifiers(Action<bool, bool, bool, bool> keyModifiersAction)
        {
            Event e = Event.current;
            if (e != null)
            {
                keyModifiersAction?.Invoke(e.control, e.shift, e.alt, e.command);
            }
        }

        public override void ProcessKeyEvents(Action<ImGuiKey, bool> keyAction)
        {
            Event e = Event.current;
            bool hasFocus = GUIUtility.hotControl == 0 || GUIUtility.hotControl == _controlID;

            if (e != null && (e.type == EventType.KeyDown || e.type == EventType.KeyUp) && IO.WantCaptureKeyboard && hasFocus)
            {
                bool keyDown = e.type == EventType.KeyDown;

                if (keyDown && GUIUtility.keyboardControl != _controlID)
                {
                    GUIUtility.keyboardControl = _controlID;
                }

                ImGuiKey key = KeycodeToImGuiKey(e.keyCode);
                if (key != ImGuiKey.None)
                {
                    keyAction?.Invoke(key, keyDown);
                    e.Use();
                }
            }
        }

        private ImGuiKey KeycodeToImGuiKey(KeyCode keyCode)
        {
            return keyCode switch
            {
                KeyCode.A => ImGuiKey.A,
                KeyCode.B => ImGuiKey.B,
                KeyCode.C => ImGuiKey.C,
                KeyCode.D => ImGuiKey.D,
                KeyCode.E => ImGuiKey.E,
                KeyCode.F => ImGuiKey.F,
                KeyCode.G => ImGuiKey.G,
                KeyCode.H => ImGuiKey.H,
                KeyCode.I => ImGuiKey.I,
                KeyCode.J => ImGuiKey.J,
                KeyCode.K => ImGuiKey.K,
                KeyCode.L => ImGuiKey.L,
                KeyCode.M => ImGuiKey.M,
                KeyCode.N => ImGuiKey.N,
                KeyCode.O => ImGuiKey.O,
                KeyCode.P => ImGuiKey.P,
                KeyCode.Q => ImGuiKey.Q,
                KeyCode.R => ImGuiKey.R,
                KeyCode.S => ImGuiKey.S,
                KeyCode.T => ImGuiKey.T,
                KeyCode.U => ImGuiKey.U,
                KeyCode.V => ImGuiKey.V,
                KeyCode.W => ImGuiKey.W,
                KeyCode.X => ImGuiKey.X,
                KeyCode.Y => ImGuiKey.Y,
                KeyCode.Z => ImGuiKey.Z,
                KeyCode.Alpha0 => ImGuiKey.Key0,
                KeyCode.Alpha1 => ImGuiKey.Key1,
                KeyCode.Alpha2 => ImGuiKey.Key2,
                KeyCode.Alpha3 => ImGuiKey.Key3,
                KeyCode.Alpha4 => ImGuiKey.Key4,
                KeyCode.Alpha5 => ImGuiKey.Key5,
                KeyCode.Alpha6 => ImGuiKey.Key6,
                KeyCode.Alpha7 => ImGuiKey.Key7,
                KeyCode.Alpha8 => ImGuiKey.Key8,
                KeyCode.Alpha9 => ImGuiKey.Key9,
                KeyCode.Keypad0 => ImGuiKey.Keypad0,
                KeyCode.Keypad1 => ImGuiKey.Keypad1,
                KeyCode.Keypad2 => ImGuiKey.Keypad2,
                KeyCode.Keypad3 => ImGuiKey.Keypad3,
                KeyCode.Keypad4 => ImGuiKey.Keypad4,
                KeyCode.Keypad5 => ImGuiKey.Keypad5,
                KeyCode.Keypad6 => ImGuiKey.Keypad6,
                KeyCode.Keypad7 => ImGuiKey.Keypad7,
                KeyCode.Keypad8 => ImGuiKey.Keypad8,
                KeyCode.Keypad9 => ImGuiKey.Keypad9,
                KeyCode.KeypadDivide => ImGuiKey.KeypadDivide,
                KeyCode.KeypadMultiply => ImGuiKey.KeypadMultiply,
                KeyCode.KeypadMinus => ImGuiKey.KeypadSubtract,
                KeyCode.KeypadPlus => ImGuiKey.KeypadAdd,
                KeyCode.KeypadPeriod => ImGuiKey.KeypadDecimal,
                KeyCode.KeypadEnter => ImGuiKey.KeypadEnter,
                KeyCode.F1 => ImGuiKey.F1,
                KeyCode.F2 => ImGuiKey.F2,
                KeyCode.F3 => ImGuiKey.F3,
                KeyCode.F4 => ImGuiKey.F4,
                KeyCode.F5 => ImGuiKey.F5,
                KeyCode.F6 => ImGuiKey.F6,
                KeyCode.F7 => ImGuiKey.F7,
                KeyCode.F8 => ImGuiKey.F8,
                KeyCode.F9 => ImGuiKey.F9,
                KeyCode.F10 => ImGuiKey.F10,
                KeyCode.F11 => ImGuiKey.F11,
                KeyCode.F12 => ImGuiKey.F12,
                KeyCode.LeftArrow => ImGuiKey.LeftArrow,
                KeyCode.RightArrow => ImGuiKey.RightArrow,
                KeyCode.UpArrow => ImGuiKey.UpArrow,
                KeyCode.DownArrow => ImGuiKey.DownArrow,
                KeyCode.PageUp => ImGuiKey.PageUp,
                KeyCode.PageDown => ImGuiKey.PageDown,
                KeyCode.Home => ImGuiKey.Home,
                KeyCode.End => ImGuiKey.End,
                KeyCode.Insert => ImGuiKey.Insert,
                KeyCode.Delete => ImGuiKey.Delete,
                KeyCode.Tab => ImGuiKey.Tab,
                KeyCode.Backspace => ImGuiKey.Backspace,
                KeyCode.Space => ImGuiKey.Space,
                KeyCode.Return => ImGuiKey.Enter,
                KeyCode.Escape => ImGuiKey.Escape,
                KeyCode.LeftControl => ImGuiKey.LeftCtrl,
                KeyCode.RightControl => ImGuiKey.RightCtrl,
                KeyCode.LeftShift => ImGuiKey.LeftShift,
                KeyCode.RightShift => ImGuiKey.RightShift,
                KeyCode.LeftAlt => ImGuiKey.LeftAlt,
                KeyCode.RightAlt => ImGuiKey.RightAlt,
                KeyCode.LeftCommand => ImGuiKey.LeftSuper,
                KeyCode.RightCommand => ImGuiKey.RightSuper,
                KeyCode.Menu => ImGuiKey.Menu,
                KeyCode.Comma => ImGuiKey.Comma,
                KeyCode.Period => ImGuiKey.Period,
                KeyCode.Slash => ImGuiKey.Slash,
                KeyCode.Minus => ImGuiKey.Minus,
                KeyCode.Equals => ImGuiKey.Equal,
                KeyCode.LeftBracket => ImGuiKey.LeftBracket,
                KeyCode.RightBracket => ImGuiKey.RightBracket,
                KeyCode.Backslash => ImGuiKey.Backslash,
                KeyCode.Semicolon => ImGuiKey.Semicolon,
                KeyCode.Quote => ImGuiKey.Apostrophe,
                KeyCode.BackQuote => ImGuiKey.GraveAccent,
                KeyCode.Print => ImGuiKey.PrintScreen,
                KeyCode.ScrollLock => ImGuiKey.ScrollLock,
                KeyCode.Pause => ImGuiKey.Pause,
                KeyCode.Numlock => ImGuiKey.NumLock,
                KeyCode.CapsLock => ImGuiKey.CapsLock,
                _ => ImGuiKey.None,
            };
        }
    }
}