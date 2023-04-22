using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.Core
{
    internal abstract class DrawableInstance
    {
        protected Rectangle _hitbox;
        public Rectangle Hitbox => _hitbox;

        protected Texture2D Sprite { get; set; }

        public DrawableInstance(Point position, Vector2 size, Texture2D sprite)
        {
            Sprite = sprite;
            _hitbox = new Rectangle(position, size.ToPoint());
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Hitbox, Color.White);
        }
    }
}
