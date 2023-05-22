﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes
{
    internal class DeadgirlRoomScene : GameScene
    {
        public static readonly string NAME = "DeadgirlRoom";

        public DeadgirlRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new Background(content.Load<Texture2D>("DeadgirlRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            throw new System.NotImplementedException();
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            throw new System.NotImplementedException();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            throw new System.NotImplementedException();
        }
    }
}
