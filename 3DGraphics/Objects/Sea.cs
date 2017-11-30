using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Objects.Commons;

namespace _3DGraphics.Objects
{
    class Sea : TexturedVertexObject
    {
        private readonly Camera camera;
        private readonly float level;
        private const string TEXTURE_PATH = "sea1.jpg";
        private const string MIXING_TEXTURE_PATH = "sea2.jpg";
        private static Texture2D mixingTexture;
        private static Texture2D texture;
        protected override string Technique => "TextureTeqMixing";
        
        

        public Sea(ContentManager ctx, Camera camera, float level, GraphicsDevice dev, float diagLength) : base(ctx, dev, new Vector3(camera.Position.X, level, camera.Position.Z), 0, 0, 0, TEXTURE_PATH)
        {
            mixingTexture = this.LoadTexture(MIXING_TEXTURE_PATH, dev);
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
            effect.MixingTexture = mixingTexture;
            this.position = new Vector3(camera.Position.X, this.level, camera.Position.Z);
            base.Draw(view, projection, pos);
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
    }
}
