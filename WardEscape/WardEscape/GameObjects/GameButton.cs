using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WardEscape.GameCore;

namespace WardEscape.GameObjects
{
    delegate void Callback();
    internal class GameButton : DrawableObject
    {
        string text;
        SpriteFont font;
        Callback callback;
        Point textPosition;
        
        public GameButton(Point position, Point size, string text, Callback callback, ContentManager content) 
            : base(position, size, content.Load<Texture2D>("GuiElements/Button"))
        {
            this.text = text;
            this.callback = callback;
            font = content.Load<SpriteFont>("Font");
            
            Point textSize = font.MeasureString(text).ToPoint();
            textPosition = position + new Point((size.X - textSize.X) / 2, (size.Y - textSize.Y) / 2);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, text, textPosition.ToVector2(), Color.Black);
        }

        public void Update(GameTime gameTime) 
        {
            MouseState mouseState = Mouse.GetState();
            if (Hitbox.Intersects(new(mouseState.Position, Constants.MOUSE_SIZE))) 
            {
                if (mouseState.LeftButton == ButtonState.Pressed) callback();
            }
        }
    }
}
