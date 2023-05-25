using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameScenes.HallRoom;
using WardEscape.GameObjects.GameTriggers;

namespace WardEscape.GameScenes
{
    internal class DeadgirlRoomScene : OverlayScene
    {
        public static readonly string NAME = "DeadgirlRoom";

        public DeadgirlRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("DeadgirlRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new Point(605, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject>() { rightTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            TriggableDrawableTrigger girl = new(InitGirl(content));

            GameButton inspectBtn = InitButton(content);
            inspectBtn.Callback = () =>
            {
                ItemOverlay overlay = InitOverlay(content);
                ItemOverlay = overlay; girl.TriggableDrawable = null;
                overlay.Callback = () => { ItemOverlay = null; TwinsRoomScene.SweetReciveChange();  };
            };
            girl.TriggableDrawable = inspectBtn;

            return new List<ITriggableDrawable>() { girl };
        }

        private GameButton InitButton(ContentManager content)
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            return new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Inspect", content);
        }
        private ItemOverlay InitOverlay(ContentManager content) 
        {
            return new("Candy", content.Load<Texture2D>("DeadgirlRoomScene/Candy"), content);
        }
        private DrawableObject InitGirl(ContentManager content)
        {
            Texture2D twinsSprite = content.Load<Texture2D>("DeadgirlRoomScene/Evelina");

            return new(new(300, Constants.FLOOR_LEVEL - 85), new(267, 85), twinsSprite);
        }
        
    }
}
