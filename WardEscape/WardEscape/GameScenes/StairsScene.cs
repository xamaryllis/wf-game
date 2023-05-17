using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameTriggers;

namespace WardEscape.GameScenes
{
    internal class StairsScene : GameScene
    {
        public static readonly string NAME = "StairsScene";
        
        public StairsScene(ContentManager content, SceneManager manager) 
        {
            background = LoadBackground(content);
            sceneTriggers = InitSceneTriggetrs(manager);
            drawableObjects = LoadDrawableObjects(content);
        }

        private Background LoadBackground(ContentManager content) 
        {
            return new Background(content.Load<Texture2D>("StairsScene/Background"));
        }

        private List<DrawableObject> LoadDrawableObjects(ContentManager content) 
        {
            return new List<DrawableObject>()
            {
                new(
                    Point.Zero, Constants.WINDOW, 
                    content.Load<Texture2D>("StairsScene/Rails")
                ),
            };
        }

        private List<SceneTrigger> InitSceneTriggetrs(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(
                new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0),
                HallScene.NAME, new Point(0, 450)
            );
            rightTrigger.Subscribe(manager);

            return new List<SceneTrigger>() { rightTrigger };
        }

        public override List<RectangleObject> GetAdditionalBounds()
        {
            List<RectangleObject> baseBounds = base.GetAdditionalBounds();
            
            baseBounds.Add(new RectangleObject(new Point(892, 210), new Point(158, 45)));
            baseBounds.Add(new RectangleObject(new Point(782, 243), new Point(102, 45)));
            
            Point stairSize = new Point(102, 45);
            Point previousStair = new Point(782, 243);

            for (int i = 0; i < 7; i++) 
            {
                previousStair += new Point(-stairSize.X, stairSize.Y);
                baseBounds.Add(new RectangleObject(previousStair, stairSize));
            }

            return baseBounds;
        }
    }
}
