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
    abstract class TexturedVertexObject : VertexObject<VertexPositionNormalTexture>, ITextured
    {
        protected TexturedVertexObject(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation, string texturePath) : base(ctx, dev, position, xRotation, yRotation, zRotation)
        {
            this.InitTexture(texturePath, dev);
        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            effect.Texture = this.Texture;
            base.Draw(view, projection, pos);
        }

        public abstract Texture2D Texture { get; set; }
    }
}
