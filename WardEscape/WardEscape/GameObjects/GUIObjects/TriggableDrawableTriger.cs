using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class TriggableDrawableTriger : ITriggableDrawable
    {
        bool isVisible = false;
        
        private DrawableObject Drawable { get; set; }
        public ITriggableDrawable TriggableDrawable { get; set; }
        public Callback Callback 
        {
            get => TriggableDrawable.Callback; 
            set => TriggableDrawable.Callback = value; 
        }

        public TriggableDrawableTriger(DrawableObject drawable) 
        {
            Drawable = drawable;
        }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            isVisible = Drawable.Hitbox.Intersects(hitbox);

            if (isVisible) TriggableDrawable?.Update(gameTime, hitbox);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Drawable.Draw(gameTime, spriteBatch);
            
            if (isVisible) TriggableDrawable?.Draw(gameTime, spriteBatch);
        }
    }
}
