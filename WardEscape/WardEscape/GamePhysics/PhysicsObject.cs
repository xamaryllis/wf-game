﻿using System;
using Microsoft.Xna.Framework;

using WardEscape.GameCore;

namespace WardEscape.GamePhysics
{
    internal class PhysicsObject : BaseObject
    {
        public Vector2 Velocity { get; set; }
        
        public PhysicsObject(Point position, Point size) 
            : base(position, size) 
        { }
        public PhysicsObject(Rectangle rectangle) 
            : base(rectangle) 
        { }
        
        public void MoveObject()
        {
            OffsetObject(Velocity);
        }
        public Vector2 SolveCollision(PhysicsObject physicsObj)
        {
            if (Hitbox.Intersects(physicsObj.Hitbox))
            {
                var xOffset = Math.Min(
                    Math.Abs(Hitbox.Left - physicsObj.Hitbox.Right),
                    Math.Abs(Hitbox.Right - physicsObj.Hitbox.Left)
                );

                var yOffset = Math.Min(
                    Math.Abs(Hitbox.Top - physicsObj.Hitbox.Bottom),
                    Math.Abs(Hitbox.Bottom - physicsObj.Hitbox.Top)
                );
                return xOffset < yOffset ? new(-xOffset, 0) : new(0, -yOffset);
            }
            return Vector2.Zero;
        }
        public Vector2 SolveCollision(Rectangle hitbox)
        {
            return SolveCollision(new PhysicsObject(hitbox));
        }
    }
}