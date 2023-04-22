using WardEscape.Core;
using WardEscape.Objects;
using WardEscape.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WardEscape.Scenes
{
    internal class StairsScene : GameScene
    {
        public static readonly string NAME = "StairsScene";
        public StairsScene(SceneManager manager, ContentManager content, Character character)
            : base(content.Load<Texture2D>("ScenesBackground/StairsScene"))
        {
            InitTriggable(manager, character);
        }

        private void InitTriggable(SceneManager manager, Character character)
        {
            SceneTrigger trigger = new(
                new Point(Constants.WIDTH, 0),
                new Vector2(20, Constants.HEIGHT),
                () =>
                {
                    character.MoveTo(new Point(0, 400));
                    manager.ChangeScene(HallScene.NAME);
                }
            );
            triggableInstances.Add(trigger);
        }
    }
}
