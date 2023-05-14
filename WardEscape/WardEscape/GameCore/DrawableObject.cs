using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameCore
{
    internal class DrawableObject : BaseObject
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
            spriteBatch.Begin();
            spriteBatch.Draw(Sprite, Hitbox, Color.White);
            spriteBatch.End();
        }
    }
}
