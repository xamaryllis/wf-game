using WardEscape.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WardEscape.Objects
{
    internal class Character : DrawableInstance
    {
        public Character(Point position, Vector2 size, Texture2D sprite) : base(position, size, sprite) { }

        public void Update() 
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W)) OffsetHitbox(0, -10);

            if (state.IsKeyDown(Keys.A)) OffsetHitbox(-10, 0);

            if (state.IsKeyDown(Keys.S)) OffsetHitbox(0, 10);

            if (state.IsKeyDown(Keys.D)) OffsetHitbox(10, 0);
        }

        public void MoveTo(Point point) => _hitbox.Location = point;

        public void OffsetHitbox(int x, int y) => MoveTo(_hitbox.Location + new Point(x, y));
    }
}
