using Microsoft.Xna.Framework;

namespace WardEscape.GameCore.BaseObjects
{
    internal class BaseObject
    {
        RectangleObject hitbox;
        public RectangleObject Hitbox { get => hitbox; }

        public BaseObject(Point position, Point size)
        {
            hitbox = new RectangleObject(position, size);
        }
        public BaseObject(RectangleObject rectangleObject)
        {
            hitbox = rectangleObject;
        }

        public void OffsetObject(Vector2 offset) => hitbox.Offset(offset);
        public void MoveObjectTo(Point newLocation) => hitbox.Location = newLocation;
    }
}
