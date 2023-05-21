using Microsoft.Xna.Framework;
using System.Collections.Generic;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GamePhysics
{
    internal class PhysicsEngine
    {
        static Vector2 GRAVITY = new(0, 0.98f);

        public List<RectangleObject> GameBounds { get; set; }
        public List<PhysicsObject> PhysicsObjects { get; set; }

        public PhysicsEngine(List<RectangleObject> gameBounds, List<PhysicsObject> physicsObjects)
        {
            GameBounds = gameBounds;
            PhysicsObjects = physicsObjects;
        }

        public void Update(GameTime gameTime) 
        {   
            foreach (var physicsObj in PhysicsObjects)
            {
                Gravity(physicsObj);

                var collision = SolveCollisions(physicsObj);
                physicsObj.MoveObject(collision);

                physicsObj.Velocity = UpdateVelocity(physicsObj, collision);
            }
        }
        
        private void Gravity(PhysicsObject physObj) 
        {
            physObj.Velocity += GRAVITY;
            physObj.MoveObject();
        }
        private Vector2 UpdateVelocity(PhysicsObject obj, Vector2 collision) 
        {
            if (collision.Y > 0) return GRAVITY;
            if (collision.Y < 0) return Vector2.Zero;
            if (collision.X != 0) return new Vector2(0, obj.Velocity.Y);

            return obj.Velocity;
        }
        private Vector2 SolveCollisions(PhysicsObject physObj) 
        {
            Vector2 collision = Vector2.Zero;
            foreach (var gameBound in GameBounds) 
            {
                Vector2 solve = physObj.SolveCollision(gameBound);

                if (physObj.Velocity.X < 0) solve.X *= -1;
                if (physObj.Velocity.Y < 0) solve.Y *= -1;

                collision += solve;
            }
            return collision;
        }
    }
}
