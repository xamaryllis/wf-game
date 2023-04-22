﻿using WardEscape.Core;
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
        public StartingScene(SceneManager manager, ContentManager content, Character character)
            : base(content.Load<Texture2D>("ScenesBackground/StartingScene"))
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
                    manager.ChangeScene(HallScene.NAME);
                    character.MoveTo(new Point(500, 400));
                }
            );
            triggableInstances.Add(trigger);
        }
    }
}
