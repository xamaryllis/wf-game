using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameCore.TextObjects
{
    internal class AnimatedTextObject : TextlabelObject
    {
        StringBuilder drawableText, textToDraw;
        public AnimatedTextObject(Vector2 position, float maxWidth, SpriteFont font, string text)
            : base(position, maxWidth, font, text)
        {
            drawableText = new StringBuilder();
            textToDraw = new StringBuilder(this.text);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (textToDraw.Length > 0)
            {
                drawableText.Append(textToDraw[0]);
                textToDraw.Remove(0, 1);
                text = drawableText.ToString();
            }
            base.Draw(gameTime, spriteBatch);
        }
    }
}
