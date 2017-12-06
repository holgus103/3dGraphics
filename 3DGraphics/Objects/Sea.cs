using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _3DGraphics.Objects.Commons;

namespace _3DGraphics.Objects
{
    class Sea : TexturedVertexPhongObject
    {
        private readonly Camera camera;
        private readonly float level;
        private const string TEXTURE_PATH = "Content\\Images\\sea1.jpg";
        private const string MIXING_TEXTURE_PATH = "Content\\Images\\sea2.jpg";
        private const string MIXING_TEXTURE_PATH2 = "Content\\Images\\sea3.jpg";
        private static Texture2D mixingTexture;
        private static Texture2D mixingTexture2;
        private Texture2D currentMixingTexture;
        private static Texture2D texture;
        protected override string Technique => "TextureTeqMixing";
        private float displacementRay;
        private float displacementCounter;
        private int displacementSpeed = 1;
        private bool imminentTextureChange;
        private bool plusDown;
        private bool minusDown;


        public Sea(ContentManager ctx, Camera camera, int displacementSpeed, float displacementRay, float level, GraphicsDevice dev, float diagLength) : base(ctx, dev, new Vector3(camera.Position.X, level, camera.Position.Z), 0, 0, 0, TEXTURE_PATH)
        {
            this.displacementSpeed = displacementSpeed;
            this.displacementRay = displacementRay;
            currentMixingTexture = mixingTexture = this.LoadTexture(MIXING_TEXTURE_PATH, dev);
            mixingTexture2 = this.LoadTexture(MIXING_TEXTURE_PATH2, dev);
            this.camera = camera;
            this.level = level;
            this.vertices = new VertexPositionNormalTexture[6];

            // 1st triangle
            this.vertices[0] = new VertexPositionNormalTexture(new Vector3(diagLength, this.level, diagLength), Vector3.UnitY, new Vector2(0, 0));
            this.vertices[1] = new VertexPositionNormalTexture(new Vector3(-diagLength, this.level, -diagLength), Vector3.UnitY, new Vector2(1, 1));
            this.vertices[2] = new VertexPositionNormalTexture(new Vector3(diagLength, this.level, -diagLength), Vector3.UnitY, new Vector2(0, 1));
            //// 2nd triangle
            this.vertices[4] = new VertexPositionNormalTexture(new Vector3(diagLength, this.level, diagLength), Vector3.UnitY, new Vector2(0, 0));
            this.vertices[3] = new VertexPositionNormalTexture(new Vector3(-diagLength, this.level, -diagLength), Vector3.UnitY, new Vector2(1, 1));
            this.vertices[5] = new VertexPositionNormalTexture(new Vector3(-diagLength, this.level, diagLength), Vector3.UnitY, new Vector2(1, 0));

        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            effect.GraphicsDevice.BlendState = BlendState.AlphaBlend;
            // update displacement
            displacementCounter += (float)(XnaFun.FrameTime.TotalMilliseconds / this.displacementSpeed);
            displacementCounter = displacementCounter - (int) displacementCounter;
            //Debug.WriteLine((displacementCounter - 0.5f) * (displacementCounter - 0.5f));
            effect.Displacement = new Vector2(displacementRay * (displacementCounter - 0.5f)*(displacementCounter - 0.5f));
            effect.MixingTexture = currentMixingTexture;
            this.position = new Vector3(camera.Position.X, this.level, camera.Position.Z);
            base.Draw(view, projection, pos);
            effect.GraphicsDevice.BlendState = BlendState.Opaque;
        }

        public override Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        private void ChangeMixingTexture() =>
            this.ensureKeyRelease(
                () => this.currentMixingTexture = this.currentMixingTexture == mixingTexture ? mixingTexture2 : mixingTexture, 
                ref this.imminentTextureChange, 
                Keys.F1);



        private void ensureKeyRelease(Action a, ref bool flag, Keys k)
        {
            if (Keyboard.GetState().IsKeyDown(k))
            {
                flag = true;
            }
            else
            {
                if (flag)
                {
                    a();
                    flag = false;
                }
            }
        }

        private void IncreaseWaveSpeed() =>
            this.ensureKeyRelease(
                () => this.displacementSpeed -=  this.displacementSpeed > 1000 ? 1000 : 0,
                ref this.plusDown,
                Keys.OemPlus
                );


        private void DecreaseWaveSpeed() =>
            this.ensureKeyRelease(
                () => this.displacementSpeed += 1000,
                ref this.minusDown,
                Keys.OemMinus
            );

        public void Control()
        {
            this.IncreaseWaveSpeed();
            this.DecreaseWaveSpeed();
            this.ChangeMixingTexture();
        }

    }
}
