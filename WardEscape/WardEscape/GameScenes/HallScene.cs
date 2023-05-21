using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;

namespace WardEscape.GameScenes
{
    internal class HallScene : GameScene
    {
        public static readonly string NAME = "HallScene";

        public HallScene(ContentManager content, SceneManager manager) 
        {
            background = LoadBackground(content);
            sceneTriggers = InitSceneTriggetrs(manager);
        }

        private Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("HallScene/Background"));
        }

        private List<SceneTrigger> InitSceneTriggetrs(SceneManager manager) 
        {
            SceneTrigger leftTrigger = new(
                new Point(-Constants.SCENE_TRIGGER_WIDTH, 0),
                () => manager.SetGameScene(StairsScene.NAME, new Point(1000, 50))
            );

            return new List<SceneTrigger> { leftTrigger };
        }
    }
}
