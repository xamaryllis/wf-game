using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameObjects.GameTriggers;
using WardEscape.GameScenes.GameMenu;

namespace WardEscape.GameScenes
{
    internal class WinScene : HeroHideScene
    {
        public static readonly string NAME = "WinScene";
        public WinScene(ContentManager content, SceneManager manager)
            : base(content, manager)
        {
            isVisible = false;
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("GameEndScene/Win"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            ClickableTrigger trigger = new(Point.Zero, Constants.WINDOW)
            {
                Callback = () => { manager.SetGameScene(GameMenuScene.NAME, Point.Zero); }
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
