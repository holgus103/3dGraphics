using _3DGraphics.Core.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3DGraphics.Core
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameBase : Game
    {
        protected readonly GraphicsDeviceManager graphics;
        private DateTime lastUpdate;
        protected readonly Camera camera = new Camera(new Vector3(0, 0, 5));


        protected readonly List<Base> elements = new List<Base>();

        public GameBase()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            GameBase.FrameTime = DateTime.Now - this.lastUpdate;
            if (FrameTime.TotalMilliseconds == 0) return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.camera.Move(FrameTime);
            this.lastUpdate = DateTime.Now;
            base.Update(gameTime);
        }

        public static TimeSpan FrameTime { get; set; }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            this.camera.Draw();

            this.elements.ForEach(e => e.Draw(this.camera.View, this.camera.Projection, camera.Position));


            base.Draw(gameTime);
        }
    }
}
