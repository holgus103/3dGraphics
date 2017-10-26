using _3DGraphics.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _3DGraphics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class XnaFun : Game
    {
        GraphicsDeviceManager graphics;
        private DateTime lastUpdate;
        private Camera camera = new Camera(new Vector3(0, 0, 50));


        private List<ObjectBase> elements = new List<ObjectBase>();

        public XnaFun()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // add palm trees
            this.elements.Add(new PalmTree(this.Content, new Vector3(-10, 0, 0), -0.2f, 0.5f, 0));
            this.elements.Add(new PalmTree(this.Content, new Vector3(10, 0, 0), 0, 0, -0.3f));
            // add island
            this.elements.Add(new Island(5, graphics.GraphicsDevice, new Vector3(0, 0, 0), 0, 0, 0));

            base.Initialize();
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

            var frameTime = DateTime.Now - this.lastUpdate;
            if (frameTime.TotalMilliseconds == 0) return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.camera.Move(frameTime);
            
            this.lastUpdate = DateTime.Now;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            this.camera.Draw();

            this.elements.ForEach(e => e.Draw(this.camera.View, this.camera.Projection));

            base.Draw(gameTime);
        }
    }
}
