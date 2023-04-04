using WardEscape.Utils;

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.Core
{
    internal abstract class GameScene : DrawableInstance
    {
        protected List<DrawableInstance> drawableInstances = new();
        protected List<ITriggableInstance> triggableInstances = new();

        protected GameScene(Texture2D sprite) 
            : base(Point.Zero, Constants.WINDOW, sprite)
        { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
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
