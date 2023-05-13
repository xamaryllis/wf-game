using Microsoft.Xna.Framework;

namespace WardEscape.GameCore
{
    internal class BaseObject
    {
        public Rectangle Hitbox { get; protected set; }
        
        public BaseObject(Rectangle hitbox)
        {
            Hitbox = hitbox;
        }
        public BaseObject(Point position, Point size) 
        {
            Hitbox = new Rectangle(position, size);
        }

        public void OffsetObject(Vector2 offset) 
        {
            Rectangle hitbox = Hitbox;
            hitbox.Offset(offset); Hitbox = hitbox;
        }
    }
}
