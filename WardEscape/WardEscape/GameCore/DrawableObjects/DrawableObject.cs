using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameCore.DrawableObjects
{
    internal class DrawableObject : BaseObject, IDrawableObject
    {
        protected Texture2D Sprite { get; set; }

        public DrawableObject(Point position, Point size, Texture2D sprite)
            : base(position, size)
        {
            Sprite = sprite;
        }
        public DrawableObject(RectangleObject rectangleObject, Texture2D sprite)
            : base(rectangleObject)
        {
            Sprite = sprite;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Sprite == null) return;
            spriteBatch.Draw(Sprite, Hitbox, Color.White);
        }
    }
}
