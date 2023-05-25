using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameObjects;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameObjects.SceneObjects;
using WardEscape.GameObjects.GameTriggers;

namespace WardEscape.GameScenes
{
    internal class LockRoomScene : HeroHideScene
    {
        int attemptsCount = 0;
        string passwordAttempt = "";
        Dictionary<string, Background> lockStates;

        public static string PASSWORD;
        static readonly int MAX_ATTEMPTS = 3;
        public static readonly string NAME = "LockRoomScene";
        
        public LockRoomScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        {
            Random random = new(); PASSWORD = "";
            for (int _ = 0; _ < random.Next(3, 10); _++) 
            {
                string nextNumber = random.Next(0, 10).ToString();
                while (PASSWORD.IndexOf(nextNumber) != -1) 
                {
                    nextNumber = random.Next(0, 10).ToString();
                }
                PASSWORD += nextNumber;
            } 
            isVisible = false;
        }

        protected override Background LoadBackground(ContentManager content)
        {
            lockStates = new()
            {
                { "Code_lock", new(content.Load<Texture2D>("LockRoomScene/Code_lock")) },
                { "Code_lock_0", new(content.Load<Texture2D>("LockRoomScene/Code_lock_0")) },
                { "Code_lock_1", new(content.Load<Texture2D>("LockRoomScene/Code_lock_1")) },
                { "Code_lock_2", new(content.Load<Texture2D>("LockRoomScene/Code_lock_2")) },
                { "Code_lock_3", new(content.Load<Texture2D>("LockRoomScene/Code_lock_3")) },
                { "Code_lock_4", new(content.Load<Texture2D>("LockRoomScene/Code_lock_4")) },
                { "Code_lock_5", new(content.Load<Texture2D>("LockRoomScene/Code_lock_5")) },
                { "Code_lock_6", new(content.Load<Texture2D>("LockRoomScene/Code_lock_6")) },
                { "Code_lock_7", new(content.Load<Texture2D>("LockRoomScene/Code_lock_7")) },
                { "Code_lock_8", new(content.Load<Texture2D>("LockRoomScene/Code_lock_8")) },
                { "Code_lock_9", new(content.Load<Texture2D>("LockRoomScene/Code_lock_9")) },
            };

            return lockStates["Code_lock"];
        }
        protected override List<ITriggableObject> InitTriggers(SceneManager manager)
        {
            List<ITriggableObject> triggers = new();
            for (int i = 0; i < 10; i++) 
            {
                int yPos = 41 + 95 * (i % 5);
                int xPos = 510 + 144 * (i / 5);

                ClickableTrigger trigger = new(new(xPos, yPos), new(82, 82))
                {
                    Callback = InitCallback(((i + 1) % 10).ToString(), manager)
                };
                triggers.Add(trigger);
            }

            return triggers;
        }
        protected override List<IDrawableObject> LoadDrawable(ContentManager content)
        {
            return new List<IDrawableObject>();
        }
        protected override List<ITriggableDrawable> InitTriggableDrawable(ContentManager content, SceneManager manager)
        {
            return new List<ITriggableDrawable>();
        }

        private Callback InitCallback(string number, SceneManager manager) 
        {
            return () =>
            {
                passwordAttempt += number;
                if (passwordAttempt.Length != PASSWORD.Length) 
                {
                    background = lockStates[$"Code_lock_{number}"];
                }

                else if (passwordAttempt == PASSWORD) 
                {
                    background = lockStates["Code_lock"];
                    passwordAttempt = ""; attemptsCount = 0;
                    manager.SetGameScene(WinScene.NAME, Point.Zero);
                }

                else if (attemptsCount + 1 == MAX_ATTEMPTS) 
                {
                    background = lockStates["Code_lock"];
                    passwordAttempt = ""; attemptsCount = 0;
                    manager.SetGameScene(LoseScene.NAME, Point.Zero);
                }
                
                else 
                {
                    background = lockStates["Code_lock"];
                    passwordAttempt = ""; attemptsCount++;
                }
            };
        }
    }
}
