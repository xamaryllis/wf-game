using Microsoft.Xna.Framework;

namespace WardEscape.GameCore
{
    internal interface ITriggableObject
    {
        public void Update(GameTime gameTime, RectangleObject hitbox);
    }
}
