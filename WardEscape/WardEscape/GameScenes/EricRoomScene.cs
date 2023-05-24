using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameObjects.GUIObjects;

namespace WardEscape.GameScenes
{
    internal class EricRoomScene : GameScene
    {
        GraphicsDevice graphicsDevice;
        static int flashlightRadius = 0;

        public static readonly string NAME = "EricRoom";

        public EricRoomScene(ContentManager content, SceneManager manager, GraphicsDevice graphics) 
            : base(content, manager)
        {
            graphicsDevice = graphics;
        }

        public override void Update(GameTime gameTime, GameHero gameHero)
        {
            base.Update(gameTime, gameHero);
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new Background(content.Load<Texture2D>("EricRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0)) 
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new(818, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject>() { rightTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            return new List<ITriggableDrawable>();
        }

        private GameButton InitButton(ContentManager content)
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            return new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Inspect", content);
        }
        private AnimatedObject InitEric(ContentManager content)
        {
            List<Texture2D> ericSprites = new()
            {
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_2"),
            };

            return new(new(100, Constants.FLOOR_LEVEL - 157), new(80, 157), ericSprites);
        }
        private Texture2D DrawFlashlightCircle(Point circleCenter) 
        {
            int width = Constants.WIDTH;
            int height = Constants.HEIGHT;

            Color[] colorData = new Color[width * height];
            for (int x = 0; x < width; x++) 
            {
                int xPart = (int)Math.Pow(x - circleCenter.X, 2);
                for (int y = 0; y < height; y++) 
                {
                    int yPart = (int)Math.Pow(y - circleCenter.Y, 2);
                    if (xPart + yPart == Math.Pow(flashlightRadius, 2)) 
                    {
                    }
                }
            }
            Texture2D flashlightCircle = new(graphicsDevice, width, height);
            flashlightCircle.SetData();
            int a = 0;
            return flashlightCircle;
        }
    }
}
