using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GamePhysics;

namespace WardEscape.SpecialTypes
{
    internal class AnimatedPhysicsObject
    {
        #region AuxTypes
        protected class AnimatedObjectAux : AnimatedObject
        {
            AnimatedPhysicsObject animatedPhysicsPart;

            public AnimatedObjectAux(RectangleObject hitbox, List<Texture2D> sprite, AnimatedPhysicsObject obj)
                : base(hitbox, sprite)
            {
                animatedPhysicsPart = obj;
            }

            public static implicit operator AnimatedPhysicsObject(AnimatedObjectAux obj)
            {
                return obj.animatedPhysicsPart;
            }

            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
                => base.Draw(gameTime, spriteBatch);
        }

        protected class PhysicsObjectAux : PhysicsObject
        {
            AnimatedPhysicsObject animatedPhysicsPart;

            public PhysicsObjectAux(RectangleObject hitbox, AnimatedPhysicsObject obj)
                : base(hitbox)
            {
                animatedPhysicsPart = obj;
            }

            public static implicit operator AnimatedPhysicsObject(PhysicsObjectAux obj)
            {
                return obj.animatedPhysicsPart;
            }
        }
        #endregion

        protected RectangleObject hitbox;
        protected PhysicsObjectAux physicsObject;
        protected AnimatedObjectAux animatedObject;

        #region CreationHooks
        protected virtual PhysicsObjectAux PhysicsAux(RectangleObject hitbox)
        {
            return new(hitbox, this);
        }
        protected virtual AnimatedObjectAux AnimatedAux(RectangleObject hitbox, List<Texture2D> sprites)
        {
            return new(hitbox, sprites, this);
        }
        #endregion

        public AnimatedPhysicsObject(Point position, Point size, List<Texture2D> sprites)
        {
            hitbox = new(position, size);

            physicsObject = PhysicsAux(hitbox);
            animatedObject = AnimatedAux(hitbox, sprites);
        }

        public static implicit operator PhysicsObject(AnimatedPhysicsObject obj)
        {
            return obj.physicsObject;
        }

        public static implicit operator AnimatedObject(AnimatedPhysicsObject obj)
        {
            return obj.animatedObject;
        }

        public Vector2 Velocity
        {
            get => physicsObject.Velocity;
            set => physicsObject.Velocity = value;
        }
        public RectangleObject Hitbox { get => hitbox; }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            => animatedObject.Draw(gameTime, spriteBatch);

        public void MoveObject()
            => physicsObject.MoveObject();
        public void MoveObjectTo(Point newLocation)
            => physicsObject.MoveObjectTo(newLocation);
        public void MoveObject(Vector2 vector)
            => physicsObject.MoveObject(vector);
        public Vector2 SolveCollision(PhysicsObject physicsObj)
            => physicsObject.SolveCollision(physicsObj);
        public Vector2 SolveCollision(Rectangle hitbox)
            => physicsObject.SolveCollision(hitbox);
    }
}
