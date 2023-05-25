using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameCore.DrawableObjects
{
    internal class AnimatedObject : DrawableObject
    {
        int timeCount = 0;
        int animationCount = 0;
        
        static readonly int PERIOD = 300;
        
        List<Texture2D> Sprites { get; set; }

        public AnimatedObject(Point position, Point size, List<Texture2D> sprites)
            : base(position, size, sprites[0])
        {
            Sprites = sprites;
        }
        public AnimatedObject(RectangleObject rectangleObject, List<Texture2D> sprites)
            : base(rectangleObject, sprites[0])
        {
            Sprites = sprites;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Animate(gameTime); base.Draw(gameTime, spriteBatch);
        }
        protected void Animate(GameTime gameTime)
        {
            timeCount += gameTime.ElapsedGameTime.Milliseconds;

            if (timeCount > PERIOD) 
            {
                timeCount -= PERIOD;
                animationCount = (animationCount + 1) % Sprites.Count;
            }
            Sprite = Sprites[animationCount];
        }
    }
}
