using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameObjects
{
    internal class TransperentBackground : Background
    {
        public TransperentBackground(Texture2D sprite) 
            : base(sprite)
        { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Hitbox, Color.White * 0.5f);
        }
    }
}
