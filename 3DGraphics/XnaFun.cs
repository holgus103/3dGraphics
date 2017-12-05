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
        readonly GraphicsDeviceManager graphics;
        private DateTime lastUpdate;
        private readonly Camera camera = new Camera(new Vector3(0, 0, 50));


        private readonly List<Base> elements = new List<Base>();
        private Sea sea;
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
            this.sea = new Sea(this.Content, this.camera, 4000, 0.03f, 0, graphics.GraphicsDevice, 150);
            // TODO: Add your initialization logic here
            // add palm trees
            this.elements.Add(new PalmTree(this.Content, new Vector3(-10, 9, 0), -0.2f, 0.5f, 0, 1));
            this.elements.Add(new PalmTree(this.Content, new Vector3(10, 7, 0), 0, 0, -0.3f, 1));
            // add island
            this.elements.Add(new Island(this.Content, 10, 0.7f, 3, 25, graphics.GraphicsDevice, new Vector3(0, -2, 0), 0, 0, 0));
            // add sea
            this.elements.Add(sea);
            this.elements.Add(new Boat(this.Content, graphics.GraphicsDevice, new Vector3(50, 0, 0), MathHelper.ToRadians(270), 0, 0, 0.05f));
            //this.elements.Add(new Flag(this.Content, new Vector3(0, 7, 0), 0, 0, 0, 0.5f));
            this.elements.Add(new Lighthouse(this.Content, new Vector3(0, 7, 0), 0, 0, 0, 0.01f));
            //this.elements.Add(new Skybox(this.Content));
            //this.skybox = new Tropikalna_wyspa.Skybox("Images\\Islands", this.Content);
            this.elements.Add(new Skybox(this.Content));
            this.elements.Add(new ReflectionSphere(this.Content, new Vector3(0, 15, -50), 5));
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

            XnaFun.FrameTime = DateTime.Now - this.lastUpdate;
            if (FrameTime.TotalMilliseconds == 0) return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.camera.Move(FrameTime);
            this.sea.Control();
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
            GraphicsDevice.Clear(Color.White);
            this.camera.Draw();

            this.elements.ForEach(e => e.Draw(this.camera.View, this.camera.Projection, camera.Position));


            base.Draw(gameTime);
        }
    }
}
