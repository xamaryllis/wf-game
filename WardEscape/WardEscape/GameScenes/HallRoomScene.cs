﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes
{
    internal class HallRoomScene : GameScene
    {
        public static readonly string NAME = "HallRoom";

        public HallRoomScene(ContentManager content, SceneManager manager)
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("HallRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger leftTrigger = new(new Point(-Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                ChangeScene = () => manager.SetGameScene(StairsRoomScene.NAME, new(Constants.RIGHTEST_HERO_POS, 50))
            };

            return new List<ITriggableObject> { leftTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            GameButton room419 = new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Enter", content)
            {
                Callback = () => { manager.SetGameScene(TwinsRoomScene.NAME, new(Constants.LEFTEST_HERO_POS, Constants.LOWEST_HERO_POS)); }
            };
            GameButton room420 = new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Enter", content)
            {
                Callback = () => { manager.SetGameScene(StartingRoomScene.NAME, new(Constants.RIGHTEST_HERO_POS, Constants.LOWEST_HERO_POS)); }
            };
            GameButton room421 = new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Enter", content)
            {
                Callback = () => { manager.SetGameScene(StartingRoomScene.NAME, new(Constants.RIGHTEST_HERO_POS, Constants.LOWEST_HERO_POS)); }
            };
            GameButton room422 = new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Enter", content)
            {
                Callback = () => { manager.SetGameScene(StartingRoomScene.NAME, new(Constants.RIGHTEST_HERO_POS, Constants.LOWEST_HERO_POS)); }
            };

            ButtonTriger room419Trigger = new(new(179, 308), new(86, 262)) { GameButton = room419 };
            ButtonTriger room420Trigger = new(new(392, 308), new(86, 262)) { GameButton = room420 };
            ButtonTriger room421Trigger = new(new(605, 308), new(86, 262)) { GameButton = room421 };
            ButtonTriger room422Trigger = new(new(818, 308), new(86, 262)) { GameButton = room422 };

            return new List<ITriggableDrawable>() { room419Trigger, room420Trigger, room421Trigger, room422Trigger };
        }
    }
}
