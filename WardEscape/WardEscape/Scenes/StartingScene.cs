using WardEscape.Core;
using WardEscape.Objects;
using WardEscape.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WardEscape.Scenes
{
    internal class StartingScene : GameScene
    {
        public static readonly string NAME = "StartingScene";
        public StartingScene(SceneManager manager, ContentManager content)
            : base(content.Load<Texture2D>("ScenesBackground/StartingScene"))
        {
            InitTriggable(manager);
        }

        private void InitTriggable(SceneManager manager)
        {
            SceneTrigger trigger = new(
                new Point(-20, 0),
                new Vector2(20, Constants.HEIGHT),
                () => manager.ChangeScene(NAME)
            );
            triggableInstances.Add(trigger);
        }
    }
}
