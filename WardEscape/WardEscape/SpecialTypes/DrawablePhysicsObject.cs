using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GamePhysics;

namespace WardEscape.SpecialTypes
{
    internal class DrawablePhysicsObject
    {
        #region AuxTypes
        private class DrawableObjectAux : DrawableObject
        {
            DrawablePhysicsObject drawablePhysicsPart;

            public DrawableObjectAux(RectangleObject hitbox, Texture2D sprite, DrawablePhysicsObject obj)
                : base(hitbox, sprite)
            {
                drawablePhysicsPart = obj;
            }

            public static implicit operator DrawablePhysicsObject(DrawableObjectAux obj)
            {
                return obj.drawablePhysicsPart;
            }
        }

        private class PhysicsObjectAux : PhysicsObject
        {
            DrawablePhysicsObject drawablePhysicsPart;

            public PhysicsObjectAux(RectangleObject hitbox, DrawablePhysicsObject obj)
                : base(hitbox)
            {
                drawablePhysicsPart = obj;
            }

            public static implicit operator DrawablePhysicsObject(PhysicsObjectAux obj)
            {
                return obj.drawablePhysicsPart;
            }
        }
        #endregion

        RectangleObject hitbox;
        PhysicsObjectAux physicsObject;
        DrawableObjectAux drawableObject;

        public DrawablePhysicsObject(Point position, Point size, Texture2D sprite)
        {
            hitbox = new(position, size);
            
            physicsObject = new(hitbox, this);
            drawableObject = new(hitbox, sprite, this);
        }

        public static implicit operator PhysicsObject(DrawablePhysicsObject obj)
        {
            return obj.physicsObject;
        }
        
        public static implicit operator DrawableObject(DrawablePhysicsObject obj)
        {
            return obj.drawableObject;
        }

        public Vector2 Velocity 
        { 
            get => physicsObject.Velocity; 
            set => physicsObject.Velocity = value;
        }
        public RectangleObject Hitbox { get => hitbox; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            => drawableObject.Draw(gameTime, spriteBatch);

        public void MoveObject()
            => physicsObject.MoveObject();

        public Vector2 SolveCollision(PhysicsObject physicsObj)
            => physicsObject.SolveCollision(physicsObj);

        public Vector2 SolveCollision(Rectangle hitbox)
            => physicsObject.SolveCollision(hitbox);
    }
}
