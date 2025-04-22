using UnityEngine;
using System;

namespace ImGuiUnityEditor
{
    /// <summary>
    /// Abstract class for handling ImGui input events.
    /// </summary>
    public abstract class ImGuiRendererInputHandler
    {
        public ImGuiIOPtr IO { get; private set; }

        private readonly Action<Vector2> _mousePositionDelegate;
        private readonly Action<int, bool> _mouseButtonDelegate;
        private readonly Action<Vector2> _mouseScrollDeltaDelegate;
        private readonly Action<ImGuiKey, bool> _keyEventDelegate;
        private readonly Action<char> _inputCharacterDelegate;
        private readonly Action<bool, bool, bool, bool> _keyModifiersDelegate;

        public ImGuiRendererInputHandler()
        {
            _mousePositionDelegate += (position) => IO.AddMousePosEvent(position.x, position.y);
            _mouseButtonDelegate += (button, isPressed) => IO.AddMouseButtonEvent(button, isPressed);
            _mouseScrollDeltaDelegate += (delta) => IO.AddMouseWheelEvent(delta.x, delta.y);
            _keyEventDelegate += (key, isPressed) => IO.AddKeyEvent(key, isPressed);
            _inputCharacterDelegate += (c) => IO.AddInputCharacter(c);
            _keyModifiersDelegate += (ctrl, shift, alt, super) =>
            {
                IO.KeyCtrl = ctrl;
                IO.KeyShift = shift;
                IO.KeyAlt = alt;
                IO.KeySuper = super;
            };
        }

        /// <summary>
        /// Sets the mouse position.
        /// </summary>
        /// <param name="mousePositionAction">The action to set the mouse position.</param>
        public abstract void MousePosition(Action<Vector2> mousePositionAction);

        /// <summary>
        /// Sets the mouse button.
        /// </summary>
        /// <param name="mouseButtonAction">The action to set the mouse button.</param>
        public abstract void MouseButton(Action<int, bool> mouseButtonAction);

        /// <summary>
        /// Sets the mouse scroll delta.
        /// </summary>
        /// <param name="mouseScrollDeltaAction">The action to set the mouse scroll delta.</param>
        public abstract void MouseScrollDelta(Action<Vector2> mouseScrollDeltaAction);

        /// <summary>
        /// Processes the key events.
        /// </summary>
        /// <param name="keyAction">The action to process the key events.</param>
        public abstract void ProcessKeyEvents(Action<ImGuiKey, bool> keyAction);

        /// <summary>
        /// Processes the input character.
        /// </summary>
        /// <param name="inputCharacterAction">The action to process the input character.</param>
        public abstract void InputCharacter(Action<char> inputCharacterAction);

        /// <summary>
        /// Sets the key modifiers.
        /// </summary>
        /// <param name="keyModifiersAction">The action to set the key modifiers.</param>
        public abstract void KeyModifiers(Action<bool, bool, bool, bool> keyModifiersAction);

        internal void SetIO(ImGuiIOPtr io)
        {
            IO = io;
        }
        
        internal void UpdateInput()
        {
            MousePosition(_mousePositionDelegate);
            MouseButton(_mouseButtonDelegate);
            MouseScrollDelta(_mouseScrollDeltaDelegate);

            ProcessKeyEvents(_keyEventDelegate);
            InputCharacter(_inputCharacterDelegate);
            KeyModifiers(_keyModifiersDelegate);
        }
    }
}