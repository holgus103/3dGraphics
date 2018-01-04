using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Core.Objects.Commons
{
    public abstract class TexturedVertexPhongObject : VertexPhongObject<VertexPositionNormalTexture>, ITextured
    {
        protected TexturedVertexPhongObject(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation, string texturePath) : base(ctx, dev, position, xRotation, yRotation, zRotation)
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
