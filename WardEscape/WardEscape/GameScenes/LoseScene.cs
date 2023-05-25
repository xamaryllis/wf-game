using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameObjects.GameTriggers;

namespace WardEscape.GameScenes
{
    internal class LoseScene : HeroHideScene
    {
        public static readonly string NAME = "LoseScene";
        public LoseScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        {
            isVisible = false;
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("GameEndScene/Lose"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            ClickableTrigger trigger = new(Point.Zero, Constants.WINDOW)
            {
                Callback = () => { manager.SetGameScene(StartingRoomScene.NAME, new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS)); }
            };

            return new List<ITriggableObject>() { trigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            return new List<ITriggableDrawable>();
        }
    }
}
