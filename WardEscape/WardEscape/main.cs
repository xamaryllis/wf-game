using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using WardEscape.GameCore;
using WardEscape.GameScenes;
using WardEscape.GameObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameObjects.SceneObjects;
using Microsoft.Xna.Framework.Content;

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
            gameHero = new GameHero(Content, new Point(100, Constants.HEIGHT - 50));

            Queue<string> dialogs = new Queue<string>(new string[] 
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
            Callback callback = () => { sceneManager.SetGameScene(HallScene.NAME, new(200, 200)); };

            candyItem = new("Candy", Content);
            button = new(new(100, 100), new(250, 100), "Hello", Content);
            gameDialog = new(new(100, 100), new(500, 150), dialogs, Content);

            candyItem.Callback = callback;
            button.Callback = callback;
            gameDialog.Callback = callback;

            sceneManager = new SceneManager(gameHero);
            sceneManager.AddGameScene(new HallScene(Content, sceneManager), HallScene.NAME);
            sceneManager.AddGameScene(new StairsScene(Content, sceneManager), StairsScene.NAME);
            sceneManager.AddGameScene(new StartingScene(Content, sceneManager), StartingScene.NAME);
            
            sceneManager.SetGameScene(StartingScene.NAME, Point.Zero);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseStateObject.Update(gameTime);
            gameDialog.Update(gameTime, gameHero.Hitbox);
            sceneManager.Update(gameTime); base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            sceneManager.Draw(gameTime, _spriteBatch);

            gameDialog.Draw(gameTime, _spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}