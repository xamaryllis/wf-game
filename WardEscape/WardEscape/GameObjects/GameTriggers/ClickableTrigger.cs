using Microsoft.Xna.Framework;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameObjects.GameTriggers
{
    internal class ClickableTrigger : BaseObject, ITriggableObject
    {
        public Callback Callback { get; set; }

        public ClickableTrigger(Point position, Point size)
            : base(position, size)
        { }
        public ClickableTrigger(RectangleObject rectangleObject)
            : base(rectangleObject)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(MouseStateObject.GetHitbox()))
            {
                if (MouseStateObject.IsClicked()) Callback?.Invoke();
            }
        }
    }
}
