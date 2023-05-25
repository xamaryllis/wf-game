using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects;
using WardEscape.GameObjects.SceneObjects;

namespace WardEscape.GameScenes
{
    internal class LockRoomScene : HeroHideScene
    {
        public LockRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            throw new System.NotImplementedException();
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
