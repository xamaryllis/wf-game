using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.TextObjects;
using WardEscape.GameObjects.GUIObjects;

namespace WardEscape.GameScenes.GameMenu
{
    internal class StartButton : GameButton
    {
        public StartButton(Point position, Point size, string text, ContentManager content) 
            : base(position, size, text, content)
        {
            TextObject = InitTextlabel(position, size, text, content);
        }

        private static TextlabelObject InitTextlabel(Point btnPos, Point btnSize, string text, ContentManager content)
        {
            SpriteFont font = content.Load<SpriteFont>("Fonts/MenuFont");

            Point textSize = font.MeasureString(text).ToPoint();
            Point textPosition = new((btnSize.X - textSize.X) / 2, (btnSize.Y - textSize.Y) / 2);

            return new((textPosition + btnPos).ToVector2(), textSize.X, font, text);
        }
    }
}
