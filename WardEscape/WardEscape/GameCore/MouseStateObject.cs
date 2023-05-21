using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameCore
{
    internal static class MouseStateObject
    {
        private static MouseState currentState;
        private static MouseState previousState;
        
        public static void Update(GameTime gameTime) 
        {
            previousState = currentState;
            currentState = Mouse.GetState();
        }
        public static RectangleObject GetHitbox() 
        {
            return new(currentState.Position, Constants.MOUSE_SIZE);
        }
        public static bool IsClicked() 
        {
            bool prevPressed = previousState.LeftButton == ButtonState.Pressed;
            bool currReleased = currentState.LeftButton == ButtonState.Released;
            
            return prevPressed && currReleased;
        }
    }
}
