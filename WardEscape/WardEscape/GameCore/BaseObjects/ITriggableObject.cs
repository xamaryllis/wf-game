using Microsoft.Xna.Framework;

namespace WardEscape.GameCore.BaseObjects
{
    internal interface ITriggableObject
    {
        public void Update(GameTime gameTime, RectangleObject hitbox);
    }
}
