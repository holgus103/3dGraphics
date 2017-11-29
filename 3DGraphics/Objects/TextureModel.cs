using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    abstract class TextureModel : ModelObject
    {
        public abstract Texture2D Texture { get; set; }

        public TextureModel(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation, float scale, string texturePath) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            if (this.Texture == null)
            {
                using (var s = File.Open(texturePath, FileMode.Open))
                {
                    this.Texture = Texture2D.FromStream(dev, s);
                }
            }

        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            effect.Texture = this.Texture;
            base.Draw(view, projection, pos);
        }
    }

}
