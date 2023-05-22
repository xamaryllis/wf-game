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
    internal class HallScene : GameScene
    {
        public static readonly string NAME = "HallScene";

        public HallScene(ContentManager content, SceneManager manager)
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("HallScene/Background"));
        }
        protected override List<DrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<DrawableObject>();
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger leftTrigger = new(new Point(-Constants.SCENE_TRIGGER_WIDTH, 0));
            leftTrigger.ChangeScene = () => manager.SetGameScene(StairsScene.NAME, new Point(1000, 50));

            return new List<ITriggableObject> { leftTrigger };
        }
    }
}
