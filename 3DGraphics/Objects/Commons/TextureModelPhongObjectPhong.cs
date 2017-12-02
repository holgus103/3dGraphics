using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects.Commons
{
    abstract class TextureModelPhongObjectPhong : ModelPhongObject, ITextured
    {
        public abstract Texture2D Texture { get; set; }

        protected TextureModelPhongObjectPhong(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation, float scale, string texturePath) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            this.InitTexture(texturePath, dev);
        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            effect.Texture = this.Texture;
            base.Draw(view, projection, pos);
        }
    }

}
