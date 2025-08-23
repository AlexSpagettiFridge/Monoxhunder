using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monoxhunder.GameLoop
{
    public class InputHandler
    {
        private Dictionary<string, GeneralButton> configuredButtons = [];
        private KeyboardState currentKeyboardState, previousKeyboardState;
        private MouseState currentMouseState, previousMouseState;
        private Vector2 mouseSpeed;
        public Vector2 MouseSpeed => mouseSpeed;

        public InputHandler()
        {
            previousKeyboardState = new KeyboardState();
            currentKeyboardState = Keyboard.GetState();
            previousMouseState = new MouseState();
            currentMouseState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            Point deltaMouse = currentMouseState.Position - previousMouseState.Position;
            mouseSpeed = new Vector2(deltaMouse.X, deltaMouse.Y) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public bool IsKeyDown(string key) => IsButtonDown(key);

        public bool IsKeyJustPressed(string key)
        {
            return !WasButtonDown(key) && IsButtonDown(key);
        }

        public bool IsKeyJustReleased(string key)
        {
            return WasButtonDown(key) && !IsButtonDown(key);
        }

        public Point MousePosition => currentMouseState.Position;

        public void ConfigureButton(string name, Keys button) => ConfigureButton(name, new GeneralButton(button));
        public void ConfigureButton(string name, MouseButton button) => ConfigureButton(name, new GeneralButton(button));
        public void ConfigureButton(string name, GeneralButton button)
        {
            if (configuredButtons.ContainsKey(name))
            {
                configuredButtons[name] = button;
                return;
            }
            configuredButtons.Add(name, button);
        }

        private bool IsButtonDown(string name)
        {
            object button = configuredButtons[name].GetButton();
            if (button is MouseButton mouseButton)
            {
                switch (mouseButton)
                {
                    case MouseButton.Left: return currentMouseState.LeftButton == ButtonState.Pressed;
                    case MouseButton.Middle: return currentMouseState.MiddleButton == ButtonState.Pressed;
                    case MouseButton.Right: return currentMouseState.RightButton == ButtonState.Pressed;
                }
            }
            if (button is Keys keyboardButton)
            {
                return currentKeyboardState.IsKeyDown(keyboardButton);
            }
            //How does this happen?
            throw new Exception("GeneralButton is neither a mouse or keyboard button.");
        }

        private bool WasButtonDown(string name)
        {
            object button = configuredButtons[name].GetButton();
            if (button is MouseButton mouseButton)
            {
                switch (mouseButton)
                {
                    case MouseButton.Left: return previousMouseState.LeftButton == ButtonState.Pressed;
                    case MouseButton.Middle: return previousMouseState.MiddleButton == ButtonState.Pressed;
                    case MouseButton.Right: return previousMouseState.RightButton == ButtonState.Pressed;
                }
            }
            if (button is Keys keyboardButton)
            {
                return previousKeyboardState.IsKeyDown(keyboardButton);
            }
            //How does this happen?
            throw new Exception("GeneralButton is neither a mouse or keyboard button.");
        }
    }
}