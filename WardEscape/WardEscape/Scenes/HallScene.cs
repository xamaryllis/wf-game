using WardEscape.Core;
using WardEscape.Objects;
using WardEscape.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WardEscape.Scenes
{
    internal class HallScene : GameScene
    {
        public static readonly string NAME = "HallScene";
        public HallScene(SceneManager manager, ContentManager content, Character character)
            : base(content.Load<Texture2D>("ScenesBackground/HallScene"))
        {
            InitTriggable(manager, character);
        }

        private void InitTriggable(SceneManager manager, Character character)
        {
            SceneTrigger trigger1 = new(
                new Point(Constants.WIDTH, 0),
                new Vector2(20, Constants.HEIGHT),
                () =>
                {
                    character.MoveTo(new Point(0, 400));
                    manager.ChangeScene(ToiletScene.NAME);
                }
            );
            triggableInstances.Add(trigger1);


            SceneTrigger trigger2 = new(
                new Point(-20, 0),
                new Vector2(20, Constants.HEIGHT),
                () =>
                {
                    manager.ChangeScene(StairsScene.NAME);
                    character.MoveTo(new Point(Constants.WIDTH - 100, 450));
                }
            );
            triggableInstances.Add(trigger2);
        }
    }
}
