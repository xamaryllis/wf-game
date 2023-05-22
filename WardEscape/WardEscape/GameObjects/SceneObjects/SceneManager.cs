﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GamePhysics;

namespace WardEscape.GameObjects.SceneObjects
{
    internal class SceneManager
    {
        GameHero gameHero;
        GameScene currentScene;
        PhysicsEngine physicsEngine;
        Dictionary<string, GameScene> gameScenes;

        List<RectangleObject> BasicBounbs
        {
            get => new List<RectangleObject>()
            {
                new RectangleObject(
                    new Point(-100 - 2 * Constants.SCENE_TRIGGER_WIDTH, 0),
                    new Point(100, Constants.HEIGHT)
                ),

                new RectangleObject(
                    new Point(Constants.WIDTH + 2 * Constants.SCENE_TRIGGER_WIDTH, 0),
                    new Point(100, Constants.HEIGHT)
                ),

                new RectangleObject(
                    new Point(-2 * Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT - 50),
                    new Point(Constants.WIDTH + 2 * Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT)
                ),
            };
        }

        public SceneManager(GameHero gameHero)
        {
            this.gameHero = gameHero;
            physicsEngine = new(new(), new());
            gameScenes = new Dictionary<string, GameScene>();
        }

        public void AddGameScene(GameScene gameScene, string sceneNames)
        {
            if (!gameScenes.ContainsKey(sceneNames))
            {
                gameScenes.Add(sceneNames, gameScene);
            }
            else gameScenes[sceneNames] = gameScene;
        }

        public void Update(GameTime gameTime)
        {
            physicsEngine.Update(gameTime); gameHero.Update(gameTime);
            currentScene?.Update(gameTime, gameHero.Hitbox);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentScene?.DrawBackground(gameTime, spriteBatch);
            gameHero.Draw(gameTime, spriteBatch);
            currentScene?.DrawObjects(gameTime, spriteBatch);
        }

        public void SetGameScene(string sceneName, Point newHeroPos)
        {
            if (gameScenes.ContainsKey(sceneName))
            {
                gameHero.MoveObjectTo(newHeroPos);

                currentScene = gameScenes[sceneName];
                UpdateGameBounds(gameScenes[sceneName]);
                UpdatePhysicsObject(gameScenes[sceneName]);
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
            physicsEngine.GameBounds = BasicBounbs;
            foreach (var gameBound in gameScene.GetAdditionalBounds())
            {
                physicsEngine.GameBounds.Add(gameBound);
            }
        }
    }
}