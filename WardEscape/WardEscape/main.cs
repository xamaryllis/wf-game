using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WardEscape.GamePhysics;
using WardEscape.SpecialTypes;

namespace WardEscape
{
    class Base : DrawablePhysicsObject
    {
        public Base(Point position, Point size, Texture2D sprite) 
            : base(position, size, sprite)
        { }

        public void Update(GameTime gameTime) 
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A))
            {
                Velocity = new Vector2(-5, Velocity.Y);
            }

            if (state.IsKeyDown(Keys.D))
            {
                Velocity = new Vector2(5, Velocity.Y);
            }

            if (state.IsKeyDown(Keys.Space) && Velocity.Y == 0) 
            {
                Velocity = new Vector2(Velocity.X, -20);
            }
        }
    }
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Base _basic1;
        private Base _basic2;
        private Base _basic3;
        private Base _basic4;
        private PhysicsEngine _physicsEngine;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Color[] data1 = new Color[100 * 100];
            for (int i = 0; i < 100 * 100; i++) 
            {
                data1[i] = Color.Red;
            }
            Texture2D rect1 = new(GraphicsDevice, 100, 100); rect1.SetData(data1);

            Color[] data2 = new Color[1000 * 1000];
            for (int i = 0; i < 1000 * 1000; i++)
            {
                data2[i] = Color.Green;
            }
            Texture2D rect2 = new(GraphicsDevice, 1000, 1000); rect2.SetData(data2);

            _basic1 = new(new(250, 0), new(100, 100), rect1);
            
            _basic2 = new(new(0, 0), new(100, 1000), rect2);
            _basic3 = new(new(700, 0), new(100, 1000), rect2);
            _basic4 = new(new(-200, 400), new(1000, 1000), rect2);

            _physicsEngine = new(
                new List<Rectangle>() { _basic2.Hitbox, _basic3.Hitbox, _basic4.Hitbox }, 
                new List<PhysicsObject>() { _basic1 }
            );

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _basic1.Update(gameTime);
            _physicsEngine.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _basic1.Draw(gameTime, _spriteBatch);
            _basic2.Draw(gameTime, _spriteBatch);
            _basic3.Draw(gameTime, _spriteBatch);
            _basic4.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}