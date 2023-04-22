using WardEscape.Core;
using WardEscape.Objects;
using WardEscape.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WardEscape.Scenes
{
    internal class ToiletScene : GameScene
    {
        public static readonly string NAME = "ToiletScene";
        public ToiletScene(SceneManager manager, ContentManager content, Character character)
            : base(content.Load<Texture2D>("ScenesBackground/ToiletScene"))
        {
            InitTriggable(manager, character);
        }

        private void InitTriggable(SceneManager manager, Character character)
        {
            SceneTrigger trigger = new(
                new Point(-20, 0),
                new Vector2(20, Constants.HEIGHT),
                () =>
                {
                    manager.ChangeScene(HallScene.NAME);
                    character.MoveTo(new Point(Constants.WIDTH - 100, 400));
                }
            );
            triggableInstances.Add(trigger);
        }
    }
}