using System;
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
    internal class EricRoomScene : LockableScene
    {
        Texture2D flashlightMask;
        AlphaTestEffect alphaEffect;
        DepthStencilState maskStencil;
        DepthStencilState backgroundStencil;

        public static bool haveFlashlight = false;
        public static readonly string NAME = "EricRoom";

        static Queue<string> EricDialog
        {
            get => new(new string[]
            {
                "Edna: Ernest why are you here?",
                "Ernest: Oh, I don't know... I was locked up after constantly repeating the numbers I overheard from the guard...",
                "Edna: Yesterday?",
                "Ernest: I lost track of time here...",
                "Edna: Were they 263?",
                $"Ernest: Miss! They were {LockRoomScene.PASSWORD}!",
                "Edna: Exactly!"
            });
        }

        public EricRoomScene(ContentManager content, SceneManager manager, GraphicsDevice graphics) 
            : base(content, manager)
        {
            haveFlashlight = false;
            flashlightMask = InitFlashlightMask(graphics);

            Matrix matrix = Matrix.CreateOrthographicOffCenter(0,
                graphics.PresentationParameters.BackBufferWidth,
                graphics.PresentationParameters.BackBufferHeight,
                0, 0, 1
            );
            alphaEffect = new(graphics) { Projection = matrix };

            maskStencil = new DepthStencilState
            {
                StencilEnable = true,
                StencilFunction = CompareFunction.Always,
                StencilPass = StencilOperation.Replace,
                ReferenceStencil = 1,
                DepthBufferEnable = false,
            };
            backgroundStencil = new DepthStencilState
            {
                StencilEnable = true,
                StencilFunction = CompareFunction.LessEqual,
                StencilPass = StencilOperation.Keep,
                ReferenceStencil = 1,
                DepthBufferEnable = false,
            };
        }

        public override void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch, GameHero gameHero)
        {
            if (haveFlashlight)
            {
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, maskStencil, null, alphaEffect);
                spriteBatch.Draw(flashlightMask, gameHero.Hitbox.Center.ToVector2() - new Vector2(150, 150), Color.White);
                spriteBatch.End();

                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, backgroundStencil, null, alphaEffect);

                background.Draw(gameTime, spriteBatch);
                foreach (var drawableObject in drawableObjects.ToArray())
                {
                    drawableObject.Draw(gameTime, spriteBatch);
                }

                spriteBatch.End();

                spriteBatch.Begin();
                foreach (var drawableObject in triggableDrawables.ToArray())
                {
                    drawableObject.Draw(gameTime, spriteBatch);
                }
            }
            gameHero.Draw(gameTime, spriteBatch);
        }
        public override void DrawBackground(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
        public override void Update(GameTime gameTime, GameHero gameHero)
        {
            foreach (var trigger in triggablesObjects.ToArray())
            {
                trigger.Update(gameTime, gameHero.Hitbox);
            }

            if (haveFlashlight) 
            {
                foreach (var trigger in triggableDrawables.ToArray())
                {
                    trigger.Update(gameTime, gameHero.Hitbox);
                }
            }
            if (!isLocked) gameHero.Update(gameTime);
        }

        protected override Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("EricRoomScene/Background"));
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            SceneTrigger rightTrigger = new(new Point(Constants.WIDTH + Constants.SCENE_TRIGGER_WIDTH, 0)) 
            {
                Callback = () => manager.SetGameScene(HallRoomScene.NAME, new(818, Constants.LOWEST_HERO_POS))
            };

            return new List<ITriggableObject>() { rightTrigger };
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>() { InitEric(content) };
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            TriggableDrawableTrigger trigger = InitTrigger();

            GameButton dialogBtn = InitButton(content);
            dialogBtn.Callback = () =>
            {
                GameDialog dialog = InitDialogLabel(content, EricDialog);
                triggableDrawables.Add(dialog); trigger.TriggableDrawable = null; isLocked = true;
                dialog.Callback = () =>
                {
                    isLocked = false;
                    triggableDrawables.Remove(dialog);
                    trigger.TriggableDrawable = dialogBtn;
                };
            };
            trigger.TriggableDrawable = dialogBtn;

            return new List<ITriggableDrawable>() { trigger };
        }

        private TriggableDrawableTrigger InitTrigger() 
        {
            return new(new(new(100, Constants.FLOOR_LEVEL - 157), new(80, 157), null));
        }
        private GameButton InitButton(ContentManager content)
        {
            int y = Constants.TRIGGER_BUTTON_SIZE.Y;
            int x = (Constants.WIDTH - Constants.TRIGGER_BUTTON_SIZE.X) / 2;

            return new(new(x, y), Constants.TRIGGER_BUTTON_SIZE, "Start Talking", content);
        }
        private AnimatedObject InitEric(ContentManager content)
        {
            List<Texture2D> ericSprites = new()
            {
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_1"),
                content.Load<Texture2D>("EricRoomScene/Eric_2"),
            };

            return new(new(100, Constants.FLOOR_LEVEL - 157), new(80, 157), ericSprites);
        }
        private Texture2D InitFlashlightMask(GraphicsDevice graphics)
        {
            int width = 300;
            int height = 300;

            int flashlightRadius = 150;
            Point circleCenter = new(150, 150);

            Color[] colorData = new Color[width * height];
            for (int y = 0; y < height; y++)
            {
                double yAxis = Math.Pow(y - circleCenter.Y, 2);
                for (int x = 0; x < width; x++)
                {
                    double xAxis = Math.Pow(x - circleCenter.X, 2);
                    if (xAxis + yAxis - Math.Pow(flashlightRadius, 2) < Math.Pow(10, -10))
                    {
                        colorData[x + width * y] = Color.White;
                    }
                }
            }
            Texture2D mask = new(graphics, width, height);
            mask.SetData(colorData); return mask;
        }
        private GameDialog InitDialogLabel(ContentManager content, Queue<string> dialog) 
        {
            int y = Constants.DIALOG_LABEL_Y_OFFSET;
            int x = (Constants.WIDTH - Constants.DIALOG_LABEL_SIZE.X) / 2;

            return new(new(x, y), Constants.DIALOG_LABEL_SIZE, dialog, content);
        }
        
    }
}
