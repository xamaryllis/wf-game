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
    internal class StartingScene : GameScene
    {
        public static readonly string NAME = "StartingScene";
        
        public StartingScene(ContentManager content, SceneManager manager)
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("StartingScene/Background"));
        }
        protected override List<DrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<DrawableObject>();
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {  
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0));
            rightTrigger.ChangeScene = () => manager.SetGameScene(HallScene.NAME, new Point(500, Constants.HEIGHT - 50));

            return new List<ITriggableObject>() { rightTrigger };
        } 
    }
}
