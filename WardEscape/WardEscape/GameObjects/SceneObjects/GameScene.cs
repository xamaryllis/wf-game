using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GamePhysics;

namespace WardEscape.GameObjects.SceneObjects
{
    internal abstract class GameScene
    {
        protected Background background;
        protected List<DrawableObject> drawableObjects;
        protected List<ITriggableObject> triggablesObjects;

        public GameScene(ContentManager content, SceneManager manager)
        {
            background = LoadBackground(content);
            drawableObjects = LoadDrawable(content);
            triggablesObjects = InitTriggers(manager);
        }

        protected abstract Background LoadBackground(ContentManager content);
        protected abstract List<DrawableObject> LoadDrawable(ContentManager content);
        protected abstract List<ITriggableObject> InitTriggers(SceneManager manager);


        public virtual void Update(GameTime gameTime, RectangleObject heroHitbox)
        {
            foreach (var trigger in triggablesObjects)
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
