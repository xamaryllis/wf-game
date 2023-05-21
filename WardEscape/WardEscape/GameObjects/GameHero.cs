﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using WardEscape.GameCore.BaseObjects;
using WardEscape.SpecialTypes;


namespace WardEscape.GameObjects
{
    internal class GameHero : AnimatedPhysicsObject
    {
        #region AuxOverride
        protected class AnimatedHeroAux : AnimatedObjectAux
        {
            public AnimatedHeroAux(RectangleObject Hitbox, List<Texture2D> sprites, AnimatedPhysicsObject obj) 
                : base(Hitbox, sprites, obj)
            { }

            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                Animate(gameTime);
            }

            public Texture2D HeroSprite 
            { 
                get => Sprite; 
                set => Sprite = value; 
            }
        }
        #endregion

        #region CreationHooks
        protected override AnimatedObjectAux AnimatedAux(RectangleObject hitbox, List<Texture2D> sprites, AnimatedPhysicsObject obj)
        {
            return new AnimatedHeroAux(hitbox, sprites, this);
        }
        #endregion

        static int MOVE_SPEED = 5;
        static int JUMP_SPEED = -15;
        static Point SIZE = new Point(81, 200);
        SpriteEffects rotation = SpriteEffects.None;

        public GameHero(ContentManager content, Point position) 
            : base(position, SIZE, LoadSprites(content))
        { }

        public void Update(GameTime gameTime)
        {
            var keyboarState = Keyboard.GetState();

            if (keyboarState.IsKeyDown(Keys.A))
            {
                rotation = SpriteEffects.FlipHorizontally;
                Velocity = new Vector2(-MOVE_SPEED, Velocity.Y);
            }
                
            if (keyboarState.IsKeyDown(Keys.D)) 
            {
                rotation = SpriteEffects.None;
                Velocity = new Vector2(MOVE_SPEED, Velocity.Y);
            }
                
            if (keyboarState.IsKeyDown(Keys.Space) && Velocity.Y == 0)
                Velocity = new Vector2(Velocity.X, JUMP_SPEED);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            AnimatedHeroAux aux = (AnimatedHeroAux)animatedObject;
            spriteBatch.Draw(aux.HeroSprite, Hitbox, null, Color.White, 0, Vector2.Zero, rotation, 0);
        }

        private static List<Texture2D> LoadSprites(ContentManager content) 
        {
            
            List<Texture2D> sprites = new()
            {
                content.Load<Texture2D>("GameHero/Edna_1"),
                content.Load<Texture2D>("GameHero/Edna_2"),
                content.Load<Texture2D>("GameHero/Edna_1"),
            };
            return sprites;
        }
    }
}
