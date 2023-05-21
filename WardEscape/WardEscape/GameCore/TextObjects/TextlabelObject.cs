using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameCore.TextObjects
{
    internal class TextlabelObject
    {
        protected string text;
        protected SpriteFont font;
        protected Vector2 position;

        public TextlabelObject(Vector2 position, float maxWidth, SpriteFont font, string text)
        {
            this.font = font;
            this.position = position;
            this.text = CutText(text, maxWidth, font);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }

        private static string CutText(string text, float maxWidth, SpriteFont font)
        {
            float currentLength = 0;
            StringBuilder builder = new(text);

            for (int i = 0; i < text.Length; i++)
            {
                if (currentLength >= maxWidth)
                {
                    currentLength = 0;
                    builder.Insert(i, "\n");
                }
                currentLength += font.MeasureString($"{text[i]}").X;
            }
            return builder.ToString();
        }
    }
}
