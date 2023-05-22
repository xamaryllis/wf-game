using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.TextObjects;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    delegate void Callback();
    internal class GameButton : DrawableObject, ITriggableObject
    {
        public Callback Callback { get; set; }
        TextlabelObject TextObject { get; set; }
        
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
        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(MouseStateObject.GetHitbox()))
            {
                if (MouseStateObject.IsClicked()) Callback();
            }
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
