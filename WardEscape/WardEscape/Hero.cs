using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;

namespace WardEscape
{
    internal class Hero
    {
        private Texture2D sprite;
        private const int velocity = 10;
        public int X { get; set; }
        public int Y { get; set; }

        public Hero(Texture2D sprite) 
        {
            this.sprite = sprite; 
        }
        public void Draw(SpriteBatch batch) 
        {
            batch.Draw(sprite, new Rectangle(X, Y, 736 / 6, 1808 / 6), Color.White);
        }

        public void Update() 
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A)) X -= velocity;

            if (keyboardState.IsKeyDown(Keys.D)) X += velocity;

            if (keyboardState.IsKeyDown(Keys.W)) Y -= velocity;

            if (keyboardState.IsKeyDown(Keys.S)) Y += velocity;
        }
    }
}
