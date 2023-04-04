using WardEscape.Utils;
using WardEscape.Objects;
using WardEscape.Scenes;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WardEscape
{
    public class GameLoop : Game
    {
        private Character character;
        private SceneManager sceneManager = new SceneManager();

        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;
        public GameLoop()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = Constants.WIDTH;
            _graphics.PreferredBackBufferHeight = Constants.HEIGHT;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sceneManager.AddScene(StartingScene.NAME, new StartingScene(sceneManager, Content));
            character = new Character(Point.Zero, new Vector2(81, 200), Content.Load<Texture2D>("Character/Character1"));

            sceneManager.ChangeScene(StartingScene.NAME);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            sceneManager.Update(character.Hitbox); character.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            sceneManager.Draw(gameTime, _spriteBatch);
            character.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ChangeGameScene(Point characterPosition) { }
    }
}

