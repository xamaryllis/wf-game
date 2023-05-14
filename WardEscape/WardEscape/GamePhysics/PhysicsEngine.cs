using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WardEscape.GamePhysics
{
    internal class PhysicsEngine
    {
        List<Rectangle> gameBounds;
        List<PhysicsObject> physicsObjects;

        static Vector2 GRAVITY = new(0, 0.98f);

        public PhysicsEngine(List<Rectangle> gameBounds, List<PhysicsObject> physicsObjects)
        {
            this.gameBounds = gameBounds;
            this.physicsObjects = physicsObjects;
        }

        public void Update(GameTime gameTime) 
        {   
            foreach (var physicsObj in physicsObjects)
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
            if (collision.Y != 0) return Vector2.Zero; // Приоритет
            if (collision.X != 0) return new Vector2(0, obj.Velocity.Y);

            return obj.Velocity;
        }
        private Vector2 SolveCollisions(PhysicsObject physObj) 
        {
            Vector2 collision = Vector2.Zero;
            foreach (var gameBound in gameBounds) 
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
