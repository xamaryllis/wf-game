﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GamePhysics;
using WardEscape.GameTriggers;

namespace WardEscape.GameObjects
{
    internal abstract class GameScene
    {
        protected Background background;
        protected List<SceneTrigger> sceneTriggers;
        protected List<DrawableObject> drawableObjects;

        public string SceneName { get; protected set; }

        public virtual void Update(GameTime gameTime, RectangleObject heroHitbox) 
        {
            foreach(var trigger in sceneTriggers) 
            {
                trigger.Update(heroHitbox);
            }
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            background?.Draw(gameTime, spriteBatch);
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
