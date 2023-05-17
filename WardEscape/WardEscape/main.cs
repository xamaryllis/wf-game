using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameScenes;

namespace WardEscape
{
    public class Main : Game
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        SpriteFont font;

        private GameHero gameHero;
        private SceneManager sceneManager;

        public Main()
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
            gameHero = new GameHero(Content, new Point(1000, 50));

            font = Content.Load<SpriteFont>("Font");

            sceneManager = new SceneManager(gameHero);
            sceneManager.AddGameScene(new HallScene(Content, sceneManager), HallScene.NAME);
            sceneManager.AddGameScene(new StairsScene(Content, sceneManager), StairsScene.NAME);
            sceneManager.AddGameScene(new StartingScene(Content, sceneManager), StartingScene.NAME);
            
            sceneManager.SetGameScene(StairsScene.NAME);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sceneManager.Update(gameTime); base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            sceneManager.Draw(gameTime, _spriteBatch);
            _spriteBatch.DrawString(font, "Hello\nWorld!", new Vector2(100, 100), Color.Black);
            var res = font.MeasureString("Hello world!");
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}