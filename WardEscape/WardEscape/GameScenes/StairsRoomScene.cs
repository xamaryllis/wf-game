using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameObjects;
using WardEscape.GameObjects.GameTriggers;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameScenes.HallRoom;

namespace WardEscape.GameScenes
{
    internal class StairsRoomScene : HeroHideScene
    {
        public static readonly string NAME = "StairsRoom";
        
        public StairsRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        public override List<RectangleObject> GetAdditionalBounds()
        {
            List<RectangleObject> baseBounds = base.GetAdditionalBounds();

            baseBounds.Add(new RectangleObject(new Point(892, 210), new Point(158, 45)));
            baseBounds.Add(new RectangleObject(new Point(782, 243), new Point(102, 45)));

            Point stairSize = new(102, 45);
            Point previousStair = new(782, 243);

            for (int i = 0; i < 7; i++)
            {
                previousStair += new Point(-stairSize.X, stairSize.Y);
                baseBounds.Add(new RectangleObject(previousStair, stairSize));
            }

            return baseBounds;
        }
        public override void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch, GameHero gameHero)
        {
            gameHero.Draw(gameTime, spriteBatch);
            foreach (var drawableObject in drawableObjects)
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }

            foreach (var drawableObject in triggableDrawables)
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("StairsRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS))
            };
            SceneTrigger leftTrigger = new(new Point(-Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                Callback = () => manager.SetGameScene(LockRoomScene.NAME, Point.Zero)
            };

            return new List<ITriggableObject>() { rightTrigger, leftTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>() { InitRails(content) };
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            SecurityTrigger security = new(InitSecurity(content))
            {
                Callback = () => { manager.SetGameScene(LoseScene.NAME, Point.Zero); }
            };
            return new List<ITriggableDrawable>() { security };
        }

        private Security InitSecurity(ContentManager content)
        {
            List<Texture2D> securitySprites = new()
            {
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_1"),
                content.Load<Texture2D>("StairsRoomScene/Security_2"),
                content.Load<Texture2D>("StairsRoomScene/Security_2"),
                content.Load<Texture2D>("StairsRoomScene/Security_2"),
                content.Load<Texture2D>("StairsRoomScene/Security_3"),
                content.Load<Texture2D>("StairsRoomScene/Security_3"),
                content.Load<Texture2D>("StairsRoomScene/Security_3"),
            };
            Texture2D watchSprite = content.Load<Texture2D>("StairsRoomScene/Security_2");

            return new(new(800, Constants.FLOOR_LEVEL - 164), new(117, 214), securitySprites, watchSprite);
        }
        private DrawableObject InitRails(ContentManager content)
        {
            return new(Point.Zero, Constants.WINDOW, content.Load<Texture2D>("StairsRoomScene/Rails"));
        }
    }
}
