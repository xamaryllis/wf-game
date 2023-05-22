using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameCore.BaseObjects
{
    internal interface IDrawableObject
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
