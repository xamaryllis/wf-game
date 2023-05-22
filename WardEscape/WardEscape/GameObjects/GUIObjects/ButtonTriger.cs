using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class ButtonTriger : DrawableObject, ITriggableDrawable
    {
        bool isVisible = false;
        
        public GameButton GameButton { get; set; }
        
        public ButtonTriger(Point position, Point size, Texture2D sprite = null) 
            : base(position, size, sprite)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            isVisible = Hitbox.Intersects(hitbox);

            if (isVisible) GameButton?.Update(gameTime, hitbox);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Sprite != null) base.Draw(gameTime, spriteBatch);
            if (isVisible) GameButton?.Draw(gameTime, spriteBatch);
        }
    }
}
