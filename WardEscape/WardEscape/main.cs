using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using WardEscape.GameCore;
using WardEscape.GameScenes;
using WardEscape.GameObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameScenes.HallRoom;

namespace WardEscape
{ 
    public class Main : Game
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        Texture2D rect1;

        private GameHero gameHero;
        private SceneManager sceneManager;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8
            };
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
            gameHero = new GameHero(Content, new Point(100, Constants.HEIGHT - 50));

            int width = 82;
            int height = 82;

            Color[] color = new Color[width * height];
            for (int i = 0; i < width * height; i++) 
            {
                color[i] = Color.Red;
            }
            rect1 = new(GraphicsDevice, width, height); rect1.SetData(color);

            sceneManager = new SceneManager(gameHero);

            sceneManager.AddGameScene(new WinScene(Content, sceneManager), WinScene.NAME);
            sceneManager.AddGameScene(new LoseScene(Content, sceneManager), LoseScene.NAME);
            sceneManager.AddGameScene(new LockRoomScene(Content, sceneManager), LockRoomScene.NAME);
            sceneManager.AddGameScene(new HallRoomScene(Content, sceneManager), HallRoomScene.NAME);
            sceneManager.AddGameScene(new TwinsRoomScene(Content, sceneManager), TwinsRoomScene.NAME);
            sceneManager.AddGameScene(new ToiletRoomScene(Content, sceneManager), ToiletRoomScene.NAME);
            sceneManager.AddGameScene(new StairsRoomScene(Content, sceneManager), StairsRoomScene.NAME);
            sceneManager.AddGameScene(new StartingRoomScene(Content, sceneManager), StartingRoomScene.NAME);
            sceneManager.AddGameScene(new DeadgirlRoomScene(Content, sceneManager), DeadgirlRoomScene.NAME);
            sceneManager.AddGameScene(new EricRoomScene(Content, sceneManager, GraphicsDevice), EricRoomScene.NAME);

            sceneManager.SetGameScene(StartingRoomScene.NAME, new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseStateObject.Update(gameTime);
            sceneManager.Update(gameTime); base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            sceneManager.Draw(gameTime, _spriteBatch);
            //_spriteBatch.Draw(rect1, new Vector2(510, 136), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}