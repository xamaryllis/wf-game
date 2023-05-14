﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace WardEscape.GameCore
{
    internal class AnimatedObject : DrawableObject
    {
        int animationCount = 0;
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
            if (gameTime.TotalGameTime.Ticks % Sprites.Count == 0) 
            {
                animationCount = (animationCount + 1) % Sprites.Count;
            }
            Sprite = Sprites[animationCount]; base.Draw(gameTime, spriteBatch);
        }
    }
}