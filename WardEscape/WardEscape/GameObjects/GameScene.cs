using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GamePhysics;

namespace WardEscape.GameObjects
{
    internal abstract class GameScene
    {
        protected Background background;
        protected List<SceneTrigger> sceneTriggers = new();
        protected List<DrawableObject> drawableObjects = new();

        public virtual void Update(GameTime gameTime, RectangleObject heroHitbox) 
        {
            foreach(var trigger in sceneTriggers) 
            {
                trigger.Update(gameTime, heroHitbox);
            }
        }
        public virtual void DrawBackground(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            background?.Draw(gameTime, spriteBatch);
        }
        public virtual void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            foreach (var drawableObject in drawableObjects) 
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }
        }

        public virtual List<RectangleObject> GetAdditionalBounds() 
        {
            return new List<RectangleObject>();
        }
        public virtual List<PhysicsObject> GetAdditionalPhysicsObject()
        {
            return new List<PhysicsObject>();
        }
    }
}
