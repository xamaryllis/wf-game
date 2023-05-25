using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameCore.TextObjects
{
    internal class AnimatedTextObject : TextlabelObject
    {
        int timeCount = 0;

        static readonly int PERIOD = 50;

        StringBuilder drawableText, textToDraw;

        public bool IsEnded { get => textToDraw.Length == 0; }
        
        public AnimatedTextObject(Vector2 position, float maxWidth, SpriteFont font, string text)
            : base(position, maxWidth, font, text)
        {
            textToDraw = new StringBuilder(this.text);
            drawableText = new StringBuilder(); this.text = "";
        }

        public void SkipAnimation()
        {
            drawableText.Append(textToDraw);
            textToDraw.Clear();
            text = drawableText.ToString();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Animate(gameTime); base.Draw(gameTime, spriteBatch);
        }
        public override void UpdateText(string newText, float maxWidth)
        {
            base.UpdateText(newText, maxWidth);

            textToDraw = new StringBuilder(text);
            drawableText = new StringBuilder(); text = "";
        }

        private void Animate(GameTime gameTime) 
        {
            timeCount += gameTime.ElapsedGameTime.Milliseconds;

            if (timeCount > PERIOD)
            {
                timeCount -= PERIOD;

                if (textToDraw.Length <= 0) return; 
                
                drawableText.Append(textToDraw[0]);
                textToDraw.Remove(0, 1);
                text = drawableText.ToString();
            }
        }
    }
}
