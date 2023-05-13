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

                if (collision != Vector2.Zero) 
                {
                    physicsObj.Velocity = collision;
                    physicsObj.MoveObject(); 
                    physicsObj.Velocity = Vector2.Zero;
                }
            }
        }
        private void Gravity(PhysicsObject physObj) 
        {
            physObj.Velocity += GRAVITY;
            physObj.MoveObject();
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
