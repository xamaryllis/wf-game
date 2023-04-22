using WardEscape.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WardEscape.Objects
{
    internal class Character : DrawableInstance
    {
        SpriteEffects rotation = SpriteEffects.None;
        public Character(Point position, Vector2 size, Texture2D sprite) : base(position, size, sprite) { }

        public void Update() 
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A))
            { 
                OffsetHitbox(-8, 0);
                rotation = SpriteEffects.FlipHorizontally;
            }

            if (state.IsKeyDown(Keys.D)) 
            {
                OffsetHitbox(8, 0);
                rotation = SpriteEffects.None;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Hitbox, null, Color.White, 0, Vector2.Zero, rotation, 0);
        }

        public void MoveTo(Point point) => _hitbox.Location = point;

        public void OffsetHitbox(int x, int y) => MoveTo(_hitbox.Location + new Point(x, y));
    }
}
