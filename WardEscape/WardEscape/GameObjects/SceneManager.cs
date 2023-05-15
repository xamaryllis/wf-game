using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GamePhysics;
using WardEscape.GameTriggers;
using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.GameObjects
{
    internal class SceneManager : IEventListener
    {
        GameHero gameHero;
        GameScene currentScene;
        PhysicsEngine physicsEngine;
        Dictionary<string, GameScene> gameScenes;

        public SceneManager(GameHero gameHero) 
        {
            this.gameHero = gameHero;
            physicsEngine = new(new(), new());
            gameScenes = new Dictionary<string, GameScene>();
        }

        public void AddGameScene(GameScene gameScene) 
        {
            if (!gameScenes.ContainsKey(gameScene.SceneName))
            {
                gameScenes.Add(gameScene.SceneName, gameScene);
            }
            else gameScenes[gameScene.SceneName] = gameScene;
        }

        public void Update(GameTime gameTime)
        {
            physicsEngine.Update(gameTime); gameHero.Update(gameTime);
            currentScene?.Update(gameTime, gameHero.Hitbox);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentScene?.Draw(gameTime, spriteBatch);
            gameHero.Draw(gameTime, spriteBatch);
        }
        
        public void SetGameScene(string sceneName) 
        {
            if (gameScenes.ContainsKey(sceneName)) 
            {
                currentScene = gameScenes[sceneName];
                UpdateGameBounds(gameScenes[sceneName]);
                UpdatePhysicsObject(gameScenes[sceneName]);
            }
        }
        public void ListentEvent(IGameEvent gameEvent)
        {
            if (gameEvent is SceneEvent sceneEvent) 
            {
                SetGameScene(sceneEvent.Info);
            }   
        }
        
        private void UpdatePhysicsObject(GameScene gameScene) 
        {
            physicsEngine.PhysicsObjects = new() { gameHero };
            foreach (var physicsObj in gameScene.GetAdditionalPhysicsObject()) 
            {
                physicsEngine.PhysicsObjects.Add(physicsObj);
            }
        }
        private void UpdateGameBounds(GameScene gameScene) 
        {
            physicsEngine.GameBounds = new() 
            {
                new(new Point(-100, 0), new Point(100, Constants.HEIGHT)),
                new(new Point(Constants.WIDTH, 0), new Point(100, Constants.HEIGHT)),
                new(new Point(0, Constants.HEIGHT - 100), new Point(Constants.WIDTH, Constants.HEIGHT)),
            };
            foreach (var gameBound in gameScene.GetAdditionalBounds()) 
            {
                physicsEngine.GameBounds.Add(gameBound);
            }
        }
    }
}
