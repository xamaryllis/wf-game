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
    internal class ToiletRoomScene : LockableScene
    {
        public static readonly string NAME = "ToiletRoom";

        static Queue<string> BunnyDialog 
        {
            get => new(new string[] 
            {
                "Edna: Harvey? What are you doing?",
                "Harvey: Dry after washing.",
                "Edna: Oh... Okey...",
                "Harvey: And you what are you doing?",
                "Edna: I feel bad... I want to leave right now",
                "Harvey: Make sure the guard doesn't see you.",
                "Edna: I will try to be on time.",
                "Harvey: Edna!",
                "Edna: Hm?",
                "Harvey: I'll miss you.",
                "Edna: I'll miss you too!"
            });
        }

        public ToiletRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("ToiletRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger leftTrigger = new(new Point(-Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new(Constants.RIGHTEST_HERO_POS, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject> { leftTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            TriggableDrawableTrigger bunny = new(InitBunny(content));
            
            GameButton dialogBtn = InitButton(content);
            dialogBtn.Callback = () =>
            {
                GameDialog dialog = InitDialogLabel(content, BunnyDialog);
                triggableDrawables.Add(dialog); bunny.TriggableDrawable = null; isLocked = true;

                dialog.Callback = () => 
                { 
                    triggableDrawables.Remove(dialog); 
                    bunny.TriggableDrawable = dialogBtn; 
                    isLocked = false;
                };
            };
            bunny.TriggableDrawable = dialogBtn;
            
            return new List<ITriggableDrawable>() { bunny };
        }

        private GameButton InitButton(ContentManager content)
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            return new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Start Talking", content);
        }
        private AnimatedObject InitBunny(ContentManager content) 
        {
            List<Texture2D> bunnySprites = new()
            {
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_1"),
                content.Load<Texture2D>("ToiletRoomScene/Bunny_2"),
            };

            return new(new(600, Constants.FLOOR_LEVEL - 434), new(437, 434), bunnySprites);
        }
        private GameDialog InitDialogLabel(ContentManager content, Queue<string> dialog)
        {
            int y = Constants.DIALOG_LABEL_Y_OFFSET;
            int x = (Constants.WIDTH - Constants.DIALOG_LABEL_SIZE.X) / 2;

            return new(new(x, y), Constants.DIALOG_LABEL_SIZE, dialog, content);
        }

    }
}
