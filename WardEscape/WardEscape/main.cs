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
    class CandyItem : ItemOverlay
    {
        public CandyItem(string itemName, ContentManager content) 
            : base(itemName, content.Load<Texture2D>("GameHero/Edna_1"), content)
        { }
    }
    
    public class Main : Game
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        GameButton button;
        GameDialog gameDialog;
        CandyItem candyItem;

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

            Queue<string> dialogs = new(new string[] 
            {
                "Dean: Hi Edna! Have you been to the cafeteria today?",
                "Edna: Yeah, the mashed potatoes were disgusting...",
                "Sam: We will all burn in hell...",
                "Dean: Shut up Sam! Mashed potatoes were never their forte...",
                "Edna: Precisely.",
                "Sam: We will all burn in hell...",
                "Dean: Shut the f*ck up Sam! I'm sick of you... Hey Edna, can you bring me something sweet?",
                "Edna: Will try."
            });
            Callback callback = () => { TwinsRoomScene.SweetReciveChange(); };

            candyItem = new("Candy", Content);
            button = new(new(0, 100), new(200, 80), "Hello", Content);
            gameDialog = new(new(100, 100), new(500, 150), dialogs, Content);

            candyItem.Callback = callback;
            button.Callback = callback;
            gameDialog.Callback = callback;

            sceneManager = new SceneManager(gameHero);

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
            //button.Update(gameTime, gameHero.Hitbox);
            sceneManager.Update(gameTime); base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            sceneManager.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}