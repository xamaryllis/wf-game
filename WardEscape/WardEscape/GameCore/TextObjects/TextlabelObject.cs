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
        public virtual void UpdateText(string newText, float maxWidth) 
        {
            text = CutText(newText, maxWidth, font);
        }

        private static string CutText(string text, float maxWidth, SpriteFont font)
        {
            float currentLength = 0;
            StringBuilder builder = new();
            string[] splitedText = text.Split(" ");

            for (int i = 0; i < splitedText.Length; i++)
            {
                string textToAdd = splitedText[i];
                if (splitedText.Length != i + 1) textToAdd += " ";
                
                float delta = font.MeasureString(textToAdd).X;
                
                if (currentLength + delta > maxWidth)
                {
                    currentLength = 0; builder.Append("\n");
                }
                builder.Append(textToAdd); currentLength += delta;
            }
            return builder.ToString();
        }
    }
}
