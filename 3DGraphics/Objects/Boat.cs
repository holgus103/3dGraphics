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
    class Boat : TextureModelPhongObjectPhong
    {
        private const string TEXTURE_PATH = "Content\\Images\\boat.jpg";
        private static Model model;
        private static Texture2D texture;

        public Boat(ContentManager ctx, GraphicsDevice dev,  Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, dev, position, xRotation, yRotation, zRotation, scale, TEXTURE_PATH)
        {
            if (Boat.model == null)
            {
                Boat.model = ctx.Load<Model>("Models\\Row_Boat");
            }
        }

        public override Model Model => Boat.model;

        public override Texture2D Texture
        {
            get
            {
                return Boat.texture;
            }
            set
            {
                Boat.texture = value;
            }
        }
    }
}
