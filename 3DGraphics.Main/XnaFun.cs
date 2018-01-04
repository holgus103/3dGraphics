using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _3DGraphics.Core;
using _3DGraphics.Core.Objects;

namespace _3DGraphics.Main
{
    class XnaFun : GameBase
    {
        private Sea sea;

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
            this.elements.Add(new PalmTree(this.Content, new Vector3(-10, 9, 0), -0.2f, 0.5f, 0, 1));
            this.elements.Add(new PalmTree(this.Content, new Vector3(10, 7, 0), 0, 0, -0.3f, 1));
            // add island
            this.elements.Add(new Island(this.Content, 10, 0.7f, 3, 25, graphics.GraphicsDevice, new Vector3(0, -2, 0), 0, 0, 0));
            // add sea
            this.elements.Add(new Boat(this.Content, graphics.GraphicsDevice, new Vector3(50, 0, 0), MathHelper.ToRadians(270), 0, 0, 0.05f));
            //this.elements.Add(new Flag(this.Content, new Vector3(0, 7, 0), 0, 0, 0, 0.5f));
            this.elements.Add(new Lighthouse(this.Content, new Vector3(0, 7, 0), 0, 0, 0, 0.01f));
            //this.elements.Add(new Skybox(this.Content));
            //this.skybox = new Tropikalna_wyspa.Skybox("Images\\Islands", this.Content);
            this.elements.Add(new Skybox(this.Content));
            this.elements.Add(new ReflectionSphere(this.Content, new Vector3(0, 15, -50), 5));
            this.sea = new Sea(this.Content, this.camera, 4000, 0.03f, 0, graphics.GraphicsDevice, 150);
            this.elements.Add(sea);
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            this.sea.Control();
            base.Update(gameTime);
        }
    }
}
