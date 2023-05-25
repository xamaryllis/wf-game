using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.TextObjects;
using WardEscape.GameCore.DrawableObjects;

using WardEscape.SpecialTypes;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class ItemOverlay : DrawableClickableObject
    {
        static Point Position
        {
            get => new((Constants.WIDTH - SIZE.X) / 2, (Constants.HEIGHT - SIZE.Y) / 2);
        }
        static readonly int PADDING = 20;
        static readonly Point SIZE = new(400, 400);
        static readonly Point ITEMSIZE = new(250, 210);

        DrawableObject Item { get; set; }
        TextlabelObject Textlabel { get; set; }
        TransperentBackground Background { get; set; }

        public ItemOverlay(string itemName, Texture2D sprite, ContentManager content)
            : base(Position, SIZE, content.Load<Texture2D>("GuiElements/Item"))
        {
            Item = InitItem(sprite);
            Background = InitBackground(content);
            Textlabel = InitLabel(itemName, content);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Background.Draw(gameTime, spriteBatch);
            base.Draw(gameTime, spriteBatch);
            Item.Draw(gameTime, spriteBatch);
            Textlabel.Draw(gameTime, spriteBatch);
        }

        private static DrawableObject InitItem(Texture2D sprite) 
        {
            int x = (SIZE.X - ITEMSIZE.X) / 2;
            int y = (SIZE.Y - ITEMSIZE.Y) / 2;
            
            return new(new Point(x, y - PADDING) + Position, ITEMSIZE, sprite);
        }
        private static TextlabelObject InitLabel(string itemName, ContentManager content)
        {
            SpriteFont font = content.Load<SpriteFont>("Fonts/ItemFont");

            int y = (SIZE.Y + ITEMSIZE.Y) / 2;
            int x = (SIZE.X - (int)font.MeasureString(itemName).X) / 2;

            Point textPosition = new Point(x, y - PADDING) + Position;

            return new(textPosition.ToVector2(), font.MeasureString(itemName).X, font, itemName);
        }
        private static TransperentBackground InitBackground(ContentManager content) 
        {
            return new(content.Load<Texture2D>("GuiElements/Overlay"));
        }
    }
}
