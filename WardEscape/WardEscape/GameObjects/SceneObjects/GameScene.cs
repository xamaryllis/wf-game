using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GamePhysics;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameObjects.SceneObjects
{
    internal abstract class GameScene
    {
        protected Background background;
        protected List<IDrawableObject> drawableObjects;
        protected List<ITriggableObject> triggablesObjects;
        protected List<ITriggableDrawable> triggableDrawables;

        public GameScene(ContentManager content, SceneManager manager)
        {
            background = LoadBackground(content);
            drawableObjects = LoadDrawable(content);
            triggablesObjects = InitTriggers(manager);
            triggableDrawables = InitTriggableDrawable(content, manager);
        }

        protected abstract Background LoadBackground(ContentManager content);
        protected abstract List<ITriggableObject> InitTriggers(SceneManager manager);
        protected abstract List<IDrawableObject> LoadDrawable(ContentManager content);
        protected abstract List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager);

        public virtual void Update(GameTime gameTime, GameHero gameHero)
        {
            foreach (var trigger in triggablesObjects.ToArray())
            {
                trigger.Update(gameTime, gameHero.Hitbox);
            }

            foreach (var trigger in triggableDrawables.ToArray()) 
            {
                trigger.Update(gameTime, gameHero.Hitbox);
            }
            gameHero.Update(gameTime);
        }
        public virtual void DrawBackground(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background?.Draw(gameTime, spriteBatch);
        }
        public virtual void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch, GameHero gameHero)
        {
            foreach (var drawableObject in drawableObjects.ToArray())
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }

            foreach (var drawableObject in triggableDrawables.ToArray()) 
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }
            gameHero.Draw(gameTime, spriteBatch);
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
