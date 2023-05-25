using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameObjects.GUIObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameScenes.HallRoom;
using WardEscape.GameObjects.GameTriggers;

namespace WardEscape.GameScenes
{
    internal class TwinsRoomScene : OverlayScene
    {
        TriggableDrawableTrigger twins;
        public static readonly string NAME = "TwinsRoom";

        static Queue<string> PreSweetDialog
        {
            get => new(new string[]
            {
                "Dean: Hi Edna! Have you been to the cafeteria today?",
                "Edna: Yeah, the mashed potatoes were disgusting...",
                "Sam: We will all burn in hell...",
                "Dean: Shut up Sam! Mashed potatoes were never their forte...",
                "Edna: Precisely.",
                "Sam: We will all burn in hell...",
                "Dean: Shut the f*ck up Sam! I'm sick of you... Hey Edna, can you bring me something sweet?",
                "Edna: Will try."
            });
        }
        static Queue<string> PostSweetDialog
        {
            get => new(new string[]
            {
                "Dean: Oh Edna! Thank you to death! Hey, take this, I stole it from the guard."
            });
        }
        public static Callback SweetReciveChange { get; private set; }

        public TwinsRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        {
            SweetReciveChange = SweetReciveChangeInit(content);
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("TwinsRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger leftTrigger = new(new Point(-Constants.SCENE_TRIGGER_WIDTH, 0))
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new(179, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject> { leftTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            twins = new(InitTwins(content));
            
            GameButton dialogBtn = InitButton(content);
            dialogBtn.Callback = () => 
            {
                GameDialog dialog = InitDialogLabel(content, PreSweetDialog);
                triggableDrawables.Add(dialog); twins.TriggableDrawable = null; isLocked = true;
                dialog.Callback = () => 
                {
                    isLocked = false;
                    triggableDrawables.Remove(dialog);
                    twins.TriggableDrawable = dialogBtn;
                };
            };
            twins.TriggableDrawable = dialogBtn;

            return new List<ITriggableDrawable>() { twins };
        }

        private GameButton InitButton(ContentManager content) 
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            return new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Start Talking", content);
        }
        private DrawableObject InitTwins(ContentManager content)
        {
            Texture2D twinsSprite = content.Load<Texture2D>("TwinsRoomScene/Twins");

            return new(new(400, Constants.FLOOR_LEVEL - 180), new(155, 170), twinsSprite);
        }
        private ItemOverlay InitOverlay(ContentManager content) 
        {
            return new("Flashlight", content.Load<Texture2D>("TwinsRoomScene/Flashlight"), content);
        }
        private Callback SweetReciveChangeInit(ContentManager content)
        {
            return () =>
            {
                twins.TriggableDrawable.Callback = () =>
                {
                    ItemOverlay item = InitOverlay(content);
                    item.Callback = () => { ItemOverlay = null; EricRoomScene.haveFlashlight = true; };

                    GameDialog dialog = InitDialogLabel(content, PostSweetDialog);
                    triggableDrawables.Add(dialog); twins.TriggableDrawable = null; isLocked = true;
                    dialog.Callback = () => { ItemOverlay = item; triggableDrawables.Remove(dialog); };
                };
            };
        }
        private GameDialog InitDialogLabel(ContentManager content, Queue<string> dialog) 
        {
            int y = Constants.DIALOG_LABEL_Y_OFFSET;
            int x = (Constants.WIDTH - Constants.DIALOG_LABEL_SIZE.X) / 2;

            return new(new(x, y), Constants.DIALOG_LABEL_SIZE, dialog, content);
        }
    }
}
