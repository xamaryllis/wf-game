using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WardEscape.GameObjects;

namespace WardEscape.GameScenes
{
    internal class StartingScene : GameScene
    {
        public StartingScene(ContentManager content, SceneManager manager)
        {
            sceneTriggers = new();
            drawableObjects = new();
            SceneName = "StartingScene";
            background = new(content.Load<Texture2D>("StartingScene/Background"));
        }
    }
}
