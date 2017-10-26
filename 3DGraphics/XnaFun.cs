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
        SpriteBatch spriteBatch;
        private Model model;
        private BasicEffect effect;
        private float speed = 10;
        private DateTime lastUpdate;
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Vector3 cameraTarget = new Vector3(0, 0, 0);
        private Vector3 cameraPosition = new Vector3(0, 0, 50);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
        private Matrix view;
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
            this.effect = new BasicEffect(graphics.GraphicsDevice);
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

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

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var step = this.cameraTarget - this.cameraPosition;
            step.Normalize();
            step = Vector3.Multiply(step, (float)(this.speed / frameTime.TotalMilliseconds));

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.cameraPosition += step;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.cameraPosition -= step;
            }
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
            this.view = Matrix.CreateLookAt(this.cameraPosition, this.cameraTarget, Vector3.UnitY);
            //var cameraPosition = new Vector3(0, 40, 20);
            //var cameraLookAtVector = Vector3.Zero;
            //var cameraUpVector = Vector3.UnitZ;

            //effect.View = Matrix.CreateLookAt(cameraPosition, cameraLookAtVector, cameraUpVector);
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            //var floorVerts = new VertexPositionTexture[3];

            //floorVerts[0].Position = new Vector3(-10, 0, 0);
            //floorVerts[1].Position = new Vector3(0, 10, 0);
            //floorVerts[2].Position = new Vector3(10, 0, 0);


            //float aspectRatio = graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight;
            //float fieldOfView = MathHelper.PiOver4;
            //float nearClipPlane = 1;
            //float farClipPlane = 200;

            //effect.Projection = Matrix.CreatePerspectiveFieldOfView(
            //    fieldOfView, aspectRatio, nearClipPlane, farClipPlane);


            //foreach (var pass in effect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();

            //    graphics.GraphicsDevice.DrawUserPrimitives(
            //    // We’ll be rendering two trinalges
            //    PrimitiveType.TriangleList,
            //    // The array of verts that we want to render
            //    floorVerts,
            //    // The offset, which is 0 since we want to start 
            //    // at the beginning of the floorVerts array
            //    0,
            //    // The number of triangles to draw
            //    1);
            //    // TODO: Add your drawing code here
            //}

            this.elements.ForEach(e => e.Draw(this.view, this.projection));

            base.Draw(gameTime);
        }
    }
}
