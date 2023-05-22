using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes
{
    internal class StairsRoomScene : GameScene
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
            return new Background(content.Load<Texture2D>("StairsRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                ChangeScene = () => manager.SetGameScene(HallRoomScene.NAME, new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject>() { rightTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>()
            {
                new DrawableObject(Point.Zero, Constants.WINDOW, content.Load<Texture2D>("StairsRoomScene/Rails")),
            };
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            return new List<ITriggableDrawable>();
        }
    }
}
