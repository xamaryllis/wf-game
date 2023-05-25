using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameScenes.HallRoom
{
    internal class SecurityTrigger : ITriggableDrawable
    {
        bool wasWatching;
        Security security;
        Point lastHeroPosition;
        
        public Callback Callback { get; set; }

        public SecurityTrigger(Security security)
        {
            this.security = security;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            => security.Draw(gameTime, spriteBatch);
        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (hitbox.X > Constants.WIDTH / 2) return;
            
            if (security.IsWatching && !wasWatching)
                lastHeroPosition = hitbox.Location;
            
            if (security.IsWatching) 
            {
                if (lastHeroPosition != hitbox.Location) Callback?.Invoke();
                lastHeroPosition = hitbox.Location;
            }
            wasWatching = security.IsWatching;
        }
    }
}
