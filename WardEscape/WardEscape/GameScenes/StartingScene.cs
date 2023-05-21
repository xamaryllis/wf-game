using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes
{
    internal class StartingScene : GameScene
    {
        public static readonly string NAME = "StartingScene";
        
        public StartingScene(ContentManager content, SceneManager manager)
        {
            background = LoadBackground(content);
            sceneTriggers = InitSceneTriggetrs(manager);
        }

        private Background LoadBackground(ContentManager content) 
        {
            return new(content.Load<Texture2D>("StartingScene/Background"));
        }

        private List<SceneTrigger> InitSceneTriggetrs(SceneManager manager) 
        {  
            SceneTrigger rightTrigger = new(
                new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0),
                () => manager.SetGameScene(HallScene.NAME, new Point(500, Constants.HEIGHT - 50))
            );

            return new List<SceneTrigger>() { rightTrigger };
        }
    }
}
