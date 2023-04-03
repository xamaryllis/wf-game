using WardEscape.Core;

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.Objects
{
    internal abstract class GameScene
    {
        private List<DrawableInstance> drawableInstances;
        private List<ITriggableInstance> triggableInstances;

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var drawableInstance in drawableInstances) 
            {
                drawableInstance.Draw(gameTime, spriteBatch);
            } 
        }

        public virtual void Update(Rectangle hitbox)
        {
            foreach (var triggableInstance in triggableInstances)
            {
                triggableInstance.Update(hitbox);
            }
        }
    }
}
