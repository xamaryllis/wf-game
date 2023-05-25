using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.TextObjects;

using WardEscape.SpecialTypes;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class GameDialog : DrawableClickableObject
    {
        Queue<string> dialogs;
        static readonly int PADDING = 10;

        AnimatedTextObject TextObject { get; set; }
        
        public GameDialog(Point position, Point size, Queue<string> dialogs, ContentManager content) 
            : base(position, size, content.Load<Texture2D>("GuiElements/Dialog"))
        {
            this.dialogs = dialogs;

            TextObject = InitTextlabel(position, dialogs.Dequeue(), content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            TextObject.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(MouseStateObject.GetHitbox()))
            {
                if (!MouseStateObject.IsClicked()) return;

                if (!TextObject.IsEnded)
                {
                    TextObject.SkipAnimation();
                }
                else if (dialogs.Count != 0)
                {
                    TextObject.UpdateText(dialogs.Dequeue(), Hitbox.Width - 2 * PADDING);
                }
                else Callback?.Invoke();
            }
        }

        private AnimatedTextObject InitTextlabel(Point labelPos, string text, ContentManager content)
        {
            Point textPosition = new(labelPos.X + PADDING, labelPos.Y);
            SpriteFont font = content.Load<SpriteFont>("Fonts/DialogFont");

            return new(textPosition.ToVector2(), Hitbox.Width - 2 * PADDING, font, text);
        }
    }
}
