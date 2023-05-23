using Microsoft.Xna.Framework;

namespace WardEscape.GameCore.BaseObjects
{
    delegate void Callback();
    internal interface ITriggableObject
    {
        public Callback Callback { get; set; }
        public void Update(GameTime gameTime, RectangleObject hitbox);
    }
}
