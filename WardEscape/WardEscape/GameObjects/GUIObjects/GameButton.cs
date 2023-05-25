using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.SpecialTypes;
using WardEscape.GameCore.TextObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class GameButton : DrawableClickableObject
    {
        protected TextlabelObject TextObject { get; set; }
        
        public GameButton(Point position, Point size, string text, ContentManager content)
            : base(position, size, content.Load<Texture2D>("GuiElements/Button")) 
        {
            TextObject = InitTextlabel(position, size, text, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            TextObject.Draw(gameTime, spriteBatch);
        }

        private static TextlabelObject InitTextlabel(Point btnPos, Point btnSize, string text, ContentManager content) 
        {
            SpriteFont font = content.Load<SpriteFont>("Fonts/ButtonFont");
            
            Point textSize = font.MeasureString(text).ToPoint();
            Point textPosition = new((btnSize.X - textSize.X) / 2, (btnSize.Y - textSize.Y) / 2);

            return new((textPosition + btnPos).ToVector2(), textSize.X, font, text);
        }
    }
}
