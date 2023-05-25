using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes.GameMenu
{
    internal class GameMenuScene : HeroHideScene
    {
        Callback InitScenes { get; set; }
        public static readonly string NAME = "GameMenu";

        public GameMenuScene(ContentManager content, SceneManager manager, Callback initScenes)
            : base(content, manager)
        {
            isVisible = false;
            InitScenes = initScenes;
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("GameMenuScene/Background"));
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            return new List<ITriggableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            GameButton button = InitStartButton(content);
            button.Callback = () =>
            {
                InitScenes();
                manager.SetGameScene(StartingRoomScene.NAME, 
                    new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS)
                );
            };
            return new List<ITriggableDrawable>() { button };
        }

        private StartButton InitStartButton(ContentManager content)
        {
            int x = (Constants.WIDTH - Constants.GAME_MENU_BUTTON_SIZE.X) / 2;
            int y = Constants.HEIGHT - 4 * Constants.GAME_MENU_BUTTON_SIZE.Y / 3;

            return new(new(x, y), Constants.GAME_MENU_BUTTON_SIZE, "Start Play", content);
        }
    }
}
