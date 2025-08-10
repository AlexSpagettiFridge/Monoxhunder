using Microsoft.Xna.Framework.Input;

namespace Monoxhunder.GameLoop
{
    public readonly struct GeneralButton
    {
        public readonly int Key;

        public GeneralButton(MouseButton mouseButton)
        {
            Key = (int)mouseButton;
        }

        public GeneralButton(Keys keyboardButton)
        {
            Key = (int)keyboardButton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return either <see cref="Keys"/> or <see cref="MouseButton"/>.</returns>
        public object GetButton()
        {
            if (Key < 0)
            {
                return (MouseButton)Key;
            }
            return (Keys)Key;
        }
    }
}