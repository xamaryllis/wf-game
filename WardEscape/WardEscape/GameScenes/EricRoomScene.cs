using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameScenes
{
    internal class EricRoomScene : GameScene
    {
        public static readonly string NAME = "EricRoom";

        public EricRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new Background(content.Load<Texture2D>("EricRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            throw new System.NotImplementedException();
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>()
            {
                new DrawableObject(
                    Point.Zero, Constants.WINDOW,
                    content.Load<Texture2D>("StairsScene/Rails")
                ),
            };
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            throw new System.NotImplementedException();
        }
    }
}
